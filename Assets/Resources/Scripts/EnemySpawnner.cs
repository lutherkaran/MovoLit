using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemySpawnner : MonoBehaviour
{
    EnemyUnit enemy;
    Vector2 offset;
    Vector3 pos;
    public void Initialize()
    {
       
        enemy = FindObjectOfType<EnemyUnit>();
        pos = transform.position;
    }
    public void PostInitialize() { }
    public void Refresh(float dt) {
        offset = new Vector2(Random.Range(-11, 11), Random.Range(-25, 25));
       /* UnityEngine.Debug.Log(offset);*/
    }
    public void PhysicsRefresh(float fdt) { }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (!enemy)
            {
               TimeDelegate.instance.Action(()=>EnemyManager.instance.SpawnEnemy(EnemyType.Ghosts, /*new Vector2(Random.Range(-pos.x,pos.x), Random.Range(-pos.y, pos.y))+*/offset),5);
            }
        }
    }
}
