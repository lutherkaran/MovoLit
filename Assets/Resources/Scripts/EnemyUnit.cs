using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { Ghosts }
public abstract class EnemyUnit : MonoBehaviour ,IManagable
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sprite;
    Transform target;
    

    public virtual void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public virtual void PostInitialize()
    {
        FindTarget();

    }

    private void FindTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public virtual void PhysicsRefresh()
    {
       
    }

    public virtual void Refresh(float dt)
    {
       
    }
}
