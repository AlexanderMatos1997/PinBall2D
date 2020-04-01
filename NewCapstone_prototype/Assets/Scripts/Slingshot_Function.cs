using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot_Function : MonoBehaviour
{
    public float ForceMinimum;
    public float relativeVelocityMax;
    public float Slingshot_force;

    public GameObject lightEffect;
    public GameObject instantLE;

    private AudioSource slshAudio;

    // Start is called before the first frame update
    void Start()
    {
        slshAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

                slshAudio.Play();

                SlingShot();

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

    void SlingShot()
    {
        instantLE = Instantiate(lightEffect, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(instantLE, 0.45f);
    }
}
