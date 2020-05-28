﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : EnemyUnit
{
    public override void Initialize()
    {
        base.Initialize();
        enemyType = EnemyType.Ghosts;
        sprite.color = Random.ColorHSV();
        /*SoundManager.instance.PlaySFX("EnemySpawn", this.gameObject,1.5f);*/
    }
    public override void PostInitialize()
    {
        base.PostInitialize();

    }
    public override void Refresh(float dt)
    {
        base.Refresh(dt);

        if (targetFound)
        {
            
            FindCloseTarget();
            RotateTowardsTarget();
            if (!isDying)
                FollowTarget(dt);
        }
       

    }
    public override void PhysicsRefresh(float fdt)
    {
        base.PhysicsRefresh(fdt);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
   
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController[] players = FindObjectsOfType<PlayerController>();
            PlayerManager.instance.PlayerDied(players);
        
        }
        if (other.gameObject.CompareTag("Light"))
        {
/*            Debug.Log(other.gameObject.name);*/
            SoundManager.instance.PlaySFX("MDeath", this.gameObject, 1f);
            isDying = true;
        }

    }
    
}
