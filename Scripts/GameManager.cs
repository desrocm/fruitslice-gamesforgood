﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    bool gameOver;
    public GameObject playButton;

    void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
        if(instance == null)
        {
            instance = this;
        } 
       // else
       // {
        //    Destroy(this.gameObject);
       // }
    }
    void Start()
    {
        gameOver = false;
        playButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        FruitSpawner.instance.StartSpawning();
        playButton.SetActive(false);
    }
    public void GameOver()
    {
        gameOver = true;
        UiManager.instance.GameOver();
        FruitSpawner.instance.StopSpawning();

    }
}
