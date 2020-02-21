using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot_Function : MonoBehaviour
{
    public float ForceMinimum = 25;
    public float relativeVelocityMax = 40;
    public float Slingshot_force = 2.5f;

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
        Rigidbody2D rb2D = collision.gameObject.GetComponent<Rigidbody2D>();
        Debug.Log("Rigidbody of ball is found");
        Debug.Log("Ball's velocity is " + collision.relativeVelocity.magnitude);

        if(rb2D != null && collision.relativeVelocity.magnitude > ForceMinimum)
        {
            Debug.Log("Ball wasn't fast enough");
            //Debug.Log("Ball's velocity is " + collision.relativeVelocity.magnitude);
            if (collision.relativeVelocity.magnitude < relativeVelocityMax)
            {
                Debug.Log("Ball is fast enough");
                float pBall = collision.relativeVelocity.magnitude;
                rb2D.velocity = new Vector2(rb2D.velocity.x * .5f, rb2D.velocity.y * .5f);
                rb2D.AddForce(transform.forward * Slingshot_force * pBall);
            }
            else
            {
                Debug.Log("Ball was too fast enough");
            }
        }
    }
}
