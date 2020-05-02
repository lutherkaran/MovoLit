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
        PlayerManager.instance.Initialize();
        FinishPointManager.instance.Initialize();
        EnemyManager.
    }
    public void PostInitialize()
    {
        PlayerManager.instance.PostInitialize();
        FinishPointManager.instance.PostInitialize();
    }
    public void Refresh(float dt)
    {
        PlayerManager.instance.Refresh(dt);
        FinishPointManager.instance.Refresh(dt);
    }
    public void PhysicsRefresh()
    {
        PlayerManager.instance.PhysicsRefresh();
        FinishPointManager.instance.PhysicsRefresh();
    }
}
