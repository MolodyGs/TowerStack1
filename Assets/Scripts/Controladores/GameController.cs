using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Contorla el juego en general.
//--->1. Crea Las estrucutas cuando el jugador haya decidido dejarla caer.
//--->2. Controla cuando se puede lanzar una nueva estructura.
//--->3. Controla que la camara se mueva hacia arriba.
public class GameController : MonoBehaviour
{

    public static GameController instance;
    public GameObject Estructura_Grua;      //Referencia de la estructura de la grua.
    public GameObject Padre;                //Referencia al gameobject "EstructurasApiladas" en la jerarquia.

    public GameObject Prefab;               //Prefab de una estructura.
    private GameObject EstructuraAux;       //Auxiliar para la creación de una estructura


    private bool gameover;

    //Con esto podemos calcular la incercia de la estructura de la grua.
    private float posicion0;    
    private float posicion1;
    private float diferencial;

    public Camera camara;                   //Referencia a la camara
    private Vector3 posicionCamara;

    public GameObject PantallaGameOver;     //Referencia al gameObject "GameOver" (Dentro del canvas).

    bool CorrutinaActiva = false; 

    private void Awake() 
    {
        if(instance != null)
        {
            Destroy(this.transform.gameObject);
        }

        instance = this;
        
        posicion1 = Estructura_Grua.transform.position.x;
        posicion0 = posicion1;

        this.posicionCamara = camara.transform.position;
        this.PantallaGameOver.SetActive(false);
        this.gameover = false;
    }
 
    //Mueve la camara dependiendo de "direccion".
    IEnumerator CamaraMov(int direccion, float posicionYEstructura)      
    {

        //Evitamos que 2 corrutinas se activen al mismo tiempo.
        while(CorrutinaActiva)
        {
            yield return new WaitForSeconds(0.1f);
        }

        switch(direccion){ 
            
            //La camara se mueve hacia arriba.
            case 1:
                
                CorrutinaActiva = true;
                float posicionReferencia = posicionYEstructura + 160; 
                while(true)
                {

                    camara.transform.position = new Vector3(camara.transform.position.x, camara.transform.position.y + 1, camara.transform.position.z);     

       
                    if(camara.transform.position.y >= posicionReferencia)
                    {          
                        break;
                    }  

                    yield return new WaitForSeconds(0.001f);        

                }
                CorrutinaActiva = false;
                break;

            //La camara se mueve hacia abajo.
            case 2:

                CorrutinaActiva = true;
                //La camara se mueve hasta la posicion inicial
                while(true)
                {
                    
                    if(camara.transform.position.y == posicionCamara.y)
                    {           
                        break;
                    }  

                    camara.transform.position = new Vector3(camara.transform.position.x, camara.transform.position.y - 1, -10);

                    yield return new WaitForSeconds(0.0025f);    

                }
                CorrutinaActiva = false;

                break;
            }  
            yield return new WaitForSeconds(0.001f);        //Espera 1 milisegundo antes de bajar 1 unidad mas, de tal forma que el movimiento se vea suavizado.

        }
    
    //Cuando perdemos, se activa este metodo.
    public void GameOver()
    {

        Estructura_Grua.SetActive(false);
        this.gameover = true;
        this.PantallaGameOver.SetActive(true);
        StopCoroutine(CamaraMov(1, 0));
        StartCoroutine(CamaraMov(2, 0));

        //Cambia todos los bodyType de los RigidBody's de las estructuras para que éstas sean afectadas completamente por la gravedad (bodytype = Dynamic).
        for(int c = 0; c < Padre.transform.childCount; c++)
        {

            this.Padre.transform.GetChild(c).GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        }

    }

    //Se puede dejar caer otra estructura.
    public void NextBlock(float posicionYEstructura){

        StartCoroutine(CamaraMov(1, posicionYEstructura)); 
        this.Estructura_Grua.SetActive(true);  

    }

    public bool Getgameover(){

        return this.gameover;

    }

    //Verifica si "space" ha sido presionado, creando una figura si ese es el caso
    private void Update()
    {

        //Calculamos la incercia de la estructura anclada a la grua.
        posicion0 = posicion1;
        posicion1 = Estructura_Grua.transform.parent.transform.position.x;
        diferencial = posicion1 - posicion0;
    
        //Verificamos si se presiona el espacio y si el juego no ha terminado.
        if(Input.GetKeyDown(KeyCode.Space) && !this.gameover && Estructura_Grua.activeSelf)
        {
        
            int rng = Random.Range(1, 4);
            
            //Se crea una estructura a partir de un prefab (Encontrado en Assets-> prefab), La estructura se crea justo donde haya estado la estructura de la grua.
            this.EstructuraAux = Instantiate(Prefab, Estructura_Grua.transform.position,Quaternion.identity);
            this.EstructuraAux.GetComponent<Rigidbody2D>().AddForce(new Vector2(4000*diferencial, -1000));

            //Hacemos que el objeto creado sea hijo del gameobject "EstructurasApiladas".
            this.EstructuraAux.transform.SetParent(Padre.transform);   

            //Se eligue una "skin" de estructura a azar.                        
            this.EstructuraAux.GetComponent<Animator>().SetInteger("Skin", rng);

            //Desactivamos la estructura de la grua, para que esta sea invisible.
            this.Estructura_Grua.SetActive(false);                                                      
        
        }

    }
        
}
    
   

