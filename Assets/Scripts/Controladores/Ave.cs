using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ave : MonoBehaviour
{
    private float vel;
    private int dir;

    void Start()
    {
        //Velocidad random para el ave
        vel = Random.Range(3.0f, 4.5f);

        //Usando la velocidad random, creamos una direccion random hacia donde irá el ave.
        if(vel >= 3.75f)
        {

            //El ave irá de derecha a izquierda
            dir = -1;
            //el ave comienza el vuelo desde el lado derecho del escenario.
            this.transform.position = new Vector3((this.transform.position.x*(-1)), this.transform.position.y, 0);
            //El sprite queda volteado, por medio de la esacala en el transform.
            this.transform.localScale = new Vector3(-1, 1, 1);

        }
        else
        {
            //El ave irá de izqueida a derecha
            dir = 1;
            //En este caso, la velocidad es menor a 3.75, esto significa que va más lento, entonces reduciremos la escala del ave, de tal forma que se vea lejana.
            this.transform.localScale = new Vector3((this.transform.localScale.x*(0.5f)), (this.transform.localScale.y*(0.5f)), 1);

        }

        StartCoroutine(dead());
        
    }

    //Se destruye el gameObject luego de 2.5 segundo.
    IEnumerator dead()
    {

        yield return new WaitForSeconds(2.5f);
        Destroy(this.gameObject);

    }

    void Update()
    {
        
        //El ave vuela a cierta velocidad, en cierta direccion y con cierta pendiente.
        this.transform.position = new Vector3((this.transform.position.x + (vel*dir)), (this.transform.position.y + vel*(Random.Range(0.1f, 0.5f))), 0);
       
    }
}
