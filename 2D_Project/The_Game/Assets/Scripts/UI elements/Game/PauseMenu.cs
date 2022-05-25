using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _optionstButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] GameObject _optionsMenu;
    [SerializeField] GameObject _exitMenu;
    [SerializeField] private SFXType _sfx;

    // Start is called before the first frame update
    void Start()
    {
        _resumeButton.onClick.AddListener(OnResumeButtonClickHandler);
        _optionstButton.onClick.AddListener(OnOptionsButtonClickHandler);
        _exitButton.onClick.AddListener(OnExitButtonClickHandler);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnResumeButtonClickHandler()
    {
        PlaySFX();
        Hide();
        Time.timeScale = 1f; ;
        Debug.Log("Resume");
    }


    private void OnOptionsButtonClickHandler()
    {
        PlaySFX();
        Hide();
        _optionsMenu.SetActive(true);
        Debug.Log("Options");
    }
    private void OnExitButtonClickHandler()
    {
        PlaySFX();
        Hide();
        _exitMenu.SetActive(true);
        Debug.Log("Exit");
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
