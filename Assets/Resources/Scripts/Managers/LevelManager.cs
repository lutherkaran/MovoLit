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

 
    public void Initialize()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;    
        
/*        Debug.Log(currentSceneIndex);*/
        startPoints=GameObject.FindGameObjectsWithTag("StartingPoint");
        totalStartPoints = startPoints.Length;
       
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
    public void LoadNextScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}