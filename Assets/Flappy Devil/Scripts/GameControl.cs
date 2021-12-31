using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour 
{
public static GameControl instance;            //A reference to our game control script so we can access it statically.
    public Text scoreText;
    public Text highScoreText;
    public Text levelText;                        //A reference to the UI text component that displays the player's score.
    public GameObject gameOvertext;                //A reference to the object that displays the text which appears when the player dies.

    private int score = 0;                        //The player's score.
    public bool gameOver = false;                //Is the game over?
    public float scrollSpeed = -2.5f;
    private float progressPoint = 1;
    private int level = 1;
    public bool nextLevel = false;
    private int highScore = 0;
    public InterstitialAd insterstitial;
    
    void Awake()
    {
        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);
    }

    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.Escape))
        {
            //...back to menu
            SceneManager.LoadScene("MenuScene");

        }

            
    }

    public void BirdScored()
    {
        //The bird can't score if the game is over.
        if (gameOver)
        {
            return;
        }
        //If the game is not over, increase the score...
        score++;
        //...and adjust the score text.
        scoreText.text = "Score: " + score.ToString();
        ProgressBar.instance.IncrementProgress(progressPoint);
    }

    public void BirdDied()
    {   
        HighScoreUpdate();
        highScoreText.text = "Your High Score: " + PlayerPrefs.GetInt("High Score"); 
        //Activate the game over text.
        gameOvertext.SetActive(true);
        //Set the game to be over.
        gameOver = true;
        if (InterstitialAd.loadCount == 3)
        {
            insterstitial.ShowAd();
            InterstitialAd.loadCount = 0;
        }
        
    }
    public void LevelUp()

    {   nextLevel = true;
        level++;
        scrollSpeed -= 1;
        levelText.text = "Level: " + level.ToString();
        if (level == 3)
        {
            ColumnPool.instance.spawnRate = 1.5f;
        }

    }
    public void HighScoreUpdate()
    {
        highScore = PlayerPrefs.GetInt("High Score");
        if (score > highScore)
        {
            PlayerPrefs.SetInt("High Score", score);
        }
    }
}
