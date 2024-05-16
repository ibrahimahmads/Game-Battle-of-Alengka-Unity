using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mov : MonoBehaviour
{
    Rigidbody2D rb;
    float moveX;
    Vector2 move;
    public float speed;
    public bool isgrounded;
    public float jumpPower;
    public LayerMask groundlayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        Move();
        Jump();
    }

    void Move()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        move = new Vector2(moveX, 0);

        transform.Translate(move * speed * Time.deltaTime);
    }

    void Jump()
    {
        if (isgrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(0, 1) * jumpPower;
            }
        }
    }
    void GroundCheck()
    {
        isgrounded = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundlayer);
    }

    
}
