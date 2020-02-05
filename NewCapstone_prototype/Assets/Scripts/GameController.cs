using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject ballSA;
    public GameObject parentBumberOb;

    public GameObject bumberSP;

    public bool inPlay;

    public bool pbInScene;

    // Start is called before the first frame update
    void Start()
    {
        inPlay = false;
        pbInScene = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pbInScene)
        {
            SpawnBumberPrefab();
        }
    }
    void SpawnBall()
    {
        Instantiate(ballPrefab, ballSA.transform.position, ballSA.transform.rotation);
        inPlay = true;
    }

    void SpawnBumberPrefab()
    {
        Instantiate(parentBumberOb, bumberSP.transform.position, bumberSP.transform.rotation);
        pbInScene = true;
    }
}
