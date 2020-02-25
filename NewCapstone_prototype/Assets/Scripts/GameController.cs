using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public List<GameObject> Pinballs;

    public GameObject[] bumperRandomizer;
    int randomInteger;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text livesText;
    [SerializeField] private int score;
    /*[SerializeField]*/ private int lives = 3;

    [SerializeField] private GameObject gameOverPanel;

    public GameObject ballPrefab;
    public GameObject ballSA;
    public GameObject parentBumberOb;
    public GameObject MultiBallSP;

    public GameObject bumperSP;

    public bool inPlay;
    //public bool gameOverBool;
    public bool pbInScene;

    // Start is called before the first frame update
    void Start()
    {
        inPlay = false;
        pbInScene = false;
        //gameOverBool = false;

        gameOverPanel.SetActive(false);

        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pbInScene)
        {
            //SpawnBumberPrefab();
            BumperRandom();
        }

        Pinballs = new List<GameObject>();
        Debug.Log("Pinballs list created");
        foreach(GameObject PBs in GameObject.FindGameObjectsWithTag("Ball"))
        {
            Pinballs.Add(PBs);
            Debug.Log("Ball object added to Pinballs list");
        }
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int lifeLost)
    {
        lives -= lifeLost;

        if(lives == 0)
        {
            GameOver();
        }
        livesText.text = "Lives: " + lives;
    }

    void SpawnBall()
    {
        Instantiate(ballPrefab, ballSA.transform.position, ballSA.transform.rotation);
        inPlay = true;
    }

    void SpawnBumberPrefab()
    {
        Instantiate(parentBumberOb, bumperSP.transform.position, bumperSP.transform.rotation);
        pbInScene = true;
    }

    public void ActivateMultiBall()
    {
        StartCoroutine(MultiBallSpawn());
    }

    IEnumerator MultiBallSpawn()
    {
        Instantiate(ballPrefab, MultiBallSP.transform.position, MultiBallSP.transform.rotation);
        yield return new WaitForSeconds(2);
        Instantiate(ballPrefab, MultiBallSP.transform.position, MultiBallSP.transform.rotation);
    }

    void BumperRandom()
    {
        randomInteger = Random.Range(0, bumperRandomizer.Length);
        Instantiate(bumperRandomizer[randomInteger], bumperSP.transform.position, bumperSP.transform.rotation);
        pbInScene = true;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
