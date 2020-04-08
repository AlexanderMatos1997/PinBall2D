using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private GameObject playButton;

    // Start is called before the first frame update
    private void Start()
    {
        //Button playButton = GameObject.FindGameObjectWithTag("Play").GetComponent<Button>();
        //playButton.onClick.AddListener(GameManager.)
    }
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else { Destroy(gameObject); return; }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
