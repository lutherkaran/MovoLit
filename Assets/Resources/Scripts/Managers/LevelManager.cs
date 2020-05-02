using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager :IManagable
{
    #region Singleton
    private static LevelManager Instance;
    private LevelManager() { }
    public static LevelManager instance { get { return Instance ?? (Instance = new LevelManager()); } }
    #endregion

    public GameObject[] startPoints;
    public int totalStartPoints;
 
    public void Initialize()
    {

        startPoints=GameObject.FindGameObjectsWithTag("StartingPoint");
        totalStartPoints = startPoints.Length;
    }

    public void PhysicsRefresh()
    {
        
    }

    public void PostInitialize()
    {
        
    }

    public void Refresh(float dt)
    {
    }
}