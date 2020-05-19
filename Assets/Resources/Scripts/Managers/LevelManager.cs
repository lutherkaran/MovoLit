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
    public GameObject[] spawnners;
    public int totalStartPoints;
    public static int currentSceneIndex;
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
        enemySpawnners.AddRange(GameObject.FindObjectsOfType<EnemySpawnner>());
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
    public void SaveLevel()
    {
        SaveSystem.Save(currentSceneIndex);
    }
    public void LoadLevel()
    {
        LevelData data = SaveSystem.Load();
        currentSceneIndex = data.sceneIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}

[System.Serializable]
public class LevelData
{
   public int sceneIndex;
    public LevelData(int _sceneIndex)
    {
        this.sceneIndex = _sceneIndex;
    }
}