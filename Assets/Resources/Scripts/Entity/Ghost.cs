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
        SoundManager.instance.PlaySFX("EnemySpawn", this.gameObject);
    }
    public override void PostInitialize()
    {
        base.PostInitialize();
    }
    public override void Refresh(float dt)
    {
        base.Refresh(dt);
        
        if (!targetsWithoutTorch)
        {
            FindCloseTarget();
            RotateTowardsTarget();
        }
       
        FollowTarget(dt);

    }
    public override void PhysicsRefresh(float fdt)
    {
        base.PhysicsRefresh(fdt);
    }
}