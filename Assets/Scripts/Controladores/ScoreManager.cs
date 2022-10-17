using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text scoreTextInGameOver;
    public Text highScoreText;
    public Text highScoreTextInGameOver;
    public Text ScoreAlcanzado;

    public int score = 0;
    public int highscore = 0;

    bool puntuacionAltaAlcanzada = false;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.transform.gameObject);
        }

        if(instance == null)
        {
            instance = this;
            return;
        }
    }

    void Start()
    {
        ScoreAlcanzado.gameObject.SetActive(false);
        highscore = PlayerPrefs.GetInt("HighScore", 0);
        scoreText.text = score.ToString() + " PUNTOS";

        highScoreText.text = "HIGHSCORE: " + highscore.ToString();
        highScoreTextInGameOver.text = "HIGHSCORE: " + highscore;
    }

    public void AddPoint(int score)
    {
        this.score += score;
        scoreText.text = this.score.ToString() + " PUNTOS";
        scoreTextInGameOver.text = scoreText.text;

        if (highscore < this.score)
        {
            PlayerPrefs.SetInt("HighScore", this.score);
            highScoreTextInGameOver.text = "HIGHSCORE: " + this.score;

            if(puntuacionAltaAlcanzada)
            {    
                MusicManager.instance.PuntuacionMasAlta();
                puntuacionAltaAlcanzada = true;
            }
        }

        if(this.score == 10 || this.score == 20 || this.score == 50 || this.score == 100)
        {
            StartCoroutine(ScoreAlcanzadoIE());
        }
    }

    IEnumerator ScoreAlcanzadoIE()
    {
        ScoreAlcanzado.text = "Alcanzaste los " + this.score;
        ScoreAlcanzado.transform.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        ScoreAlcanzado.transform.gameObject.SetActive(false);
    }

}
