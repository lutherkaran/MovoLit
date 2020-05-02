using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : IManagable
{
    #region Singleton
    private static EnemyManager Instance;
    private EnemyManager() { }
    public static EnemyManager instance { get { return Instance ?? (Instance = new EnemyManager()); } }

    #endregion
    public void Initialize()
    {    
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
