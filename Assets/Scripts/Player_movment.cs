﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movment : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    private Rigidbody2D Rigidbody2D;
    private float horizontal;
    private float vertical;
    public bool in_ground;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        // if fly == true
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);


        if (Physics2D.Raycast(transform.position, Vector3.down, 0.22f))
        {
            in_ground = true;
        }
        else in_ground = false;


        if (Input.GetKeyDown("space")&& in_ground)
        {
            Jump();
        }
    }
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up*JumpForce);

    }


    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(horizontal, vertical);
    }
}
