using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase que controla el comportamiento entre estructuras cuando estas colisionan.
//--->1. Cambia los tags de las estructuras
//--->2. Destruye los scripts "Estructura.cs" de las estructuras, para que así no se ejecute el metodo "OnCollisionEnter2D" en estructuras no deseadas. 
//--->3. hace que la estructura, que el jugador dejó caer, si es que esta quedó cerca del centro de la estructura base, esta quede entonces exactamente centrada.
public class Estructura : MonoBehaviour
{
    int cont = 0;
    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("asdasd");
        if(GameController.instance.Getgameover())
        {
            return;
        }

        ScoreManager.instance.AddPoint();
        Debug.Log(other.gameObject.tag);

        if(other.gameObject.tag.Equals("Up"))      //Comprueba si la estructura colisionó con otra estructura.
        {

            //Si hemos entrado a este código, significa que "other" es una estructura (Especificamente la estructura base).
            //define que tan cerca del centro tiene que haber quedado la estructura para que esta quede centradada.
            if((this.transform.position.x < other.transform.position.x + 5) && (this.transform.position.x > other.transform.position.x - 5)) 
            {

                this.transform.rotation.Set(0f, 0f, 0f, 0f);                                                            //Cancela cualquier rotación que se haya podido producir.
                this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;                                     //Deja la estructura sin movimiento alguno
                this.transform.position = new Vector2(other.transform.position.x, other.transform.position.y + 80);    //Deja la estructura completamente centrada a la estructura base
                this.transform.rotation.Set(0f, 0f, 0f, 0f);                                                            //Cancela cualquier rotación que se haya podido producir.

               for(int c = cont; c < this.transform.parent.childCount; c++, cont = c)
                {
                    
                    this.transform.parent.GetChild(c).GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

                }
                
            }
            //Con estos else if calculamos si la estructura cayó muy cerca del borde, de tal forma que si es así, se le aplique una fuerza para que la estructura termine de caer.
            else if(this.transform.position.x > other.transform.position.x + 40)
            {
                                                                                                                    
                this.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(15000,0));
                
            }
            else if (this.transform.position.x < other.transform.position.x - 40)
            {

                this.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(-15000,0));

            }
            //Caso donde la estructura no cayó ni cerca del borde, ni cerca del centro.
            else
            {
                
                this.transform.position = new Vector2(this.transform.position.x, other.transform.position.y + 80);
            
            }

            other.gameObject.transform.tag = "Down";                //Deja a la estructura base con el Tag "Down".
            this.gameObject.transform.tag = "Up";                   //Deja a la estructura que ha caido con el Tag "Up".
            Destroy(this.gameObject.GetComponent<Estructura>());    //Destruye el script "Estructura.cs", de tal forma que las estructura no realicen acciones cuando colisionen entre ellas.

            GameController.instance.NextBlock();
           
        }

    }

}
