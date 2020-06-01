using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    bool isPaused;
    AudioSource[] audioSources;
    public GameObject pauseMenuUI;
    private TextMeshProUGUI gameTimerUI;
    //   GameObject player;
    PlayerController player;
    bool isAlive = true;
    bool oneTime = false;

    public float gameTime = 10f;

    // public Button retry, quit;
    GameObject restartMenu;
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            restartMenu = GameObject.FindGameObjectWithTag("RestartMenu");
            gameTimerUI = GameObject.FindGameObjectWithTag("GameTimer").GetComponent<TextMeshProUGUI>();
        }
        audioSources = GameObject.FindObjectsOfType<AudioSource>();

        /* retry = GameObject.Find("RetryButton").GetComponent<Button>();
         quit = GameObject.Find("QuitButton2").GetComponent<Button>();*/

        RetryMenu(false);

    }
    // void Start()


    /*        Debug.Log(player.transform);*/
    /*if (!player)
    {

    }
    for (int i = 0; i < audioSources.Length; i++)
    {
        //Debug.Log(audioSources[i].name);
    }*/

    void Update()
    {
       
        /*
             if (!player.isAlive)
             {
                 isAlive = false;
                 Retry();

             }*/
        GameTimer();
        if (PlayerManager.playersAreDead)
        {
            RetryMenu(true);
        }
        else
            RetryMenu(false);


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGameButton();
            }
            else
            {
                PauseGameButton();
            }
        }
    }

    private void RetryMenu(bool b)
    {
        //if(!restartMenu.activeSelf)
        if (SceneManager.GetActiveScene().name != "MainMenu")
            restartMenu.SetActive(b);
        //if(isAlive == false)
        //{
        //     retry.enabled = true;
        //     retry.interactable = true;
        //}
        //else
        //{
        //    retry.enabled = false;
        //    retry.interactable = false;
        //}
    }

    public void NewGameButton()
    {
        LevelManager.instance.LoadNextScene(LevelManager.instance.firstSceneIndex + 1);


    }

    public void LoadGameButton()
    {
        LevelManager.instance.LoadLevel();



    }

    public void ResumeGameButton()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
    public void PauseGameButton()
    {
        pauseMenuUI.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;


    }

    public void QuitGameButton()
    {
        Application.Quit();
    }

    public void RestartButton()
    {
        LevelManager.instance.LoadNextScene(LevelManager.currentSceneIndex);
    }

    public void SoundButton()
    {

        if (SoundManager.instance.isPlaying)
        {

            SoundManager.instance.StopMusic(audioSources);
            SoundManager.instance.isPlaying = false;
        }
        else
        {
            SoundManager.instance.StopMusic(audioSources);
            SoundManager.instance.isPlaying = true;
        }

    }
    public void RestartGameButton()
    {
        LevelManager.instance.LoadNextScene(LevelManager.instance.firstSceneIndex);
    }

    public void GameTimer()
    {
        if (player)
        {
            gameTime -= Time.deltaTime;

            if (gameTimerUI)
            {
                if (gameTime > 0)
                    gameTimerUI.text = string.Format("{0:0}:{1:00}", (int)gameTime / 60, Mathf.FloorToInt(gameTime % 60));
                else
                    gameTimerUI.text = "Game Over";
            }

            if (gameTime <= 0)
            {
                PlayerController[] players = FindObjectsOfType<PlayerController>();

             
                if (!oneTime)
                {
                    PlayerManager.instance.PlayerDied(players);
                    oneTime = true;
                }
            }
        }
        else
            if (gameTimerUI)
                gameTimerUI.text = "Game Over";
        
    }

}
