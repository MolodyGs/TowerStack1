using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class Boton : MonoBehaviour
{

    public Image img;
    public Sprite[] sprites = new Sprite[3];
    public bool Exit = false;
    public bool Press = false;
    
    public abstract void OnPressButtom();

    private void Start() {
        
        img = GetComponent<Image>();

    }
    
    public void OnUp(){

        if(Exit){
            
        
        img.sprite = sprites[0];    
        Press = false;
        return;
        }

        img.sprite = sprites[1];    
        Press = false;

    }
    
    public void OnEnter(){

        if(Exit && Press){

            img.sprite = sprites[2];    
            Exit = false;
            return;
        
        } 
        img.sprite = sprites[1];
        Exit = false;

    }

    

    public void OnExit(){

        Exit = true;

        if(Press){

            img.sprite = sprites[2];
            return;    

        }
        img.sprite = sprites[0];

    }
}
