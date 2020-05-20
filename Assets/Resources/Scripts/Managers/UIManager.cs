using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    bool isPaused;
    AudioSource[] audioSources;
    public GameObject pauseMenuUI;
 //   GameObject player;
    PlayerController player;
    bool isAlive = true;
 
    public Button retry, quit;
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
       
        audioSources = GameObject.FindObjectsOfType<AudioSource>();
       /* retry = GameObject.Find("RetryButton").GetComponent<Button>();
        quit = GameObject.Find("QuitButton2").GetComponent<Button>();*/

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

    private void Retry()
    {
        if(isAlive == false)
        {
             retry.enabled = true;
             retry.interactable = true;
        }
        else
        {
            retry.enabled = false;
            retry.interactable = false;
        }
    }

    public void NewGameButton() {
        LevelManager.instance.LoadNextScene(LevelManager.instance.firstSceneIndex+1);
       
   
    }
    
    public void LoadGameButton() {
        LevelManager.instance.LoadLevel();
       

        
    }

    public void ResumeGameButton() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
 

    }
    public void PauseGameButton() {
        pauseMenuUI.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
        

    }

    public void QuitGameButton() {
        Application.Quit();
    }

    public void RestartButton() {
        LevelManager.instance.LoadNextScene(LevelManager.currentSceneIndex);
    }

    public void SoundButton() {

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
    

}
