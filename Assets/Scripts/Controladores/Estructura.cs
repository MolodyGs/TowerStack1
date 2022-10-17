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
    public Sprite[] particulas;
    public GameObject particula;

    private void Start() 
    {
        this.GetComponent<Animator>().speed = (Random.Range(0.7f, 2));
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        MusicManager.instance.estructuraCae();

        if(other.gameObject.tag.Equals("Up"))      //Comprueba si la estructura colisionó con otra estructura.
        {
            //Si hemos entrado a este código, significa que "other" es una estructura (Especificamente la estructura base o la punta del edificio).
            //Este if discrimina que tan cerca del centro quedo la estructura para que esta quede completamente centradada (Si +5 y -5 son números más grandes, entonces es más facil centrar la estructura).
            if((this.transform.position.x < other.transform.position.x + 5) && (this.transform.position.x > other.transform.position.x - 5)) 
            {
                this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;                                     //Deja la estructura sin movimiento alguno
                this.transform.position = new Vector2(other.transform.position.x, other.transform.position.y + 90);     //Deja la estructura completamente centrada a la estructura base
                this.transform.rotation = Quaternion.Euler(0, 0, 0);                                                    //Cancela cualquier rotación que se haya podido producir.

                //Deja toda la estructura o eficio sin movimiento (BodyType = Static), de tal forma que sea más sencillo seguir construyendo.
                for(int c = cont; c < this.transform.parent.childCount; c++, cont = c)
                {
                    this.transform.parent.GetChild(c).GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                }
                //Se crean particulas que saldrán eyectadas con el doble de fuerza (2).
                CrearParticulas(2);
                //Agregamos un punto para el jugador. (serían 2 puntos, con la linea 89).
                ScoreManager.instance.AddPoint(1);
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
            else    
            {
                this.transform.position = new Vector2(this.transform.position.x, other.transform.position.y + 90);
            }

            //Con estos tags sabemos que estructura está arriba y cual está abajo.
            other.gameObject.transform.tag = "Down";                //Deja a la estructura base con el Tag "Down".
            this.gameObject.transform.tag = "Up";                   //Deja a la estructura que ha caido con el Tag "Up".


            //Agregamos un punto para el jugador.
            ScoreManager.instance.AddPoint(1);

            //Las estrucuctura ya cayó, entonces damos aviso a que se pueda lanzar otra estructura.
            GameController.instance.NextBlock(this.transform.position.y);
        }
        else
        {
            //Si estamos aquí, entonces hemos tocado el suelo.
            GameController.instance.GameOver();
        }
        
        //Destruyemos el componente Animator, para que termine de girar la estructura.
        Destroy(this.GetComponent<Animator>());

        //Destruye el script "Estructura.cs", de tal forma que las estructuras no realicen acciones cuando colisionen entre ellas.
        Destroy(this.GetComponent<Estructura>()); 

        //Independientemente de como haya caido la estructura, se crean particulas al impactar.
        CrearParticulas(1);
    }

    //Crea particulas con cierta posición y fuerza.
    private void CrearParticulas(int Fuerza)
    {
        //Para que las particulas queden en una posición aleatoria.
        float rng = Random.Range(0.25f, 1);

        //Se crean 5 particulas. "int c" Va de -2 a 2 para efectos practicos.
        for(int c = -2; c<3; c++)
        {
            //Crea una particula con un sprite aleatorio.
            particula.GetComponent<SpriteRenderer>().sprite = particulas[Random.Range(0, 10)];
            //Instalncia la particula justo debajo de la estructura.
            Instantiate(particula, new Vector3(this.transform.position.x + (20*rng*c), this.transform.position.y-60, 0), Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(new Vector2(800*Fuerza*c,1000*Fuerza));
        }
    }
}
