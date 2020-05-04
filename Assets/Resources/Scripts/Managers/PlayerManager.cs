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

    
    GameObject[] playerPrefab;
    GameObject playerParent;
    public List<PlayerController> playersList;
    public PlayerController player { get; set; }
    public int playerIndex;
    GameObject[] startPoints;
    /*public Dictionary<PlayerController, bool> playersDict;*/
    

    public void Initialize()
    {
        startPoints = new GameObject[LevelManager.instance.totalStartPoints];
        startPoints = LevelManager.instance.startPoints;
        playerPrefab = new GameObject[startPoints.Length];
        playersList = new List<PlayerController>();
        playerParent = new GameObject("PlayerParent");
     
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
                playerPrefab[i] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Player"), startPoints[i].transform.position, Quaternion.identity);
                playerPrefab[i].name = "Player " + (i + 1);
                playerPrefab[i].transform.SetParent(playerParent.transform);
                playersList.Add(playerPrefab[i].GetComponent<PlayerController>());
            }
            player = playerPrefab[0].GetComponent<PlayerController>();
            playerIndex = 0;
            player.canMove = true;

            /*  playersDict.Add(player,player.canMove);*/

            /*
             * 
                        playerPrefab[1] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Player2"), startLocs[1].transform.position, Quaternion.identity);
                        inActivePlayer = playerPrefab[1].GetComponent<PlayerController>();
                        inActivePlayers.Add(inActivePlayer);
            */
            /*     playerPrefab[2] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Player2"), startLocs[2].transform.position, Quaternion.identity);
                 player = playerPrefab[2].GetComponent<PlayerController>();
                 inActivePlayers.Add(player);*/
        }

        player.PlayerSpawned();
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
        CanMoveInput();
        foreach (PlayerController p in playersList)
        {
            if (p == player)
            {
                p.canMove = true;
                p.Refresh(dt);
            }
            else
            {
                p.canMove = false;
            }
        }

        Debug.Log(player.transform);
    }

    private void CanMoveInput()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {
           
            int index = (playerIndex + 1) % playersList.Count;
            player = playersList[index];
            playerIndex = index;
         
        }
    }
}
