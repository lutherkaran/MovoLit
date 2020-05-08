using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public enum EnemyType { Ghosts }
public abstract class EnemyUnit : MonoBehaviour ,IManagable
{
    Rigidbody2D rb;
    Animator anim;
    public SpriteRenderer sprite;
    public Transform target;
    Vector3 direction;
    public Vector3 InitialPosition;
    public float speed;
    public EnemyType enemyType;

    public virtual void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        InitialPosition = transform.position;
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    public virtual void PostInitialize()
    {  
    }
    public virtual void PhysicsRefresh(float fdt)
    {
    }

    public virtual void Refresh(float dt)
    {
        FindTarget();
    }

    public void FindTarget()
    {
        
        direction = target.transform.position - transform.position;
       
    }
    public void FollowTarget(float dt)
    {
        if (target)
        {
            transform.position += direction.normalized * speed * dt;
        }
    }
}
