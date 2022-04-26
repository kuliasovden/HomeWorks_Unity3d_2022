using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    public Button startButton;
    public Button optionsButton;
    public Button exitButton;
    public Button yesButton;
    public Button noButton;
    public GameObject maineMenu;
    public GameObject optionsMenu;
    public GameObject exitMenu;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        maineMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Exit()
    {
        maineMenu.SetActive(false);
        exitMenu.SetActive(true);
    }

    public void BackToMaineMenu()
    {
        maineMenu.SetActive(true);
        optionsMenu.SetActive(false);
        exitMenu.SetActive(false);
    }


    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
