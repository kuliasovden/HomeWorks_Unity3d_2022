using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _optionstButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] GameObject _optionsMenu;
    [SerializeField] GameObject _quitMenu;
    [SerializeField] private SFXType _sfx;

    // Start is called before the first frame update
    void Start()
    {
        _startButton.onClick.AddListener(OnStarButtonClickHandler);       
        _optionstButton.onClick.AddListener(OnOptionsButtonClickHandler);
        _quitButton.onClick.AddListener(OnQuitButtonClickHandler);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnStarButtonClickHandler()
    {
        PlaySFX();
        Hide();
        SceneManager.LoadScene("Level_1");
        Debug.Log("Start");
    }


    private void OnOptionsButtonClickHandler()
    {
        PlaySFX();       
        Hide();
        _optionsMenu.SetActive(true);
        Debug.Log("Options");
    }
    private void OnQuitButtonClickHandler()
    {
        PlaySFX();
        Hide();
        _quitMenu.SetActive(true);
        Debug.Log("Quit");
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void PlaySFX()
    {
        SoundManager.PlaySFX(_sfx);
    }
}
