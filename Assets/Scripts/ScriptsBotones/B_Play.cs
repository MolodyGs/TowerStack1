using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Clase que controla el botón "Play". Extiende de "Button"
public class B_Play : Button
{

    override
    public void OnUp()              //Se activa cuando dejamos de presionar el botón.
    {

        Press = false;
        if(!Exit)
        {

            img.sprite = sprites[1];
            SceneManager.LoadScene("Game");
            return;
        }

        SceneManager.LoadScene("Game");         //Cargamos la escena "Menu"
        img.sprite = sprites[0];            
            
    }

}

