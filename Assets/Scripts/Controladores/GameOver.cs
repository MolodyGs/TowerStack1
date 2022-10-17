using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    
    public void Reintentar()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void volverMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Game");
        }
    }
}
