using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumber_Code : MonoBehaviour
{
    [SerializeField]
    public ParentBumber_function parent;
    //public int points;
    public float bumperForce;
    public int bumperHealth;
    public Sprite bumpSprite;

    public void Awake()
    {
        parent = GetComponentInParent<ParentBumber_function>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            GameObject ballRB = collision.gameObject;
            /* This is the first time using Vector2.Reflect, but to have a better undertsanding the ballRB.GetComponent<Rigidbody2D>().velocity
               represents the velocity of the ball of the ball, while collision.contacts[0].normal is the point at which the ball hits the object that
               script is attach to. AddForce(Vector2.Reflect()) takes the velocity value and the point the ball collided with the object and "reflects"
               the ball object to the other direction. bumperForce basically adds to the velocity of the ball.
             */
            ballRB.GetComponent<Rigidbody2D>().AddForce(Vector2.Reflect(ballRB.GetComponent<Rigidbody2D>().velocity, collision.contacts[0].normal * bumperForce));
            Debug.Log("Ball is reflected");
            if (bumperHealth > 1)
            {
                bumperHealth--;
                GetComponent<SpriteRenderer>().sprite = bumpSprite;
                Debug.Log("bumper sprite change");
            }
            else
            {
                parent.parentCounter--;
                Destroy(gameObject);
                Debug.Log("bumper is destroy");
            }
        }
    }
}
