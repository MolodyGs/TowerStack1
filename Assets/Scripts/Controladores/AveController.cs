using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AveController : MonoBehaviour
{

    public GameObject Ave;
    GameObject InstanciaAve;
    AveController instance;
    public Camera camara;
    GameObject vacio;

    // Start is called before the first frame update
    private void Awake() {

        if(instance != null){

            Destroy(this.transform.gameObject);

        }
        instance = this;

    }

    void Start()
    {

        if(!SceneManager.GetActiveScene().name.Equals("Menu")){
            StartCoroutine(InstanceAve());
        }

    }


    IEnumerator InstanceAve(){
        vacio = new GameObject();
        vacio.transform.position = new Vector3(-750, (camara.transform.position.y + Random.Range(-200, 200)), 0);

        InstanciaAve = Instantiate(Ave, new Vector3(0, 0, 0), Quaternion.identity ); 
        InstanciaAve.transform.SetParent(vacio.transform);

        yield return new WaitForSeconds(Random.Range(2,6));
        StartCoroutine(InstanceAve());

    }
}
