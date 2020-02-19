using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Code : MonoBehaviour
{
    public GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("KillBox"))
        {
            gc.inPlay = false;
            Destroy(gameObject);
            gc.UpdateLives(1);
        }
    }
}
