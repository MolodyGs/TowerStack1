using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//Clase que controla el comportamiento de un botón generico.
public abstract class Button : MonoBehaviour
{

    //Tiene un metodo abstracto "OnUp()" que tiene que ser definido por los distitnos botones que extienden de esta clase.

    public Image img;                           //Componente "Image" que se encuentra en el inspector de cada botón. Rellena desde unity.
    public Sprite[] sprites = new Sprite[3];    //Array de sprites. [0] Sprite default, [1] Sprite por encima, [2] Sprite presionando. Rellenada desde unity.
    public bool Exit = false;                   //Indica si el cursor está fuera del área del botón. Es publica para visualizarla desde unity.
    public bool Press = false;                  //Indica si el cursor está presionando el botón. Es publica para visualizarla desde unity.
    
    private void Start() {
        
        img = GetComponent<Image>();

    } 
    public void OnPressButton()                 //Se activa cuando presionamos el botón.
    {

        img.sprite = sprites[2];
        Press = true;

    }
    public void OnEnter()                       //Se activa cuando pasamos el cursor por encima del botón.
    {

        if(Exit && Press){

            img.sprite = sprites[1];    
            Exit = false;
            return;
        
        } 
        img.sprite = sprites[1];
        Exit = false;

    }
    public void OnExit()                        //Se activa cuando el cursor haya dejado de estar por encima del botón.
    {

        Exit = true;

        if(Press){

            img.sprite = sprites[2];
            return;    

        }
        img.sprite = sprites[0];

    }
    public abstract void OnUp();                //Metodo abstracto que se activa cuando hayamos dejado de presionar el botón.       
}
