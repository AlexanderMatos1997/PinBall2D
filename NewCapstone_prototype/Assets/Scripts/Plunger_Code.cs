using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plunger_Code : MonoBehaviour
{
    float power;
    public float minPower = 0f;
    public float maxPower;
    public Slider powerSlider;
    public GameObject ballPrefab;
    public GameObject ballLaunch;
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        powerSlider.minValue = minPower;
        powerSlider.maxValue = maxPower;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameController.inPlay)
        {
            powerSlider.gameObject.SetActive(true);

            //BallLaunch();
        }
        else
        {
            powerSlider.gameObject.SetActive(false);
            power = 0f;
        }

        powerSlider.value = power;

        if (Input.GetKey(KeyCode.Space))
        {
            if (power <= maxPower)
            {
                power += 45 * Time.deltaTime;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject ballRB = Instantiate(ballPrefab, ballLaunch.transform.position, ballLaunch.transform.rotation);
            ballRB.GetComponent<Rigidbody2D>().AddForce(power * Vector2.up);
            gameController.inPlay = true;
        }
    }
    //void BallLaunch()
    //{
    //    if (Input.GetKey(KeyCode.Space))
    //    {
    //        if (power <= maxPower)
    //        {
    //            power += 45 * Time.deltaTime;
    //        }
    //    }
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        GameObject ballRB = Instantiate(ballPrefab, ballLaunch.transform.position, ballLaunch.transform.rotation);
    //        ballRB.GetComponent<Rigidbody2D>().AddForce(power * Vector2.up);
    //        gameController.inPlay = true;
    //    }
    //}
}
