using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetterActive : MonoBehaviour
{
    GameObject[] a;

    GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        a = GameObject.FindGameObjectsWithTag("ScoreLight");
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        //gc = GameObject.FindGameObjectWithTag("")
    }

    // Update is called once per frame
    void Update()
    {
        bool areallActive = true;

        foreach(GameObject go in a)
        {
            if (go.GetComponent<LightUpScore>().IsActive == false){
                areallActive = false;
                Debug.Log("areallActive is set to false");
                break;
            }
        }
        if (areallActive)
        {
            gc.ActivateMultiBall();

            foreach (GameObject go in a)
            {
                go.GetComponent<LightUpScore>().IsActive = false;
            }
            Debug.Log("areallActive is set to true");
        }
    }
}
