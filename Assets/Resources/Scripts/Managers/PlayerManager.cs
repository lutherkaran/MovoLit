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
    public PlayerController Player { get; set; }
    public int playerIndex;
    GameObject[] startPoints;
    /*public Dictionary<PlayerController, bool> playersDict;*/

    public void Initialize()
    {
        // startPoints = new GameObject[LevelManager.instance.totalStartPoints];
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
    public void PostInitialize()
    {

        //foreach (PlayerController p in playersList)
        //{
        //    p.PostInitialize();
        //}
        for (int i = 0; i < playersList.Count; i++)
        {
            playersList[i].PostInitialize();
        }
    }

    private void SpawnPlayer()
    {
        if (!Player)
        {

            for (int i = 0; i < playerPrefab.Length; i++)
            {
                playerPrefab[i] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Player"), startPoints[i].transform.position, Quaternion.identity);
                playerPrefab[i].name = "Player " + (i + 1);
                playerPrefab[i].transform.SetParent(playerParent.transform);
                playersList.Add(playerPrefab[i].GetComponent<PlayerController>());
            }
            Player = playerPrefab[0].GetComponent<PlayerController>();
            playerIndex = 0;
            Player.canMove = true;

            #region Unneccessary 
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
        #endregion

    }

    public void PhysicsRefresh(float fdt)
    {
        foreach (PlayerController p in playersList)
        {
            if (p)
                p.PhysicsRefresh(fdt);
        }

    }

    public void Refresh(float dt)
    {
        // CanMoveInput();
        foreach (PlayerController p in playersList)
        {
            //if (p == Player)
            //  {
            //    p.canMove = true;
            p.Refresh(dt);

            if (playersList.Count > 1)
            {
                if (p.inputInfo.switchPlayerPressed)
                {
                    p.canMove = !p.canMove;
                }
            }
            // }
            // else
            //  {
            //      p.canMove = false;
            //  }
        }

        /* Debug.Log(Player.transform);*/
    }
    public void PlayerDied()
    {
         
        for (int i = 0; i < playersList.Count; i++)
        {
            SoundManager.instance.PlaySFX("Death", playersList[i].gameObject, 0.2f);
            playersList[i].canMove = false;
            playersList[i].isAlive = false;
            GameObject.Destroy(playersList[i], 1f);
            playersList.Remove(playersList[i]);
            playersList.Clear();
        }




    }
    /*private void CanMoveInput()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {

            int index = (playerIndex + 1) % playersList.Count;
            Player = playersList[index];
            playerIndex = index;

        }
    }*/
}
