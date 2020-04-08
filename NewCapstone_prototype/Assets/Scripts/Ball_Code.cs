using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Code : MonoBehaviour
{
    public GameController gc;
    AudioSource ballCollision;

    public GameObject ballShatter;
    private GameObject instantBall;

    public GameObject ballFlash;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        ballCollision = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ballCollision.Play();

        if (collision.gameObject.CompareTag("KillBox"))
        {
            instantBall = Instantiate(ballShatter, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(instantBall, 1f);

            GameObject ballLE = Instantiate(ballFlash, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(ballLE, .25f);

            foreach(GameObject PBs in gc.Pinballs)
            {
                if (PBs == gameObject)
                {
                    gc.Pinballs.Remove(gameObject);
                    Destroy(gameObject);
                    break;
                }
            }
            if(gc.Pinballs.Count == 0)
            {
                gc.UpdateLives(1);
                gc.inPlay = false;
                if(gc.lives > 0)
                {
                    StartCoroutine(messageBallDestroyed());
                }
            }
        }
    }

    IEnumerator messageBallDestroyed()
    {
        gc.messageText.text = ("Ball Destroyed");
        yield return new WaitForSeconds(2);
        gc.messageText.text = (" ");
    }
}
