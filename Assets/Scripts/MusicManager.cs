using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{

    public AudioClip MusicaFondo;
    public AudioClip MusicaFondoSinIntro;
    public AudioSource audioSource;
    public AudioSource efectosDeSonido;

    public AudioClip estructuraClip;
    public AudioClip PuntuacionClip;
    
    public Queue<AudioClip> clipQueue;


    public static MusicManager instance;

    private void Awake() {
        

        if((instance != null) && ( GameObject.Find("MusicControllerUnico") != null)){

            Destroy(this.gameObject);

        }
        instance = this;
        this.transform.name = "MusicControllerUnico";
        DontDestroyOnLoad(this.gameObject);

        clipQueue = new Queue<AudioClip>();
        clipQueue.Enqueue(MusicaFondo);
        clipQueue.Enqueue(MusicaFondoSinIntro);
        audioSource.clip = clipQueue.Dequeue();
        audioSource.Play();

        //MusicaFondo = this.GetComponents<AudioSource>()[0];

        //ChoqueEstructura = this.GetComponents<AudioSource>()[1];

    }

    //Cambia el volumen de los audioSource's
    public void Volumen(float volumen){

        audioSource.volume = volumen;
        efectosDeSonido.volume = volumen;

    } 


    public void Update()
     {
        //Carga la continuacion de la musica de fondo
         if (!audioSource.isPlaying) {

            Debug.Log("Agregando cancion");
             clipQueue.Enqueue(MusicaFondoSinIntro);
             audioSource.clip = clipQueue.Dequeue();
             audioSource.Play();
         }
     }

     public void estructuraCae(){

        efectosDeSonido.clip = estructuraClip;
        efectosDeSonido.Play();

     }

     public void PuntuacionMasAlta(){

        efectosDeSonido.clip = PuntuacionClip;
        efectosDeSonido.Play();

     }
     
 }


