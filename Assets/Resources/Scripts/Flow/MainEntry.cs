using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEntry : MonoBehaviour
{
    void Awake() {
        
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
        GameFlow.instance.PhysicsRefresh();
    }
}
