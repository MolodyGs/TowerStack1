using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B_Play : Boton
{

    override
    public void OnPressButtom(){

            img.sprite = sprites[2];
            Press = true;
    }

}

