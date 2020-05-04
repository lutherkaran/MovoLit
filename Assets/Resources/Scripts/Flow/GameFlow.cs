using System.Collections;
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
        SoundManager.instance.Initialize();
    }
    public void PostInitialize()
    {
        LevelManager.instance.PostInitialize();
        FinishPointManager.instance.PostInitialize();
        PlayerManager.instance.PostInitialize();
        EnemyManager.instance.PostInitialize();
        SoundManager.instance.PostInitialize();
    }
    public void Refresh(float dt)
    {
        LevelManager.instance.Refresh(dt);
        FinishPointManager.instance.Refresh(dt);
        PlayerManager.instance.Refresh(dt);
        EnemyManager.instance.Refresh(dt);
        SoundManager.instance.Refresh(dt);
    }
    public void PhysicsRefresh(float fdt)
    {
        LevelManager.instance.PhysicsRefresh(fdt);
        FinishPointManager.instance.PhysicsRefresh(fdt);
        PlayerManager.instance.PhysicsRefresh(fdt);
        EnemyManager.instance.PhysicsRefresh(fdt);
        SoundManager.instance.PhysicsRefresh(fdt);
    }
}
