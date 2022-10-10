using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text highScoreText;

    public int score = 0;
    public int highscore=0;

    private void Awake()
    {
        if(instance == null){
            Debug.Log("Creando instancia");
            instance = this;
            return;
        }
        Debug.Log("fuera del if");
    }
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " PUNTOS";
        highScoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    // Update is called once per frame
    public void AddPoint() {
        score += 1;
        scoreText.text = score.ToString() + " PUNTOS";
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
