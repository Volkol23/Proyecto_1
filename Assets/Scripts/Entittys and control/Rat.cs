﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public GameObject Prota;
    Rigidbody2D Rigidbody2D;

    public int Health = 1;
    public bool in_wall= false;
    public float vertical =0;
    private float LastShoot;
    public void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        Player_movment variable = GetComponent<Player_movment>();
        vertical = 0;
        if ( GetComponent<Player_movment>().enabled == true)
        {
            if ((Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.E)) && Time.time> LastShoot + 0.3f)
            {
                
                LastShoot = Time.time;
            }
        }
        if (Physics2D.Raycast(transform.position, Vector3.right, 0.16f))
        {
            if (in_wall == false) { 
                transform.Rotate(0, 0, 90);
            in_wall = true;
            }

        }
        else if (Physics2D.Raycast(transform.position, Vector3.left, 0.16f))
        {
            if (in_wall == false) { 
            transform.Rotate(0, 0, -90);
            in_wall = true;
            }

        }
        else in_wall = false;

        if (transform.rotation.z != 0)
        {
            if (in_wall == false)
                transform.Rotate(0, 0, -90);
        }
        if (in_wall == true)
        {
            vertical = Mathf.Abs(GetComponent<Player_movment>().horizontal);
        }
    }
    private void FixedUpdate()
    {
        if (vertical == 1|| vertical ==-1)
        Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, vertical * GetComponent<Player_movment>().Speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("Bullet") || collision.gameObject.tag.Equals("Enemy"))
        {
            if (gameObject.tag.Equals("Controlable"))
                Health -= 1;
            if (Health == 0)
            {

                Debug.Log("Dead Enemy");
                Destroy(gameObject);
            }




        }
    }
}

