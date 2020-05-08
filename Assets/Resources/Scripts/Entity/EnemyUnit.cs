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
    public GameObject[] Player;
    private Vector3 target;
    Vector3 direction;
    public Vector3 InitialPosition;
    public float speed;
    public bool targetsWithTorch;
    public EnemyType enemyType;

    public bool targetFound { get; private set; }

    public virtual void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        InitialPosition = transform.position;
        Player = GameObject.FindGameObjectsWithTag("Player");
       

    }

    public virtual void PostInitialize()
    {  
    }
    public virtual void PhysicsRefresh(float fdt)
    {
    }

    public virtual void Refresh(float dt)
    {
        UnityEngine.Debug.Log("Fuck");
        FindTarget();
    }

    public void FindTarget()
    {
       
        for (int i = 0; i < Player.Length; i++)
        {
            if (!Player[i].GetComponentInChildren<Torch>())
            {
                targetFound = true;
                target = Player[i].transform.position;
                
            }
            direction = target - transform.position;
        }
      
    }
    public void FollowTarget(float dt)
    {
      
        if (targetFound)
        {
            transform.position += direction.normalized * speed * dt;
        }
    }
    public void RotateTowardsTarget()
    {
        if (targetFound)
        {
            if (target.x < transform.position.x)
                transform.rotation = Quaternion.Euler(new Vector2(0, 180));
            else
                transform.rotation = Quaternion.Euler(new Vector2(0, 0));
        }
    }
    public void FindCloseTarget()
    {
        for(int i = 0; i < Player.Length; i++)
        {
            float[] distance = new float[Player.Length];
            if(!(Player[i].GetComponentInChildren<Torch>()))
            {
                 /*distance = Player[i].transform.position.magnitude;*/


                /*float closeTargetDistance_1 = Vector3.Distance(this.transform.position, Player[i].transform.position);
                float closeTargetDistance_2 = Vector3.Distance(this.transform.position, Player[Player.Length].transform.position);
                if (closeTargetDistance_1 < closeTargetDistance_2)
                {
                    UnityEngine.Debug.Log("Distance: " + closeTargetDistance_1);
                }
                else
                {
                    UnityEngine.Debug.Log("Distance: " + closeTargetDistance_2);
                }
                targetsWithTorch = true;*/
            }

        }
    }
}
