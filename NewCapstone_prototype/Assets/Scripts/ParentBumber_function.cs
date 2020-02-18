using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentBumber_function : MonoBehaviour
{
    [SerializeField] public List<GameObject> bumpers = new List<GameObject>();

    public GameController gameController;

    public int parentCounter;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        //BumberList();

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

        if(parentCounter == 0)
        {
            Destroy(gameObject);
            gameController.pbInScene = false;
        }  
    }
}
