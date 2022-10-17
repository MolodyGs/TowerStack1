using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class B_VolverMenu : Button
{
    
    override
    public void OnUp(){

        SceneManager.LoadScene("Menu");
        Press = false;

    }

}
