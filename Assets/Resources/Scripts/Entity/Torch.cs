﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Globalization;

public class Torch : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force;
    Collider2D otherCollider;

    TextMeshProUGUI torchPickText;
    RectTransform torchTextTransform;
    PlatformEffector2D[] effectors;
    GameObject checker;
    Vector3 textOffset = new Vector3(0, 1, 0);
    float counter = .5f;
    private Camera cam;
    PlayerDied[] deadZones;

    bool isPickedUp = false;
    Collider2D[] colliders;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;

        //try
        {
            //if(torchPickText == null)
            torchPickText = GameObject.FindGameObjectWithTag("TorchText").GetComponent<TextMeshProUGUI>();
            torchTextTransform = torchPickText.GetComponent<RectTransform>();
            colliders = GetComponents<PolygonCollider2D>();
            effectors = FindObjectsOfType<PlatformEffector2D>();
            deadZones = FindObjectsOfType<PlayerDied>();

        }
        //catch (System.Exception e)
        //{
        //    Debug.LogException(e, this);
        //}
        checker = GameObject.Find("Checker");
    }

    private void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.CompareTag("TorchPass"))
         {
             foreach (Collider2D collider in colliders)
             {
                // otherCollider = collision.gameObject.GetComponent<Collider2D>();
                // Physics2D.IgnoreCollision(collider, otherCollider, true);
                 collider.isTrigger = true;
                 TimeDelegate.instance.Action(() => collider.isTrigger = false, .2f);

             }
         }
        if (collision.gameObject.CompareTag("DeadZones"))
        {

            gameObject.SetActive(false);

            PlayerController player = FindObjectOfType<PlayerController>();
            if (player)
            {
                TimeDelegate.instance.Action(()=>Reposition(player),1.5f);
            }
            else
            {
                Debug.Log("Couldn't Find The player..!!");
            }
        }
     }

    private void Reposition(PlayerController player)
    {
        gameObject.transform.position = player.handTransform.position;
        TimeDelegate.instance.Action(() => this.gameObject.SetActive(true), 3f);
        player.PickupObject(this.gameObject);
    }

    private void OnCollisionExit2D(Collision2D collision)
     {
         if (collision.gameObject.CompareTag("TorchPass"))
         {
             foreach (Collider2D collider in colliders)
             {
                 //otherCollider = collision.gameObject.GetComponent<Collider2D>();
                // Physics2D.IgnoreCollision(collider, otherCollider, true);
                 TimeDelegate.instance.Action(() => collider.isTrigger = false, .2f);

             }
         }
     }


    public void Update()
    {
        //CheckPosition();
        isPickedUp = transform.parent ? true : false;

        try
        {
            //if (torchPickText)
            {
                if (!isPickedUp && Mathf.Abs(rb.velocity.x) < 2f && Mathf.Abs(rb.velocity.y) < 2f)
                {
                    Collider2D col = Physics2D.OverlapCircle(transform.position, .5f, LayerMask.GetMask("Player"));
                    if (col)
                    {
                        torchPickText.gameObject.SetActive(true);
                        torchTextTransform.position = cam.WorldToScreenPoint(transform.position + textOffset);
                    }
                    else
                    {
                        torchPickText.gameObject.SetActive(false);
                    }
                }
                else
                {
                    torchPickText.gameObject.SetActive(false);
                }

            }
        }
        catch (System.Exception e)
        {
            Debug.LogException(e, this);
        }
    }

    private void CheckPosition()
    {
        for (int i = 0; i < deadZones.Length; i++)
        {
            if (Vector2.Distance(transform.position, deadZones[i].transform.position) <= 0.5f)
            {
                TimeDelegate.instance.Action(() => gameObject.SetActive(false), 2f);
                PlayerController player = FindObjectOfType<PlayerController>();
                player.PickupObject(this.gameObject);
                this.gameObject.SetActive(true);
            }
            else
            {

            }

        }
        
        
        /*
        if (transform.position.y > checker.transform.position.y)
        {
            *//*this.GetComponent<Collider2D>().isTrigger = true;*//*
            for (int i = 0; i < effectors.Length; i++)
            {
                Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), effectors[i].gameObject.GetComponent<Collider2D>(), true);
            
                Debug.Log("True");
            }
        }
        else
        {
            *//*this.GetComponent<Collider2D>().isTrigger = false;*//*
             for (int i = 0; i < effectors.Length; i++)
             {
                 Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), effectors[i].gameObject.GetComponent<Collider2D>(), false);
                 Debug.Log("False");
             }
        }*/
    }
}
