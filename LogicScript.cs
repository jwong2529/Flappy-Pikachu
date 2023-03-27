using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text highestScoreText;
    public GameObject gameOverScreen;
    public bool alive = true;
    private AudioSource gameMusic;

    public void addScore(int scoreToAdd) {
        if (alive == true) {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
        }
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver() {
        gameOverScreen.SetActive(true);
        updateHighestScore();
    }

    void Start(){
        int startHighScore = PlayerPrefs.GetInt("highScore", 0);
        highestScoreText.text = "Highest score: " + startHighScore.ToString();

        gameMusic = GetComponent<AudioSource>();
    }

    public void updateHighestScore() {
        if (playerScore > PlayerPrefs.GetInt("highScore")) {
            PlayerPrefs.SetInt("highScore", playerScore);
            highestScoreText.text = "Highest score: " + playerScore.ToString();
        }
    }

    public void quitGame() {
        Application.Quit();
    }
}
