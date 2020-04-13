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
    [SerializeField] public Text messageText;
    [SerializeField] private int score;
    [SerializeField] public int lives = 3;
    [SerializeField] private GameObject gameoverButton;
    [SerializeField] private GameObject gameOverPanel;

    //[SerializeField] private GameObject gameOverPanel;
    public Text highScoreText;

    public GameObject ballPrefab;
    public GameObject ballSA;
    public GameObject parentBumberOb;
    public GameObject MultiBallSP;

    public GameObject bumperSP;

    public bool inPlay;
    public bool gameOverBool;
    public bool pbInScene;
    public bool multiBallIP;

    public GameObject ballFlash;

    // Start is called before the first frame update
    void Start()
    {
        inPlay = false;
        pbInScene = false;
        gameOverBool = false;
        gameoverButton.SetActive(false);
        gameOverPanel.SetActive(false);


        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
        messageText.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            PlayerPrefs.DeleteKey("HIGHSCORE");
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            ActivateMultiBall();
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            SceneManager.LoadScene("MainMenu");
        }

        if (!pbInScene)
        {
            //SpawnBumberPrefab();
            BumperRandom();
        }

        if(Pinballs.Count > 1) {
            multiBallIP = true;
        }
        else { multiBallIP = false; }

        Pinballs = new List<GameObject>();
        //Debug.Log("Pinballs list created");
        foreach(GameObject PBs in GameObject.FindGameObjectsWithTag("Ball"))
        {
            Pinballs.Add(PBs);
            //Debug.Log("Ball object added to Pinballs list");
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
        messageText.text = ("Multi-Ball!");
        if(!multiBallIP)
        {
            StartCoroutine(MultiBallSpawn());
        } 
    }

    IEnumerator MultiBallSpawn()
    {
        GameObject multiSFX;

        Instantiate(ballPrefab, MultiBallSP.transform.position, MultiBallSP.transform.rotation);
        multiSFX = Instantiate(ballFlash, MultiBallSP.transform.position, gameObject.transform.rotation);
        Destroy(multiSFX, 0.25f);
        yield return new WaitForSeconds(2);
        Instantiate(ballPrefab, MultiBallSP.transform.position, MultiBallSP.transform.rotation);
        multiSFX = Instantiate(ballFlash, MultiBallSP.transform.position, gameObject.transform.rotation);
        Destroy(multiSFX, 0.25f);
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
        gameoverButton.SetActive(true);
        gameOverBool = true;

        int highScore = PlayerPrefs.GetInt("HIGHSCORE");
        if(score > highScore)
        {
            PlayerPrefs.SetInt("HIGHSCORE", score);

            messageText.text = "Congratulations!" + "\n" + "New High Score!" + "\n" + highScore; ;
        }
        else
        {
            messageText.text = "HighScore is currently: " + highScore + "\n" + "Your score was " + score;
        }
    }
}
