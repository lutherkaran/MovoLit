using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnner : MonoBehaviour
{
    EnemyUnit enemy;
    Vector2 offset;
    Vector3 pos;
    public void Initialize()
    {
        offset = new Vector2(Random.Range(-8, 8), Random.Range(-10, 10));
        enemy = FindObjectOfType<EnemyUnit>();
        pos = transform.position;
    }
    public void PostInitialize() { }
    public void Refresh(float dt) { }
    public void PhysicsRefresh(float fdt) { }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if(!enemy)
            EnemyManager.instance.SpawnEnemy(EnemyType.Ghosts, new Vector2(Random.Range(-pos.x,pos.x), Random.Range(-pos.y, pos.y))+offset);
        }
    }
}
