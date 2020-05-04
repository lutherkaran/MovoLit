using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    bool isPaused;
    AudioSource[] audioSources;
    public GameObject pauseMenuUI;
    GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSources = GameObject.FindObjectsOfType<AudioSource>();
    }
    void Start()
    {
/*        Debug.Log(player.transform);*/
        if (!player)
        {

        }
        for (int i = 0; i < audioSources.Length; i++)
        {
            Debug.Log(audioSources[i].name);
        }
    }
    void Update()
    {
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
    
    public void LoadGameButton() { // Load Last Scene
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

    public void RestartGameButton() {
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
    

}
