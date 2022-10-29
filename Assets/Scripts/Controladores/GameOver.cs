using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Text ReitentaSpaceText;

    public void Reintentar()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void volverMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void OnEnable() 
    {
        StartCoroutine(RainBow());
    }

    //Si presionamos espacio, el juego vuelve a comenzar.
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Game");
        }
    }

    //Cambio de color cada 400 ms.
    IEnumerator RainBow()
    {
        ReitentaSpaceText.color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.4f);
        ReitentaSpaceText.color = new Color(255, 255, 0);
        yield return new WaitForSeconds(0.4f);
        ReitentaSpaceText.color = new Color(0, 255, 0);
        yield return new WaitForSeconds(0.4f);
        ReitentaSpaceText.color = new Color(0, 255, 255);
        yield return new WaitForSeconds(0.4f);
        ReitentaSpaceText.color = new Color(0, 0, 255);
        yield return new WaitForSeconds(0.4f);
        ReitentaSpaceText.color = new Color(255, 0, 255);
        yield return new WaitForSeconds(0.4f);
        StartCoroutine(RainBow());
    }
}
