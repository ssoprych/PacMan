using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasuePanel : MonoBehaviour
{
    public TMP_Text HighScore;
    public TMP_Text Score;

    void Update()
    {
        Score.text = "SCORE NOW: " + GameManager.Instance.Score;
        HighScore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void Resume()
    {
        gameObject.SetActive(false);
        GameManager.Instance.isPaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

}
