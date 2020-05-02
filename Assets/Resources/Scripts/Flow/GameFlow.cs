﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : IManagable
{
    #region Singleton
    private static GameFlow Instance;
    private GameFlow() { }
    public static GameFlow instance { get { return Instance ?? (Instance = new GameFlow()); } }
    #endregion

    public void Initialize()
    {
        LevelManager.instance.Initialize();
        FinishPointManager.instance.Initialize();
        PlayerManager.instance.Initialize();
        EnemyManager.instance.Initialize();
    }
    public void PostInitialize()
    {
        LevelManager.instance.PostInitialize();
        FinishPointManager.instance.PostInitialize();
        PlayerManager.instance.PostInitialize();
        EnemyManager.instance.PostInitialize();
    }
    public void Refresh(float dt)
    {
        LevelManager.instance.Refresh(dt);
        FinishPointManager.instance.Refresh(dt);
        PlayerManager.instance.Refresh(dt);
        EnemyManager.instance.Refresh(dt);
    }
    public void PhysicsRefresh()
    {
        LevelManager.instance.PhysicsRefresh();
        FinishPointManager.instance.PhysicsRefresh();
        PlayerManager.instance.PhysicsRefresh();
        EnemyManager.instance.PhysicsRefresh();
    }
}
