using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    bool isPaused;
    AudioSource[] audioSources;
    public GameObject pauseMenuUI;
    PlayerController player;
    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        audioSources = FindObjectsOfType<AudioSource>();
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
        LevelManager.instance.LoadNextScene(LevelManager.instance.firstSceneIndex);
    }
    
    public void LoadGameButton() { // Load Last Scene
    }

    public void ResumeGameButton() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        player.canControl = false;

    }
    public void PauseGameButton() {
        pauseMenuUI.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
        player.canControl = true;

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
