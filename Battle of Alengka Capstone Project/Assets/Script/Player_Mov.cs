using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mov : MonoBehaviour
{
    AudioManager audioManager;
    PlayerStat stat;
    Rigidbody2D rb;
    float moveX;
    Vector2 move;
    public bool isgrounded;
    private bool isWalking = false;
    public LayerMask groundlayer;
    public float distanceGr;

    Animator animator;  
    // Start is called before the first frame update
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stat = GetComponent<PlayerStat>();
    }
    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        Move();
        Jump();
        direction(MouseCheck());
        Animation();
    }

    void Move()
    {
        moveX = Input.GetAxis("Horizontal");
        move = new Vector2(moveX, 0);

        transform.Translate(move * Time.deltaTime * stat.speed);
        if(moveX != 0 && isgrounded == true)
        {
            if(!isWalking) // Jika tidak sedang berjalan
            {
                isWalking = true;
                audioManager.PlaySFX(audioManager.walk);
            }
        }
        else
        {
            if(isWalking) // Jika sedang berjalan
            {
                isWalking = false;
                audioManager.StopSFX();
            }
        }
    }

    void Jump()
    {
            if (Input.GetKeyDown(KeyCode.Space) && isgrounded == true)
            {   
                rb.velocity = new Vector2(0, 1) * stat.jumpPower;
                audioManager.PlaySFX(audioManager.jump);
            }
    }
    void GroundCheck()
    {
        isgrounded = Physics2D.Raycast(transform.position, Vector2.down, distanceGr, groundlayer);
    }

    Vector3 MouseCheck()
    {
       Vector3 mouseP = stat.mousePos;
        return mouseP;
    }

    void direction(Vector3 direct)
    {
        Vector3 localScale = transform.localScale;
        if (direct.x > transform.position.x)
        {
            localScale.x = Mathf.Abs(localScale.x);
        }
        else
        {
            localScale.x = -Mathf.Abs(localScale.x);
        }
        transform.localScale = localScale;
    }

    void Animation()
    {
        animator.SetFloat("Moving", Mathf.Abs( moveX));
        animator.SetBool("OnGround", isgrounded);
    }
}
