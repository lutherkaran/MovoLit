using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager :IManagable
{
    #region Singleton
    private static LevelManager Instance;
    private LevelManager() { }
    public static LevelManager instance { get { return Instance ?? (Instance = new LevelManager()); } }
    #endregion

    public GameObject[] startPoints;
    public int totalStartPoints;
    static public int currentSceneIndex;
    public int firstSceneIndex = 0;
    public List<EnemySpawnner> enemySpawnners;

 
    public void Initialize()
    {
        FirstInitialze();
        foreach(EnemySpawnner spawnner in enemySpawnners)
        {
            spawnner.Initialize();
        }

    }

    private void FirstInitialze()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        /*Debug.Log(currentSceneIndex);*/
        startPoints = GameObject.FindGameObjectsWithTag("StartingPoint");
        totalStartPoints = startPoints.Length;
        enemySpawnners = new List<EnemySpawnner>();
    }

    public void PhysicsRefresh(float fdt)
    {
        foreach (EnemySpawnner spawnner in enemySpawnners)
        {
            spawnner.PhysicsRefresh(fdt);
        }
    }

    public void PostInitialize()
    {
        foreach (EnemySpawnner spawnner in enemySpawnners)
        {
            spawnner.PostInitialize();
        }
    }

    public void Refresh(float dt)
    {
        foreach (EnemySpawnner spawnner in enemySpawnners)
        {
            spawnner.Refresh(dt);
        }
    }
    public void LoadNextScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}