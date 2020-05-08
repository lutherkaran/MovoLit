using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnner : MonoBehaviour
{
    EnemyUnit enemy;
    Vector2 offset;
    public void Awake()
    {
        offset = new Vector2(8, 1);
        enemy = FindObjectOfType<EnemyUnit>();
    }
    public void Update() { }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if(!enemy)
            EnemyManager.instance.SpawnEnemy(EnemyType.Ghosts, (Vector2)this.transform.position+offset);
        }
    }
}
