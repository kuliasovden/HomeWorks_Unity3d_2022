using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options_Menu : MonoBehaviour
{
    [SerializeField] private Button _creditButton;
    [SerializeField] private Button _cinematicButton;

    [SerializeField] private Toggle _fullscreenToggle;
    [SerializeField] private Toggle _soundInBackgroundToggle;
    [SerializeField] private Toggle _enableToggle;
    [SerializeField] private Toggle _allowToggle;

    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;

    [SerializeField] private Dropdown _resolutionDropdown;
    [SerializeField] private Dropdown _qualityDropdown;

    // Start is called before the first frame update
    void Start()
    {
        _creditButton.onClick.AddListener(OnCreditButtonClickHandler);
        _cinematicButton.onClick.AddListener(OnCinematicButtonClickHandler);

        _fullscreenToggle.onValueChanged.AddListener(OnFullscrinToggleValueChangeHandler);
        _soundInBackgroundToggle.onValueChanged.AddListener(OnSoundInBackgroundToggleValueChangeHandler);
        _enableToggle.onValueChanged.AddListener(OnEnableToggleValueChangeHandler);
        _allowToggle.onValueChanged.AddListener(OnAllowToggleValueChangeHandler);

        _masterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeSliderValueChangeHandler);
        _musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeSliderValueChangeHandler);

        //Очистка списка
        _resolutionDropdown.options.Clear();
        //Составление списка
        List<string> resolution = new List<string>();
        resolution.Add("640x480");
        resolution.Add("800x600");
        resolution.Add("1600x1200");
        //Заполнение списка
        foreach (var item in resolution)
        {
            _resolutionDropdown.options.Add(new Dropdown.OptionData() { text = item });
        }
        _resolutionDropdown.onValueChanged.AddListener(OnResolutionDropdownHandler);

        //Очистка списка
        _qualityDropdown.options.Clear();
        //Составление списка
        List<string> quality = new List<string>();
        quality.Add("Low");
        quality.Add("Medium");
        quality.Add("High");
        //Заполнение списка
        foreach (var item in quality)
        {
            _qualityDropdown.options.Add(new Dropdown.OptionData() { text = item });
        }
        _qualityDropdown.onValueChanged.AddListener(OnQualityDropdownHandler);
    }

    //Кнока-----------------------------------------------------------------------------------
    private void OnCreditButtonClickHandler()
    {
        Debug.Log("[OnCreditButtonClickhandler] OK");
    }
    private void OnCinematicButtonClickHandler()
    {
        Debug.Log("[OnCinematicButtonClickhandler] OK");
    }

    //Чекбокс----------------------------------------------------------------------------------
    private void OnFullscrinToggleValueChangeHandler(bool isOn)
    {
        Debug.Log($"[OnFullscrinToggleValueChange] OK, isOn : {isOn}");
    }
    private void OnSoundInBackgroundToggleValueChangeHandler(bool isOn)
    {
        Debug.Log($"[OnSoundInBackgroundToggleValueChangeHandler] OK, isOn : {isOn}");
    }
    private void OnEnableToggleValueChangeHandler(bool isOn)
    {
        Debug.Log($"[OnEnableToggleValueChangeHandler] OK, isOn : {isOn}");
    }
    private void OnAllowToggleValueChangeHandler(bool isOn)
    {
        Debug.Log($"[OnAllowToggleValueChangeHandler] OK, isOn : {isOn}");
    }

    //Слайдер-------------------------------------------------------------------------------------
    private void OnMasterVolumeSliderValueChangeHandler(float value)
    {
        Debug.Log($"[OnMasterVolumeSliderValueChangeHandler] OK, value : {value}"); 
    }
    private void OnMusicVolumeSliderValueChangeHandler(float value)
    {
        Debug.Log($"[OnMusicVolumeSliderValueChangeHandler] OK, value : {value}"); 
    }

    //Выпадающий список----------------------------------------------------------------------------

    private void OnResolutionDropdownHandler(int value)
    {
        Debug.Log($"You selected:  { _resolutionDropdown.options[_resolutionDropdown.value].text} resolution!");
    }

    private void OnQualityDropdownHandler(int value)
    {
        Debug.Log($"You selected:  { _qualityDropdown.options[_qualityDropdown.value].text} quality!");
    }
}
