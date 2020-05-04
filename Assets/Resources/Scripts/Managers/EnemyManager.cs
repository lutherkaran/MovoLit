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

    public Dictionary<EnemyType, GameObject> enemyPrefabDict;
    Transform parent;

    public void Initialize()
    {
        enemyPrefabDict = new Dictionary<EnemyType, GameObject>();
        enemyPrefabDict.Add(EnemyType.Ghosts, Resources.Load<GameObject>("Prefab/Ghost"));
        parent = new GameObject("EnemyParent").transform;

    }

    public void PhysicsRefresh(float fdt)
    { 
    }

    public void PostInitialize()
    {  
    }

    public void Refresh(float dt)
    {  
    }
}
