using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    [SerializeField] Button _exitButton; 
    [SerializeField] private SFXType _sfx;

    // Start is called before the first frame update
    void Start()
    {
        _exitButton.onClick.AddListener(OnExitButtonClickHandler);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnExitButtonClickHandler()
    {
        PlaySFX();
        Hide();
        SceneManager.LoadScene("MaineMenu");
        Time.timeScale = 1f;
        Debug.Log("Yes");
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
