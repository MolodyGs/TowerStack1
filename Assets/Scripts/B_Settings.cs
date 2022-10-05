using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B_Settings : Boton
{

    public RectTransform recT;
    public float[] posicion;
    
    public GameObject Padre;
    private void Awake() {
        
        posicion = new float[2];
        posicion[0] = recT.position.x;
        posicion[1] = recT.position.y;

    }

    override
    public void OnPressButtom(){

            img.sprite = sprites[2];
            Press = true;
            Debug.Log(recT.position.x + " y=" + recT.position.y);
            recT.position = new Vector3(posicion[0], posicion[1], 0);
    }

}

