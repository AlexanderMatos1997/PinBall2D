using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetterActive : MonoBehaviour
{
    GameObject[] a;

    bool allTrue = true;

    // Start is called before the first frame update
    void Start()
    {
        a = GameObject.FindGameObjectsWithTag("ScoreLight");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < a.Length; i++)
        {
            print(a[i].GetComponent<LightUpScore>().isActive);
            if (!a[i].GetComponent<LightUpScore>().isActive)
            {
                allTrue = true;
            }
            else
            {

            }
        }
    }
}
