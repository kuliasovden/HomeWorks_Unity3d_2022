using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitManu : MonoBehaviour
{
    [SerializeField] GameObject _mainMenu;
    [SerializeField] Button _yesButton;
    [SerializeField] Button _noButton;
    [SerializeField] private SFXType _sfx;

    // Start is called before the first frame update
    void Start()
    {
        _yesButton.onClick.AddListener(OnYesButtonClickHandler);
        _noButton.onClick.AddListener(OnNoButtonClickHandler);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnYesButtonClickHandler()
    {
        PlaySFX();
        Hide();
        Application.Quit();
        Debug.Log("Yes");
    }

    private void OnNoButtonClickHandler()
    {
        PlaySFX();
        Hide();
        _mainMenu.SetActive(true);
        Debug.Log("No");
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
