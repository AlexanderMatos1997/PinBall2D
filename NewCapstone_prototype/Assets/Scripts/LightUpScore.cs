﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpScore : MonoBehaviour
{
    [SerializeField] private bool isActivated;

    public bool IsActive
    {
        get
        {
            return isActivated;
        }
        set { if (value) {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(15f, 64f, 113f);
                //Debug.Log("Ball is detected");
                isActivated = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 128f, 255f);
                isActivated = false;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (!IsActive)
            {
                //gameObject.GetComponent<SpriteRenderer>().color = new Color(15f, 64f, 113f);
                ////Debug.Log("Ball is detected");
                //isActivated = true;
                IsActive = true;
            }
            else
            {
                //gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 128f, 255f);
                //isActivated = false;
                IsActive = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
