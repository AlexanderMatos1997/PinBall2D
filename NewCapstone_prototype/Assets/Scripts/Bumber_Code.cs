using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumber_Code : MonoBehaviour
{
    [SerializeField]
    public ParentBumber_function parent;
    Animator animator;
    GameController gc;

    //public int points;
    private float bumberForce = 1.5f;
    private byte bumberHealth = 3;
    //public Sprite bumpSprite;
    private SpriteRenderer rend;
    public ParticleSystem bbParticle;
    public Material redShatter, blueShatter, greenShatter;
    public Sprite fullHealth, halfHealth, tfHealth;

    private int pointsAdded;

    void Start()
    {
        parent = GetComponentInParent<ParentBumber_function>();
        rend = GetComponent<SpriteRenderer>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        animator = GetComponent<Animator>();
        animator.SetBool("Full_Health state", true);
        //animator.SetBool("Destroy bumper", false);

    }

    void Update()
    {
        BumberChangeSprite();

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ball")) {
            GameObject ballRB = collision.gameObject;
            /* This is the first time using Vector2.Reflect, but to have a better undertsanding the ballRB.GetComponent<Rigidbody2D>().velocity
               represents the velocity of the ball of the ball, while collision.contacts[0].normal is the point at which the ball hits the object that
               script is attach to. AddForce(Vector2.Reflect()) takes the velocity value and the point the ball collided with the object and "reflects"
               the ball object to the other direction. bumperForce basically adds to the velocity of the ball.
             */
            ballRB.GetComponent<Rigidbody2D>().AddForce(Vector2.Reflect(ballRB.GetComponent<Rigidbody2D>().velocity, collision.contacts[0].normal * bumberForce));
            //CreateParticle();
            //BumberHealthCheck();
            //bumberHealth--;

            //Debug.Log("Ball is reflected");
            
            if (bumberHealth > 0) {
                if(bumberHealth == 3) {
                    //animator.SetBool("Full_Health state 1", true);
                    animator.SetBool("Half-Damage state", true);
                    animator.SetBool("Full_Health state", false);
                    pointsAdded = 100;
                    gc.UpdateScore(pointsAdded);
                    bumberHealth--;
                    //Debug.Log("Full_Health state 1 is true");
                }
                else if(bumberHealth == 2) {
                    animator.SetBool("25-Damage state", true);
                    animator.SetBool("Half-Damage state", false);
                    pointsAdded = 50;
                    gc.UpdateScore(pointsAdded);
                    bumberHealth--;

                }
                else if (bumberHealth == 1) {
                    //animator.SetBool("OneFourth-Damage state", true);
                    //animator.SetBool("Half-Damage state 0", false);
                    //pointsAdded = 50;
                    //animator.SetBool("Destroy bumper", true);
                    animator.SetBool("25-Damage state", false);
                    animator.SetBool("Destroyed", true);
                    pointsAdded = 10;
                    gc.UpdateScore(pointsAdded);
                    bumberHealth--;

                }
            }
            else {
                //pointsAdded = 10;
                //gc.UpdateScore(pointsAdded);
                //animator.SetBool("Destroy bumper", true);
                //animator.SetBool("OneFourth-Damage state", false);
                //animator.SetBool("OneFourth-Damage state", false);
                //parent.bumpers.Remove(gameObject);
                //Destroy(gameObject);
                //Debug.Log("bumper is destroy");
            }
        }
    }

    public void BumberChangeSprite()
    {
        if (animator.GetBool("Full_Health state") == true)
        {
            rend.sprite = fullHealth;
        }

        if (animator.GetBool("Half-Damage state") == true)
        {
            rend.sprite = halfHealth;
        }

        if (animator.GetBool("25-Damage state") == true)
        {
            rend.sprite = tfHealth;
        }

        if (animator.GetBool("Destroyed") == true)
        {
            parent.bumbers.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    void CreateParticle()
    {
        if(bumberHealth == 3)
        {
            bbParticle.GetComponent<ParticleSystemRenderer>().material = redShatter;
        }
        bbParticle.Play();
    }
}
