using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : IManagable
{
    #region Singleton
    private static PlayerManager Instance;
    private PlayerManager() { }
    public static PlayerManager instance { get { return Instance ?? (Instance = new PlayerManager()); } }
    #endregion
    bool isAlive;
    GameObject[] playerPrefab;
    GameObject PlayerParent;
    public List<PlayerController> playersList;
    public PlayerController activePlayer { get; set; }

    

    public void Initialize()
    {
        playerPrefab = new GameObject[1];
        playersList = new List<PlayerController>();
        PlayerParent = new GameObject();
        playersList.AddRange(GameObject.FindObjectsOfType<PlayerController>());
       
        foreach (PlayerController p in playersList)
        {
            p.PlayerSpawned();
        }
        //SpawnPlayer(); 
    }

    private void SpawnPlayer()
    {
        if (!activePlayer)
        {
            playerPrefab[0] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
            activePlayer = playerPrefab[0].GetComponent<PlayerController>();
           /* playerPrefab[1] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Player2"));*/
            playersList.Add(activePlayer);
        }
        activePlayer.PlayerSpawned();
    }

    public void PhysicsRefresh()
    {
        foreach (PlayerController p in playersList)
        {
            if (p)
                p.PhysicsRefresh();
        }
    }

    public void PostInitialize()
    {
        foreach (PlayerController p in playersList)
        {
            if (p)
                p.PostInitialize();
        }
    }

    public void Refresh(float dt)
    {
        foreach (PlayerController p in playersList)
        {
            if (p)
                p.Refresh(dt);
        }
    }
    
    
}
