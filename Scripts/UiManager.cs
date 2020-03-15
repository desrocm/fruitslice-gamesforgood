using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{

    public static UiManager instance;
    public Text scoreText;
    public GameObject gameOverPanel;
    public Text highScoreText;
    public GameObject gameOverSplat;
   

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ScoreManager.instance.score.ToString();
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("HighScore");
        if (Line.instance.gameOver == true)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        //gameOverSplat.SetActive(true);
        gameOverPanel.SetActive(true);
        
    }
    public void Replay()
    {
        SceneManager.LoadScene("level1");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

}
