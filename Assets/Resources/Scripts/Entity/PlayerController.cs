﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IManagable
{
    public float speed;
    public float jumpForce;
    public Transform feet;
    readonly static float PlayerHpMax = 100;
    const float MaxGravity = -12f;
    private float playerHp = PlayerHpMax;

    public float jumpFrameTimer = 0;

    bool isInitialize;
    public bool jumpThresholdTime;

    InputManager inputManager;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator anim;
    Carried carried;

    public InputManager.InputInfo inputInfo;
    public bool isAlive;
    private bool jump;
    public bool canMove;
    Torch torch;
    Vector2 handPos;


    public void PlayerSpawned()
    {
        if (!isInitialize)
            Initialize();
        playerHp = PlayerHpMax;
    }

    public void Initialize()
    {

        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        inputManager = new InputManager();
        torch = GameObject.FindGameObjectWithTag("Torch").GetComponent<Torch>();
        Transform handTransform = transform.Find("Hand");
        handPos = handTransform.localPosition;
        GameObject.Destroy(handTransform.gameObject);


    }

    public void PhysicsRefresh(float fdt)
    {

    }

    public void PostInitialize()
    {
        isAlive = true;
        isInitialize = true;
        jumpThresholdTime = false;
        torch.Initialize();
    }

    public void Refresh(float dt)
    {
        inputManager.InputUpdate(dt);
        torch.Refresh();
        if (this.isAlive)
        {
            inputInfo = inputManager.GetInfo();

            if (canMove)
            {
                if (inputInfo.throwPressed)
                {
                    /* Debug.Log("Pressed");*/
                    if (carried)
                    {
                        GameObject throwObject = DetachObject();
                        ThrowTorch(throwObject);
                    }
                    else
                        Pickup();
                }

                PlayerJump(inputInfo.jumpPressed);
                if (!jump && !jumpThresholdTime)
                {
                    PlayerMove(inputInfo.inputDir);
                    //SoundManager.instance.PlaySFX("Run", this.gameObject);
                }
            }
            else
            {
                Debug.Log("Animator working");
                jump = false;
                rb.velocity = Vector2.zero;
            }
            ManageJump(dt);
            GravityCheck();
            PlayerAnimationStates();
        }

    }

    private void ThrowTorch(GameObject throwingObject)
    {

        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        Vector3 faceDirection = worldMousePosition - transform.position;
        var aimAngle = Mathf.Atan2(faceDirection.y, faceDirection.x);
        if (aimAngle < 0f)
        {
            aimAngle = Mathf.PI * 2 + aimAngle;
        }
        var aimDirection = Quaternion.Euler(0, 0, aimAngle * Mathf.Rad2Deg) * Vector2.right;
        // Vector2 dir = (Vector2)throwingObject.transform.position * faceDirection ;
        Torch t = throwingObject.GetComponent<Torch>();
        if (t)
        {
            t.rb.AddForce(aimDirection.normalized * t.force, ForceMode2D.Impulse);
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), t.GetComponent<Collider2D>());
            SoundManager.instance.PlaySFX("Throw", this.gameObject);

            /*
            torch.ThrowTorch(faceDirection);*/
        }
    }

    private GameObject DetachObject()
    {
        GameObject dropedObject = carried.gameObject;
        carried.Dropped();
        carried = null;
        return dropedObject;

    }

    private Collider2D FindTorch(float radius)
    {
        Collider2D colli = Physics2D.OverlapCircle(transform.position, radius, LayerMask.GetMask("Torch"));
        if (colli)
        {
           // Debug.Log(colli.name);
        }
        return colli;

    }

    private void Pickup()
    {
        Collider2D torchfound = FindTorch(1f);
        if (torchfound)
            PickupObject(torchfound.transform.gameObject);
    }

    private void PickupObject(GameObject go)
    {
        carried = Carried.PickUpObject(go, this.transform, handPos);
    }

    private void ManageJump(float dt)
    {
        jump = !Grounded();
        if (jumpThresholdTime)
        {
            jumpFrameTimer += dt;
            if (jumpFrameTimer > 0.25f)
            {
                jumpFrameTimer = 0;
                jumpThresholdTime = false;
            }
        }
    }

    private void PlayerMove(Vector2 dir)
    {
        if (dir.x == -1 || dir.x == 1)
        {

            if (dir.x == -1) { sprite.flipX = true; }
            else { sprite.flipX = false; }
            rb.velocity = dir.normalized * speed;
           

        }

    }

    private void PlayerJump(bool jumpPressed)
    {

        if (jumpPressed)
        {
            if (!jump)
            {
                jumpThresholdTime = true;
                Vector2 velocity = rb.velocity;
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(velocity.x, jumpForce), ForceMode2D.Impulse);

            }
        }
    }

    void GravityCheck()
    {
        if (!Grounded())
        {
            if (rb.velocity.y < MaxGravity)
            {
                rb.velocity = new Vector2(rb.velocity.x, MaxGravity);
            }
        }
    }

    private bool Grounded()

    {
        return Physics2D.OverlapCircle(feet.transform.position, 0.2f, LayerMask.GetMask("Ground"));

    }

    private void PlayerAnimationStates()
    {
        anim.SetBool("isJumping", jump);
        if (!jump)
            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.magnitude));
    }

}
