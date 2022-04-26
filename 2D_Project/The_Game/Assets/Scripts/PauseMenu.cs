using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Button continyeButton;
    public Button optionsButton;
    public Button exitButton;
    public Button yesButton;
    public Button noButton;
    public Button returnButton;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject exitMenu;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
    }


    public void BackToGame()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        exitMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Options()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Exit()
    {
        pauseMenu.SetActive(false);
        exitMenu.SetActive(true);
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
    public void BackToPauseMenu()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
        exitMenu.SetActive(false);
    }

    public void Pause()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
