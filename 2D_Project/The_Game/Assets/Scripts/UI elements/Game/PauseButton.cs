using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] private SFXType _sfx;

    // Start is called before the first frame update
    private void Start()
    {
        _pauseButton.onClick.AddListener(OnPauseButtonClickHandler);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    private void OnPauseButtonClickHandler()
    {
        PlaySFX();
        Time.timeScale = 0;
        _pauseMenu.SetActive(true);
        Debug.Log("Pause");
    }

    private void PlaySFX()
    {
        SoundManager.PlaySFX(_sfx);
    }
}
