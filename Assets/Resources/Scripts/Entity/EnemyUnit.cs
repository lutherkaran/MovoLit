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
    public List<PlayerController> players;

    public bool targetFound { get; private set; }

    public virtual void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        InitialPosition = transform.position;
        players = new List<PlayerController>();
        players.AddRange(FindObjectsOfType<PlayerController>());
        /*Player = GameObject.FindGameObjectsWithTag("Player");*/
       

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
        // FindTarget();
        FindCloseTarget();
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

        for (int i = 0; i < players.Count; i++) {

            if (!(players[i].GetComponentInChildren<Torch>()))
            {
                int index = i;
                targetFound = true;
                target = players[index].transform.position;
                direction =  target - this.transform.position;
/*                UnityEngine.Debug.Log("1");*/
            }
         
             if (!(players[0].GetComponentInChildren<Torch>()) && !(players[1].GetComponentInChildren<Torch>())) {
               /* UnityEngine.Debug.Log("2");*/

                
                float distance = Vector2.Distance(this.transform.position, players[0].transform.position);
               /* UnityEngine.Debug.Log("Distance:"+distance);*/
                float distance2 = Vector2.Distance(this.transform.position, players[1].transform.position);
             /*   UnityEngine.Debug.Log("Distance2:" + distance2);*/
                if (distance < distance2)
                {
                    target = players[0].transform.position;
                    direction = target - this.transform.position;
                }
                else
                {
                    target = players[1].transform.position;
                    direction = target - this.transform.position;
                }
            }

        }
        /*for(int i = 0; i < Player.Length; i++)
        {
            Transform[] playerTransform = new Transform[Player.Length];
            if (!(Player[i].GetComponentInChildren<Torch>()))
            {
                UnityEngine.Debug.Log(Player[i].transform.position);
                playerTransform[i] = Player[i].GetComponent<Transform>();
                targetsWithoutTorch = true;
                direction = GetClosetTargetsTransfrom(playerTransform);
                
            }
        }*/
    }
   /* Vector3 GetClosetTargetsTransfrom(Transform[] players)
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
    }*/
}
