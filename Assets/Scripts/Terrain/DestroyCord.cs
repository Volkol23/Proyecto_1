﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCord : MonoBehaviour
{
    public GameObject Candel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Plataform"))
            transform.parent = collision.transform;

        if (collision.gameObject.tag.Equals("Bullet"))
        {
            Candel.GetComponent<Rigidbody2D>().bodyType-=2;

            Destroy(collision.gameObject);
                Destroy(gameObject);



        }
    }
}