using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public AudioClip estructuraClip;
    public AudioClip PuntuacionClip;
    public AudioClip MusicaFondo;
    public AudioClip MusicaFondoSinIntro;

    //Para la musica de fondo
    public AudioSource audioSource;

    //Para efectos de sonido
    public AudioSource efectosDeSonido;

    public Queue<AudioClip> clipQueue;

    public static MusicManager instance;

    private void Awake() 
    {
        if((instance != null)){

            Destroy(this.gameObject);

        }
        else
        {

            instance = this;
            this.transform.name = "MusicControllerUnico";
            DontDestroyOnLoad(this.gameObject);

            //Agregamos musica a la cola
            clipQueue = new Queue<AudioClip>();
            clipQueue.Enqueue(MusicaFondo);
            clipQueue.Enqueue(MusicaFondoSinIntro);

            //Audiosourse tiene el primer clip de la cola
            audioSource.clip = clipQueue.Dequeue();

            //Empieza a sonar el primer clip de la cola
            audioSource.Play(); 
        } 
        
    }

    public void Update()
    {
        //Carga la continuacion de la musica de fondo
        if (!audioSource.isPlaying) 
        {
            Debug.Log("Agregando cancion");
            clipQueue.Enqueue(MusicaFondoSinIntro);
            audioSource.clip = clipQueue.Dequeue();
            audioSource.Play();
        }
    }

    //Cambia el volumen de los audioSource's
    public void Volumen(float volumen)
    {
        audioSource.volume = volumen;
        efectosDeSonido.volume = volumen;
    } 


     public void estructuraCae()
     {
        efectosDeSonido.clip = estructuraClip;
        efectosDeSonido.Play();
     }

     public void PuntuacionMasAlta()
     {
        efectosDeSonido.clip = PuntuacionClip;
        efectosDeSonido.Play();
     }

     public float getVolumen(){

        return audioSource.volume;

     }
     
 }


