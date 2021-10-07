using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public Text livesText;
    public Text scoreText;
    public Text HStext;
    public bool gameOver;
    public GameObject gameOverPanel;
    public GameObject LoadLevelPanel;
    public int numberOfBricks;
    public Transform [] levels;
    public int currentLevelIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        numberOfBricks = GameObject.FindGameObjectsWithTag("brick").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;
        //verifica as vidas restantes e verifica o fim do jogo
        livesText.text = "Lives: " + lives;
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
    }
    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }
    public void UpdateNumberOfBricks()
    {
        numberOfBricks--;
        if (numberOfBricks <= 0){
            if(currentLevelIndex >= levels.Length - 1)
            {
            GameOver();
            }
            else
            {
                LoadLevelPanel.SetActive(true);
                LoadLevelPanel.GetComponentInChildren<Text>().text = "Level" + (currentLevelIndex + 2);
                gameOver = true;
                Invoke("LoadLevel", 2f);
            }
            
        }
    }
        void LoadLevel()
    {
                currentLevelIndex++;
                Instantiate(levels[currentLevelIndex], Vector2.zero, Quaternion.identity);
        numberOfBricks = GameObject.FindGameObjectsWithTag("brick").Length;
        gameOver = false;
        LoadLevelPanel.SetActive(false);
    }
    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        int highScore = PlayerPrefs.GetInt("HIGHSCORE");
        if(score > highScore)
        {
            PlayerPrefs.SetInt("HIGHSCORE", score);

            HStext.text = "New High Score!!   " + score;
        }
        else
        {
            HStext.text = "High Score  " + highScore + "\n" + "Can you beat it?";
        }
        
        }
    
    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Quit()
    {
        SceneManager.LoadScene("menu");
       
    }
}
