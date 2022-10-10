using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Contorla el juego en general.
//--->1. Crea Las estrucutas cuando el jugador haya decidido dejar caer la estrucutra.
//--->2. Controla el tiempo entre estructuras.
//--->3. Controla el efecto de que la camara se mueva hacia arriba (Aunque no es así en realidad, las estructuras son las que se mueven).
public class GameController : MonoBehaviour
{
    
    public static GameController instance;
    public GameObject Estructura_Grua;      //Referencia de la grua.
    public GameObject Padre;                //Referencia al gameobject "Estructuras" en la jerarquia.
    public GameObject Prefab;               //Prefab de una estructura.
    private GameObject EstructuraAux;       //Estrucutra creada a la semejanza de un prefab.

    private bool gameover;
    private float posiciciont0;
    private float posiciciont1;
    private float diferencial;

    public Camera camara;                   //Referencia a la camara

    private Vector3 posicionCamara;
    public GameObject PantallaGameOver;

    bool space;                             //Controla cuando hayamos dejado cae un objeto con el espacio (space)
    

    private void Awake() {

        if(instance == null){
            instance = this;

        }
        else
        {

            Destroy(this);

        }
        posiciciont0 = 0;
        posiciciont1 = 1;
        this.posicionCamara = camara.transform.position;
        this.PantallaGameOver.SetActive(false);
        this.gameover = false;

    }
    //Espera 0.75 segundos, luego de esto el jugador podrá dejar caer otra estructura.
    IEnumerator Time()                      
    {
        yield return new WaitForSeconds(0.75f);                 //espera 0.75 segundos.
        StartCoroutine(CamaraMov(1));                            //Comienza la corrutina "CamaraMov()".
        Estructura_Grua.SetActive(true);   //Activa la estructura de la grua, para que esta sea visible.         
        NextBlock();                                  

    }
    //Mueve la camara hacia arriba (En realidad las estructuras son las que van hacia abajo, dando la ilusion de que la camara sube).
    //Esto es así porque la camara ve en todo momento al canvas, independientemente de si la camara está en un lugar u otro (Debe haber una forma de hacer esto con la camara misma).
    IEnumerator CamaraMov(int direccion)      
    {

        int c = 0; 
        switch(direccion){
            
            case 1:
                //La camara sube 85 unidades hacia arriba. 
                while(true){

                    c++;
                    camara.transform.position = new Vector3(camara.transform.position.x, camara.transform.position.y + 1, -10);     //Mueve las estrucutas 1 unidad hacia abajo
                    if(c == 85){           //If que se activa cuando las estructuras hayan bajado 180 unidades

                        c = 0;
                        break;
                    }  
                    yield return new WaitForSeconds(0.001f);        //Espera 1 milisegundo antes de bajar 1 unidad mas, de tal forma que el movimiento se vea suavizado.
                }
                break;

            case 2:
                //La camara se mueve hasta la posicion inicial
                while(true)
                {
                    Debug.Log(posicionCamara[1]);
                    Debug.Log("camara" + camara.transform.position.y);
                    if(camara.transform.position.y == posicionCamara[1])
                    {           
                        break;
                    }  
                    camara.transform.position = new Vector3(camara.transform.position.x, camara.transform.position.y - 1, -10);

                    yield return new WaitForSeconds(0.0025f);    

                }
                yield return 0;     //Es necesario para que el IEnumerator no de error. necesita que se retorne lo que sea.
                break;

        }
        yield return 0;
        
    }

    //Verifica si el espacio ha sido presionado, creando una figura si es que se presiona.
    void Update()
    {

        //Calculamos la pendiente de la recta tangente a la curva que produce la animacion de la grua (Aproximada).
        posiciciont0 = posiciciont1;
        posiciciont1 = Estructura_Grua.transform.parent.transform.position.x;
        diferencial = posiciciont1 - posiciciont0;

        if(Input.GetKeyDown(KeyCode.Space) && !this.gameover)
        {
        
            if(!this.space)     //Verifica si el espacio fue ya presionado antes.
            {

                space = true;
                
                //Se crea una estructura a partir de un prefab (Encontrado en Assets-> prefab), La estructura se crea justo donde haya estado la estructura de la grua.
                this.EstructuraAux = Instantiate(Prefab, Estructura_Grua.transform.position,Quaternion.identity);
                this.EstructuraAux.GetComponent<Rigidbody2D>().AddForce(new Vector2(4000*diferencial, -1000));
                this.EstructuraAux.transform.SetParent(Padre.transform);                                             //Hacemos que el objeto creado sea hijo del gameobject "Estructuras".

                this.Estructura_Grua.SetActive(false);                                                          //Desactivamos la estructura de la grua, para que esta sea visible.  
                StartCoroutine(Time());                                                                         //Comienza la corrutina Time().
            
            }
            
        }

    }

    public void GameOver()
    {

        //Estructura_Grua.transform.parent.transform.SetParent(Estructura_Grua.transform.parent.transform.parent.transform.parent);
        Estructura_Grua.SetActive(false);
        this.gameover = true;
        this.PantallaGameOver.SetActive(true);
        StartCoroutine(CamaraMov(2));

        //Cambia todos los RigidBodoys de las estructuras para que estas sean afectadas completamente por la gravedad
        for(int c = 0; c < Padre.transform.childCount; c++){

            this.Padre.transform.GetChild(c).GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        }

    }

    public void NextBlock(){

        this.space = false;

    }

    public bool Getgameover(){

        return this.gameover;

    }



   
}
