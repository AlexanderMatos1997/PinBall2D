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
        //for (int i = 0; i < a.Length; i++)
        //{
        //    print(a[i].GetComponent<LightUpScore>().IsActive);
        //    if (!a[i].GetComponent<LightUpScore>().IsActive)
        //    {
        //        //Debug.Log("Score is currently disabled");
        //        //allTrue = true;
        //    }
        //    else
        //    {
        //        
        //        //a[i].GetComponent<LightUpScore>().isActive = false
        //        Debug.Log("Score is currently active");
        //    }
        //}
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
            foreach(GameObject go in a)
            {
                go.GetComponent<LightUpScore>().IsActive = false;
                
            }

            Debug.Log("areallActive is set to true");
        }
    }
}
