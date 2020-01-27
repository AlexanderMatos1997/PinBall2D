using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject ballSA;

    public bool inPlay;

    // Start is called before the first frame update
    void Start()
    {
        inPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!inPlay)
        //{
        //    //SpawnBall();
        //}
    }
    void SpawnBall()
    {
        Instantiate(ballPrefab, ballSA.transform.position, ballSA.transform.rotation);
        inPlay = true;
    }
}
