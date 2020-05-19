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
    PlayerController[] players;
 
    public Button restart, quit;
    private void Start()
    {
        players = FindObjectsOfType<PlayerController>();
       
        audioSources = GameObject.FindObjectsOfType<AudioSource>();

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
        
        for (int i = 0; i <= players.Length; i++)
        {
            Debug.Log (players[i].transform.position) ;
            /*if (!players[i].isAlive)
            {
                Debug.Log("1");
                restart.enabled = true;
                quit.enabled = true;
            }
            else
            {
                Debug.Log("2");
                restart.enabled = false;
                quit.enabled = false;
              }*/
        }
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
