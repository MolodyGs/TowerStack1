using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Clase que controla el botón "Exit". Extiende de "Button"
public class B_Exit : Button
{

    public GameObject SettingsGameObj;      //Game object en la jerarquia llamado "Settings"
    private RectTransform rect;              //Componente rectTransform del gameobject "Settings"
    public GameObject Menu;

    private void Start() {
        
        rect = SettingsGameObj.GetComponent<RectTransform>();   //Obtenemos el componente rectTransform del objeto "Settings"

    }
    
    //Sobreescribimos el metodo abstracto "OnPressButton" de la clase "Button"
    override
    public void OnUp(){


            img.sprite = sprites[0];
            Press = false;

            if(SettingsGameObj.activeInHierarchy){

                SettingsGameObj.SetActive(false);
                Menu.SetActive(true);
                return;

            }
            if(SceneManager.GetActiveScene().name.Equals("Menu"))
            {

                Debug.Log("Quit");
                Application.Quit();
                return;

            }
                        
            //rect.position = new Vector3(0, -1000, 0);      //Movemos el gameObject a la direccion inicial en la que estaba (Depende de en donde lo hayamos dejado en Unity)
            
    }

}

