using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpScore : MonoBehaviour
{
    [SerializeField] private bool isActivated;
    public Sprite SpriteActive;
    public Sprite SpriteDeactive;
    public AudioSource audioSFX;
    public GameController gc;

    public bool IsActive
    {
        get
        {
            return isActivated;
        }
        set { if (value) {
                //gameObject.GetComponent<SpriteRenderer>().color = new Color(15f, 64f, 113f);
                gameObject.GetComponent<SpriteRenderer>().sprite = SpriteActive;
                //Debug.Log("Ball is detected");
                audioSFX.Play();
                isActivated = true;
            }
            else
            {
                //gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 128f, 255f);
                gameObject.GetComponent<SpriteRenderer>().sprite = SpriteDeactive;
                isActivated = false;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSFX = gameObject.GetComponent<AudioSource>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Ball")) {
            if (!gc.multiBallIP)
            {
                if (!IsActive)
                {
                    IsActive = true;

                }
                else
                {
                    IsActive = false;
                }
            }
            /*
            if (!IsActive) {
                IsActive = true;

            }
            else {
                IsActive = false;
            }*/
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
