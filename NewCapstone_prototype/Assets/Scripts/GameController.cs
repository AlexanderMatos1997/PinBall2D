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
    [SerializeField] private GameObject playAgainButton;

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

    public GameObject MainCamera;
    public float CameraForce = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        inPlay = false;
        pbInScene = false;
        gameOverBool = false;
        playAgainButton.SetActive(false);


        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
        messageText.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
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

    public void UpdateMessage()
    {

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
        if(!multiBallIP)
        {
            StartCoroutine(MultiBallSpawn());
        } 
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
        playAgainButton.SetActive(true);
        gameOverBool = true;

        int highScore = PlayerPrefs.GetInt("HIGHSCORE");
        if(score > highScore)
        {
            PlayerPrefs.SetInt("HIGHSCORE", score);

            messageText.text = "Congratulations!" + "\n" + "New High Score!" + "\n" + highScore; ;
        }
        else
        {
            messageText.text = "HighScore is currently: " + highScore + "\n" + "Your score was " + (highScore - score) + "\n" + "in beating the previous HighScore.";
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
