using System;
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

    InputManager.InputInfo inputInfo;
    bool isAlive;
    private bool jump;
    public bool canMove;
    Torch torch;

    public void PlayerSpawned()
    {
        if (!isInitialize)
            Initialize();
        playerHp = PlayerHpMax;
    }

    public void Initialize() {

        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        inputManager = new InputManager();
        torch = GameObject.FindGameObjectWithTag("Torch").GetComponent<Torch>(); 
      
        
        
    }

    public void PhysicsRefresh()
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
        
        if (this.isAlive)
        {
            inputInfo = inputManager.GetInfo();
            
            if (canMove)
            {
                ThrowTorch(inputInfo.throwPressed);
                PlayerJump(inputInfo.jumpPressed);
                if (!jump && !jumpThresholdTime)
                    PlayerMove(inputInfo.inputDir);
                   

            }
            ManageJump(dt);
            GravityCheck();
            PlayerAnimationStates();
        }

    }

    private void ThrowTorch(bool throwPressed)
    {
        
        if (throwPressed) {
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
            Vector3 faceDirection = worldMousePosition - transform.position;
            torch.ThrowTorch(faceDirection);
            SoundManager.instance.PlaySFX("Throw", this.gameObject);
        }
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
