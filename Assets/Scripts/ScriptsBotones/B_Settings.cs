using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Clase que controla el botón "Settings". Extiende de "Button"
public class B_Settings : Button
{

    public GameObject SettingsGameObj;                      //hademos referencia al gameobject "Settings". Rellenado desde unity.
    public GameObject Menu;                                 //Hacemos referencia al gameobject "Menu". Rellenado desde unity.
    RectTransform SettingsRectTransform;                    //Componente rectTransform del gameobject "Settings"
    
    private void Awake()                                    //Se inicia antes que un Start()
    {
        
        SettingsRectTransform = SettingsGameObj.GetComponent<RectTransform>();      //Obtenemos el componente rectTransform del objeto "Settings"    
        SettingsGameObj.SetActive(false);                                           //Desactivamos el panel de configuración.                                  
 
    }
    override
    public void OnUp()                                      //Se activa cuando dejamos de presionar el botón.
    {

            img.sprite = sprites[0];
            Press = false;
            Menu.SetActive(false);                          //Dejamos de mostrar el menu (Conformado por los botones "Play" y "Settings").
            SettingsGameObj.SetActive(true);                //Activamos el panel de configuracion (donde podemos cambiar el volumen del juego y efectos de sonido).

    }
}

