using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentBumber_function : MonoBehaviour
{
    [SerializeField] public List<GameObject> bumpers;

    public GameController gameController;

    public int parentCounter;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameController is found");
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        //BumberList();
        if (bumpers == null || bumpers.Count == 0)
        {
            bumpers = new List<GameObject>();
            Debug.Log("bumpers has a new list");
            foreach (GameObject BB in GameObject.FindGameObjectsWithTag("Bumper"))
            {
                bumpers.Add(BB);
                //gameController.pbInScene = true;
                Debug.Log("Bumpers are added to the list");
            }
        }
    }

    //private void Awake()
    //{
    //    if (bumpers == null)
    //    {
    //        bumpers = new List<GameObject>();
    //        foreach (GameObject BB in GameObject.FindGameObjectsWithTag("Bumper"))
    //        {
    //            bumpers.Add(BB);
    //        }
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("objects in list is " + bumbers.Count);

        if(bumpers.Count == 0)
        {
            Destroy(gameObject);
            gameController.pbInScene = false;
        } 
    }
}
