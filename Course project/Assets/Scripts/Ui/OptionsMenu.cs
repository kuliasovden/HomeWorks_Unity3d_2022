using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class OptionsMenu : MonoBehaviour
{
    [SerializeField]private AudioMixer _mainMixer;

    public void PauseButton()
    {
        Time.timeScale = 0;
    }

    public void ReturneButton()
    {
        Time.timeScale = 1;
    }

    public void ReternToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void SetVolume(float volume)
    {
        _mainMixer.SetFloat("Volume", volume);
    }


}
