using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainEntry : MonoBehaviour
{
    
    void Awake() {
        CheckCreditScene();
        /*  go = this.gameObject;
          DontDestroyOnLoad(go);
          SoundManager.instance.PlayMusic("Theme", go, true);*/
        Time.timeScale = 1;
        GameFlow.instance.Initialize();   
    }

    private void CheckCreditScene()
    {
        String sceneName =SceneManager.GetActiveScene().name;
       // Debug.Log(sceneName);
        /*if (sceneName == "Credits")
        {
            Destroy(this);
        }
        else {
            DontDestroyOnLoad(this);
        }*/
    }

    void Start()
    {
        GameFlow.instance.PostInitialize();

    }
    void Update()
    {
        
        float dt = Time.deltaTime;

        GameFlow.instance.Refresh(dt);
    }
    private void FixedUpdate()
    {
        float fdt = Time.fixedDeltaTime;
        GameFlow.instance.PhysicsRefresh(fdt);
    }
}
