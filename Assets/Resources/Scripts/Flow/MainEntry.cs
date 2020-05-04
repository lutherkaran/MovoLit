using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEntry : MonoBehaviour
{
    
    void Awake() {
        /*  go = this.gameObject;
          DontDestroyOnLoad(go);
          SoundManager.instance.PlayMusic("Theme", go, true);*/
        Time.timeScale = 1;
        GameFlow.instance.Initialize();   
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
