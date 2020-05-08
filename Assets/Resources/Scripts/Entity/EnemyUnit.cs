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
    public bool targetsWithoutTorch;
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
/*        UnityEngine.Debug.Log("Fuck");*/
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
                
            direction = target - transform.position;
            }
            else{
                Vector3 moveRandom = new Vector3(UnityEngine.Random.Range(-10,10), UnityEngine.Random.Range(-10, 10),0);
                direction = moveRandom - transform.position;
            }
        }
        
      
    }
    public void FollowTarget(float dt)
    {
      
        if (targetsWithoutTorch)
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
            Transform[] playerTransform = new Transform[Player.Length];
            if (!(Player[i].GetComponentInChildren<Torch>()))
            {
               
                playerTransform[i] = Player[i].GetComponent<Transform>();
                targetsWithoutTorch = true;
                direction = GetClosetTargetsTransfrom(playerTransform);
                
            }
        }
    }
    Vector3 GetClosetTargetsTransfrom(Transform[] players)
    {
        Transform minTransform = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform t in players)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                minTransform = t;
                minDist = dist;
            }
        }
        return minTransform.position;
    }
}
