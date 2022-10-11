using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCielo : MonoBehaviour
{

    public GameObject[] prefabsNubes;

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.tag.Equals("Fondo"))
        {

            Debug.Log("tag = fondo");
            Instantiate(prefabsNubes[Random.Range(0,1)], new Vector3(other.transform.position.x, other.transform.position.y + 1007.5f, 0), Quaternion.identity);
            Destroy(other.transform.GetComponent<BoxCollider2D>());

        } 
    }

}
