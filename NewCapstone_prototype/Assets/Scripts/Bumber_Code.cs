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
    public float bumperForce;
    public int bumperHealth;
    public Sprite bumpSprite;

    public int pointsAdded;

    public void Awake()
    {
        parent = GetComponentInParent<ParentBumber_function>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ball")) {
            GameObject ballRB = collision.gameObject;
            /* This is the first time using Vector2.Reflect, but to have a better undertsanding the ballRB.GetComponent<Rigidbody2D>().velocity
               represents the velocity of the ball of the ball, while collision.contacts[0].normal is the point at which the ball hits the object that
               script is attach to. AddForce(Vector2.Reflect()) takes the velocity value and the point the ball collided with the object and "reflects"
               the ball object to the other direction. bumperForce basically adds to the velocity of the ball.
             */
            ballRB.GetComponent<Rigidbody2D>().AddForce(Vector2.Reflect(ballRB.GetComponent<Rigidbody2D>().velocity, collision.contacts[0].normal * bumperForce));
            bumperHealth--;

            //Debug.Log("Ball is reflected");
            if (bumperHealth > 0) {
                if(bumperHealth == 3) {
                    animator.SetBool("Full_Health state 1", true);

                    //Debug.Log("Full_Health state 1 is true");
                }
                else if(bumperHealth == 2) {
                    animator.SetBool("Half-Damage state 0", true);
                    animator.SetBool("Full_Health state 1", false);
                    pointsAdded = 100;
                    gc.UpdateScore(pointsAdded);

                }
                else if (bumperHealth == 1) {
                    animator.SetBool("OneFourth-Damage state", true);
                    animator.SetBool("Half-Damage state 0", false);
                    pointsAdded = 50;
                    gc.UpdateScore(pointsAdded);

                }
            }
            else {
                pointsAdded = 10;
                gc.UpdateScore(pointsAdded);
                animator.SetBool("Destroy bumper", true);
                animator.SetBool("OneFourth-Damage state", false);
                //animator.SetBool("OneFourth-Damage state", false);
                parent.parentCounter--;
                Destroy(gameObject);
                //Debug.Log("bumper is destroy");
            }
        }
    }
}
