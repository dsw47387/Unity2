using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject loseUI;
    public int points = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public AudioSource scoreSound;

    public void StartGame()
    {
        Time.timeScale = 1;
    }

    private void ShowLoseUI()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        scoreText.text = "Score: " + points;
        highScoreText.text = "High Score: " + highScore;
        loseUI.SetActive(true);
    }

    public void RepeatGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void OnGameOver()
    {
        CheckHighScore();
        ShowLoseUI();
        Time.timeScale = 0;
    }

    public void UpdateScore()
    {
        points++;
        scoreText.text = points.ToString();
        scoreSound.Play();
    }

    private void CheckHighScore()
    {
        if (points > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", points);
        }
    }
    
    public void LoadMenuScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
