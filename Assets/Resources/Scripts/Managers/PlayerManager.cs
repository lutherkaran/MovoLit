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
    public Dictionary<PlayerController, bool> playersDict;
    public List<PlayerController> playersList;
    public PlayerController activePlayer { get; set; }
    public PlayerController inActivePlayer { get; set; }
    public PlayerController player { get; set; }
    public List<PlayerController> inActivePlayers;
       


    GameObject[] startLocs;
    

    public void Initialize()
    {
        playerPrefab = new GameObject[3];
        playersDict = new Dictionary<PlayerController, bool>();
        playersList = new List<PlayerController>();
        inActivePlayers = new List<PlayerController>();
        startLocs = GameObject.FindGameObjectsWithTag("StartingPoint");
     
        SpawnPlayer();

        foreach (PlayerController p in playersList)
        {
            p.PlayerSpawned();
        }
    }

    private void SpawnPlayer()
    {
        if (!player)
        {

            for (int i = 0; i < playerPrefab.Length; i++)
            {
                playerPrefab[i] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Player"), startLocs[i].transform.position, Quaternion.identity);

                inActivePlayers[i] = playerPrefab[i + 1].GetComponent<PlayerController>();
                inActivePlayers[i].canMove = false;
                inActivePlayers.Add(inActivePlayers[i]);

            }
            activePlayer = playerPrefab[0].GetComponent<PlayerController>();
            activePlayer.canMove = true;
            playersList.Add(activePlayer);

            for(int i = 0; i < playerPrefab.Length; i++)
            {
                
            }


            /*  playersDict.Add(player,player.canMove);*/

            /*
                        playerPrefab[1] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Player2"), startLocs[1].transform.position, Quaternion.identity);
                        inActivePlayer = playerPrefab[1].GetComponent<PlayerController>();
                        inActivePlayers.Add(inActivePlayer);
            */
            /*     playerPrefab[2] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Player2"), startLocs[2].transform.position, Quaternion.identity);
                 player = playerPrefab[2].GetComponent<PlayerController>();
                 inActivePlayers.Add(player);*/
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
