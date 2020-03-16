using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentBumber_function : MonoBehaviour
{
    [SerializeField] public List<GameObject> bumbers;

    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        if (bumbers == null || bumbers.Count == 0)
        {
            bumbers = new List<GameObject>();
            foreach (GameObject BB in GameObject.FindGameObjectsWithTag("Bumper"))
            {
                bumbers.Add(BB);
            }
        }
    }

    void Update()
    {
        //Debug.Log("objects in list is " + bumbers.Count);

        if(bumbers.Count == 0 /*&& bumpers ==null*/)
        {
            Destroy(gameObject);
            gameController.pbInScene = false;
        } 
    }
}
