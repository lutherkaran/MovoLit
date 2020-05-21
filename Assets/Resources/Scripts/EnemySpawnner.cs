using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemySpawnner : MonoBehaviour
{
    EnemyUnit enemy;
    Vector2 offset;
    GameObject[] spawnPoints;
    Vector3 randomLocation;
    public void Initialize()
    {
       
        enemy = FindObjectOfType<EnemyUnit>();
        spawnPoints =  GameObject.FindGameObjectsWithTag("SpawnPoint");
    }
    public void PostInitialize() {
       
    }

    private void FindRandomPoint()
    {
        int randomNumber = UnityEngine.Random.Range(0, spawnPoints.Length);
        randomLocation = spawnPoints[randomNumber].transform.position;
    }

    public void Refresh(float dt) {
         FindRandomPoint();
        // offset = new Vector2(Random.Range(-11, 11), Random.Range(-25, 25));
        /* UnityEngine.Debug.Log(offset);*/

    }
    public void PhysicsRefresh(float fdt) { }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (!enemy)
            {
               TimeDelegate.instance.Action(()=>EnemyManager.instance.SpawnEnemy(EnemyType.Ghosts, /*new Vector2(Random.Range(-pos.x,pos.x), Random.Range(-pos.y, pos.y))+*/randomLocation),5);
            }
        }
    }
}
