using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBar : MonoBehaviour
{

    public void Volumen(){

        MusicManager.instance.Volumen(this.GetComponent<Scrollbar>().value);

    }

}
