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
    List<EnemyUnit> EnemyUnitsList;
    Transform parent;

    public void Initialize()
    {
        enemyPrefabDict = new Dictionary<EnemyType, GameObject>
        {
            { EnemyType.Ghosts, Resources.Load<GameObject>("Prefabs/Ghost") }
        };
        parent = new GameObject("EnemyParent").transform;

        EnemyUnitsList = new List<EnemyUnit>();
        EnemyUnitsList.AddRange(GameObject.FindObjectsOfType<EnemyUnit>());

        for(int i = 0; i < EnemyUnitsList.Count; i++)
        {
            if (EnemyUnitsList[i].transform.parent == null)
                EnemyUnitsList[i].transform.SetParent(parent);
            else
                EnemyUnitsList[i].transform.SetParent(parent);

            EnemyUnitsList[i].Initialize();
        }


    }

    public void PhysicsRefresh(float fdt)
    { 
        foreach(EnemyUnit enemy in EnemyUnitsList)
        {
            enemy.PhysicsRefresh(fdt);
        }
    }
    public void PostInitialize()
    {
        foreach (EnemyUnit enemy in EnemyUnitsList)
        {
            enemy.PostInitialize();
        }
    }
    public void Refresh(float dt)
    {
        foreach (EnemyUnit enemy in EnemyUnitsList)
        {
            enemy.Refresh(dt);
        }
    }
    public EnemyUnit SpawnEnemy(EnemyType enemy,Vector2 pos)
    {
        EnemyUnit newEnemy;

        newEnemy = GameObject.Instantiate(enemyPrefabDict[enemy], pos, Quaternion.identity, parent).transform.GetComponentInChildren<EnemyUnit>();
        newEnemy.Initialize();
        newEnemy.PostInitialize();
        EnemyUnitsList.Add(newEnemy);

        return newEnemy;

    }
    public void Died(EnemyUnit enemy)
    {
        EnemyUnitsList.Remove(enemy);
    }

}
