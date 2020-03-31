using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Code : MonoBehaviour
{
    public GameController gc;
    AudioSource ballCollision;

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
            foreach(GameObject PBs in gc.Pinballs)
            {
                if (PBs == gameObject)
                {
                    gc.Pinballs.Remove(gameObject);
                    Destroy(gameObject);
                    //Debug.Log("Pinball removed from List");
                    break;
                }
            }
            if(gc.Pinballs.Count == 0)
            {
                gc.UpdateLives(1);
                gc.inPlay = false;
                //Debug.Log("All pinballs are gone");
                //gc.UpdateLives(1);
                //Debug.Log("New round has started");
            }
        }
    }
}
