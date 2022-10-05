using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B_Exit : Boton
{

    public GameObject Padre;
    public GameObject Menu;
    public RectTransform recT;

    private void Start() {
        
        recT.position = new Vector3(0, -1000, 0);

    }
    
    override
    public void OnPressButtom(){

            img.sprite = sprites[0];
            Press = false;
            Exit = false;
            recT.position = new Vector3(0, -1000, 0);
            
    }

}

