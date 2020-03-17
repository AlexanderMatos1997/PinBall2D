﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot_Function : MonoBehaviour
{
    public float ForceMinimum;
    public float relativeVelocityMax;
    public float Slingshot_force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb2D = collision.gameObject.GetComponent<Rigidbody2D>();
        Debug.Log("Rigidbody of ball is found");
        Debug.Log("Ball's velocity is " + collision.relativeVelocity.magnitude);

        if (rb2D != null && collision.relativeVelocity.magnitude > ForceMinimum)
        {
            if (collision.relativeVelocity.magnitude < relativeVelocityMax)
            {
                Debug.Log("Ball is fast enough");
                float pBall = collision.relativeVelocity.magnitude;
                rb2D.velocity = new Vector2(rb2D.velocity.x * 1.5f, rb2D.velocity.y * 1.5f);
                rb2D.AddForce(transform.forward * Slingshot_force * pBall);
                Debug.Log("Ball's new velocity is " + collision.relativeVelocity.magnitude);
            }
            else
            {
                Debug.Log("Ball was moving too fast");
            }
        }
        else
        {
            Debug.Log("Ball wasn't fast enough");
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb2D = collision.gameObject.GetComponent<Rigidbody2D>();
        Debug.Log("Rigidbody of ball is found");
        Debug.Log("Ball's velocity is " + collision.attachedRigidbody.velocity);

        if (rb2D != null && collision.attachedRigidbody.velocity.magnitude > ForceMinimum)
        {
            if (collision.attachedRigidbody.velocity.magnitude < relativeVelocityMax)
            {
                Debug.Log("Ball is fast enough");
                float pBall = collision.attachedRigidbody.velocity.magnitude;
                rb2D.velocity = new Vector2(rb2D.velocity.x * 1.5f, rb2D.velocity.y * 1.5f);
                rb2D.AddForce(transform.forward * Slingshot_force * pBall);
                Debug.Log("Ball's new velocity is " + collision.attachedRigidbody.velocity.magnitude);
            }
            else
            {
                Debug.Log("Ball was moving too fast");
            }
        }
        else
        {
            Debug.Log("Ball wasn't fast enough");
        }
    }
}
