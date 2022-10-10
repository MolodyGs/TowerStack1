using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class B_Replay : Button
{
    
    override
    public void OnUp(){

        SceneManager.LoadScene("Game");
        Press = false;

    }

}
