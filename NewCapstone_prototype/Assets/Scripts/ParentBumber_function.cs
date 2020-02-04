using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentBumber_function : MonoBehaviour
{
    [SerializeField] private List<GameObject> bumbers = new List<GameObject>();

    public GameController gameController;

    public int parentCounter;

    public List<GameObject> myList
    {
        get
        {
            return bumbers;
        }
        set
        {

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        //BumberList();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("objects in list is " + bumbers.Count);

        if(parentCounter == 0)
        {
            Destroy(gameObject);
        }  
    }
}
