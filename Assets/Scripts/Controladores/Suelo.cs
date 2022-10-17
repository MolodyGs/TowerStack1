using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suelo : MonoBehaviour
{

    //public Sprite[] partesEstructura;
    public Vector3 estructura;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.transform.name.Equals("Particula(Clone)"))
        {
            Destroy(other.gameObject);
        }
    }
}
