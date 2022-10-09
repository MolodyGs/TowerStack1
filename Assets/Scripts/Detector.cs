using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Detecta si una estructura ha caido, esto lo hace por medio del tag de la estrucutra.
public class Detector : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) 
    {   
        //La estructura, cuando cae, cambia el tag de la estructura que está por debajo de la siguiente manera:
        //Tag estructura que cae = Up. Tag estructura por debajo = "Down". Esto lo puedes ver en el código Estructura.cs Linea 24 y 25.

        if(other.gameObject.tag.Equals("Up"))           
        {

            SceneManager.LoadScene("Menu");  //Cargamos la scena "Menu" (Falta en realidad cargar un panel donde podamos elegir entre ir al menú o volver a intentarlo).

        }

    }
    
}
