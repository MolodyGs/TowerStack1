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

    bool space;                             //Controla cuando hayamos dejado cae un objeto con el espacio (space)
    

    //Espera 0.75 segundos, luego de esto el jugador podrá dejar caer otra estructura.
    IEnumerator Time()                      
    {
        yield return new WaitForSeconds(0.75f);                 //espera 0.75 segundos.
        StartCoroutine(CamaraMov());                            //Comienza la corrutina "CamaraMov()".
        Estructura_Grua.GetComponent<Image>().enabled = true;   //Activa la estructura de la grua, para que esta sea visible.  
        space = false;                                          

    }
    //Mueve la camara hacia arriba (En realidad las estructuras son las que van hacia abajo, dando la ilusion de que la camara sube).
    //Esto es así porque la camara ve en todo momento al canvas, independientemente de si la camara está en un lugar u otro (Debe haber una forma de hacer esto con la camara misma).
    IEnumerator CamaraMov()      
    {
        int c = 0; 
        while(true)
        {
            c++;
            Padre.transform.position = new Vector2(Padre.transform.position.x, Padre.transform.position.y - 1);     //Mueve las estrucutas 1 unidad hacia abajo
            if(c == 180){           //If que se activa cuando las estructuras hayan bajado 180 unidades

                c = 0;
                break;
            }  
            yield return new WaitForSeconds(0.001f);        //Espera 1 milisegundo antes de bajar 1 unidad mas, de tal forma que el movimiento se vea suavizado.

        }
        yield return 0;     //Es necesario para que el IEnumerator no de error. necesita que se retorne lo que sea.
        
    }
    //Verifica si el espacio ha sido presionado, creando una figura si es que se presiona.

    
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
        
            if(!space)     //Verifica si el espacio fue ya presionado antes.
            {

                space = true;

                //Se crea una estructura a partir de un prefab (Encontrado en Assets-> prefab), La estructura se crea justo donde haya estado la estructura de la grua.
                EstructuraAux = Instantiate(Prefab, Estructura_Grua.transform.position,Quaternion.identity);
                EstructuraAux.transform.SetParent(Padre.transform);                                             //Hacemos que el objeto creado sea hijo del gameobject "Estructuras".

                Estructura_Grua.GetComponent<Image>().enabled = false;                                          //Desactivamos la estructura de la grua, para que esta sea visible.  
                StartCoroutine(Time());                                                                         //Comienza la corrutina Time().
            
            }
            
        }

    }

   
}
