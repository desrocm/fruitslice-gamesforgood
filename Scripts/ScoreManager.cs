using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    public int highscore;
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
        score = 0;
        highscore = PlayerPrefs.GetInt("HighScore");
        PlayerPrefs.SetInt("Score", score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncrementScore()
    {
        score++;
        if (score > highscore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        } 

    }

}
