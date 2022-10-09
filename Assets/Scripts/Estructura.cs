using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase que controla el comportamiento entre estructuras cuando estas colisionan.
//--->1. Cambia los tags de las estructuras
//--->2. Destruye los scripts "Estructura.cs" de las estructuras, para que así no se ejecute el metodo "OnCollisionEnter2D" en estructuras no deseadas. 
//--->3. hace que la estructura, que el jugador dejó caer, si es que esta quedó cerca del centro de la estructura base, esta quede entonces exactamente centrada.
public class Estructura : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other) 
    {
        ScoreManager.instance.AddPoint();

        if(other.gameObject.name.Equals("EstructuraR(Clone)"))      //Comprueba si la estructura colisionó con otra estructura.
        {
            //Si hemos entrado a este código, significa que "other" es una estructura (Especificamente la estructura base).

            //define que tan cerca del centro tiene que haber quedado la estructura para que esta quede centradada.
            if((this.transform.position.x < other.transform.position.x + 15) && (this.transform.position.x > other.transform.position.x - 15)) 
            {

                this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;         //Deja la estructura sin movimiento alguno
                this.transform.position = new Vector2(other.transform.position.x, other.transform.position.y + 180);    //Deja la estructura completamente centrada a la estructura base
                this.transform.rotation.Set(0f, 0f, 0f, 0f);        //Cancela cualquier rotación que se haya podido producir.
                
            }

            other.gameObject.transform.tag = "Down";                //Deja a la estructura base con el Tag "Down".
            this.gameObject.transform.tag = "Up";                   //Deja a la estructura que ha caido con el Tag "Up".
            Destroy(this.gameObject.GetComponent<Estructura>());    //Destruye el script "Estructura.cs", de tal forma que las estructura no realicen acciones cuando colisionen entre ellas.

        }

    }

}
