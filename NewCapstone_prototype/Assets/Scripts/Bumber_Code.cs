using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumber_Code : MonoBehaviour
{
    [SerializeField]
    public ParentBumber_function parent;
    Animator animator;
    GameController gc;

    Material[] shatterParticle;

    //public int points;
    private float bumberForce = 0.075f;
    private byte bumberHealth = 3;
    public GameObject bumberShatter;
    public GameObject particleScore;
    private SpriteRenderer rend;
    public GameObject score100, score50, score10;
    public GameObject particleShatter;
    public Sprite fullHealth, halfHealth, tfHealth;
    public GameObject bumberLight;
    public GameObject lightSpawn;

    private int pointsAdded;

    void Start()
    {
        parent = GetComponentInParent<ParentBumber_function>();
        rend = GetComponent<SpriteRenderer>();
        //bbParticle = GetComponentInChildren<ParticleSystem>();
       // mrParticle = GetComponentInChildren<ParticleSystemRenderer>();
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

            ballRB.GetComponent<Rigidbody2D>().AddForce(Vector2.Reflect(ballRB.GetComponent<Rigidbody2D>().velocity, collision.contacts[0].normal * bumberForce));
            ShatterParticle();
            ScoreParticle();
            BumberLight();
            
            if (bumberHealth > 0) {
                if(bumberHealth == 3) {
                    //mrParticle.material = new Material(redShatter);
                    //bbParticle.Play();
                    //bumberShatter = Instantiate(redShatter, gameObject.transform.position, gameObject.transform.rotation);
                    //Destroy(bumberShatter, 3.5f);
                    //Destroy(bumberShatter.gameObject, 2.5f);
                    animator.SetBool("Half-Damage state", true);
                    animator.SetBool("Full_Health state", false);
                    pointsAdded = 100;
                    gc.UpdateScore(pointsAdded);
                    bumberHealth--;
                }
                else if(bumberHealth == 2) {
                    //mrParticle.material = new Material(blueShatter);
                    //bbParticle.Play();
                    animator.SetBool("25-Damage state", true);
                    animator.SetBool("Half-Damage state", false);
                    pointsAdded = 50;
                    gc.UpdateScore(pointsAdded);
                    bumberHealth--;

                }
                else if (bumberHealth == 1) {
                    //mrParticle.material = new Material(greenShatter);
                    //bbParticle.Play();
                    animator.SetBool("25-Damage state", false);
                    animator.SetBool("Destroy", true);
                    pointsAdded = 10;
                    gc.UpdateScore(pointsAdded);
                    bumberHealth--;

                }
            }
            else {
                animator.SetBool("Destroy", true);
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

        if (animator.GetBool("Destroy") == true)
        {
            parent.bumbers.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    void ShatterParticle()
    {
        bumberShatter = Instantiate(particleShatter, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(bumberShatter, 3.5f);
    }

    void ScoreParticle()
    {
        if (animator.GetBool("Full_Health state") == true)
        {
            particleScore = Instantiate(score100, gameObject.transform.position, gameObject.transform.rotation);
        }

        if (animator.GetBool("Half-Damage state") == true)
        {
            particleScore = Instantiate(score50, gameObject.transform.position, gameObject.transform.rotation);
        }

        if (animator.GetBool("25-Damage state") == true)
        {
            particleScore = Instantiate(score10, gameObject.transform.position, gameObject.transform.rotation);
        }

        Destroy(particleScore, 3.5f);
    }
     void BumberLight()
    {
        lightSpawn = Instantiate(bumberLight, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(lightSpawn, 0.25f);
    }
}
