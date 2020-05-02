using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPointManager : IManagable
{
    #region Singleton
    private static FinishPointManager Instance;
    private FinishPointManager() { }
    public static FinishPointManager instance { get { return Instance ?? (Instance = new FinishPointManager()); } }
    #endregion

    List<FinishPoint> finishPoints;

   
    public void Initialize()
    {
        finishPoints = new List<FinishPoint>();
        finishPoints.AddRange(GameObject.FindObjectsOfType<FinishPoint>());

        foreach(FinishPoint fp in finishPoints)
        {
            fp.Initialize();

        }
    }

    public void PhysicsRefresh()
    {
        foreach (FinishPoint fp in finishPoints)
        {
            fp.PhysicsRefresh();
        }
    }

    public void PostInitialize()
    {

        foreach (FinishPoint fp in finishPoints)
        {
            fp.PostInitialize();
        }
    }

    public void Refresh(float dt)
    {

        //foreach (FinishPoint fp in finishPoints)
        //{
        //    if (fp.playerReached == true)
        //    {
        //        Debug.Log("Yo yo");
        //    }

        //    fp.Refresh(dt);
        //}
        if (!LevelFinisher())
        {
            Debug.Log("//Players have not reached yet");
        }
        else
        {
            Debug.Log("Game Won");
        }
       
       
    }

    bool LevelFinisher()
    {
        for (int i = 0; i < finishPoints.Count; i++)
        {
            if (finishPoints[i].playerReached)
            {
                continue;
            }
            else
            {
                Debug.Log("Players have not reached yet");
                return false;
            }
        }
        return true;
    }

    
}
