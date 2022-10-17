using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBar : MonoBehaviour
{

    private void Awake() {
        
        this.GetComponent<Scrollbar>().value = MusicManager.instance.getVolumen();

    }

    public void Volumen(){

        MusicManager.instance.Volumen(this.GetComponent<Scrollbar>().value);

    }

}
