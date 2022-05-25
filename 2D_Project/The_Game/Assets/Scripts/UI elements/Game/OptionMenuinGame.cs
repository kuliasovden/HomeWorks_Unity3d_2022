using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenuinGame : MonoBehaviour
{
    [SerializeField] private Button _backButton;
    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private Toggle _soundToggle;
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] private SFXType _sfx;


    // Start is called before the first frame update
    private void Start()
    {
        _backButton.onClick.AddListener(OnBackButtonClickHandler);
        _musicToggle.onValueChanged.AddListener(OnMusicToggleValuChangeHandler);
        _soundToggle.onValueChanged.AddListener(OnSoundToggleValuChangeHandler);
    }


    private void OnBackButtonClickHandler()
    {
        PlaySFX();
        Hide();
        _pauseMenu.SetActive(true);
        Debug.Log("Back");
    }

    private void OnMusicToggleValuChangeHandler(bool isOn)
    {
        Debug.Log("Presd");
    }

    private void OnSoundToggleValuChangeHandler(bool isOn)
    {
        Debug.Log("Presd");
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
