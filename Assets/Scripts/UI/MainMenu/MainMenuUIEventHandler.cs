using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuUIEventHandler : MonoBehaviour
{
    UIDocument uIDocument;
    Button startButton;
    Button settingsButton;

    Button closePopupButton;

    VisualElement popupSettings;

    Slider musicVolumeSlider;
    Slider soundVolumeSlider;

    private void Awake() {
        uIDocument = GetComponent<UIDocument>();
        startButton = uIDocument.rootVisualElement.Q<Button>(GlobalConfig.START_BUTTON_NAME);
        settingsButton = uIDocument.rootVisualElement.Q<Button>(GlobalConfig.SETTINGS_BUTTON_NAME);
        closePopupButton = uIDocument.rootVisualElement.Q<Button>(GlobalConfig.POPUP_SETTINGS_CLOSE_BUTTON_NAME);
        popupSettings = uIDocument.rootVisualElement.Q<VisualElement>(GlobalConfig.POPUP_SETTINGS_NAME);
        musicVolumeSlider = uIDocument.rootVisualElement.Q<Slider>(GlobalConfig.MUSIC_VOLUME_SLIDER_NAME);
        soundVolumeSlider = uIDocument.rootVisualElement.Q<Slider>(GlobalConfig.SOUND_VOLUME_SLIDER_NAME);
        startButton.RegisterCallback<ClickEvent>(OnStartGameButtonClicked);
        settingsButton.RegisterCallback<ClickEvent>(OnSettingsButtonClicked);
        closePopupButton.RegisterCallback<ClickEvent>(OnClosePopupButtonClicked);
        musicVolumeSlider.RegisterValueChangedCallback(OnMusicVolumeSliderValueChanged);
        soundVolumeSlider.RegisterValueChangedCallback(OnSoundVolumeSliderValueChanged);
    }

    private void OnSoundVolumeSliderValueChanged(ChangeEvent<float> evt)
    {
        AudioManager.instance.SetSfxVolume(evt.newValue);
    }

    private void OnMusicVolumeSliderValueChanged(ChangeEvent<float> evt)
    {
        AudioManager.instance.SetMusicVolume(evt.newValue);
    }

    private void OnClosePopupButtonClicked(ClickEvent evt)
    {
        AudioManager.instance.PlaySound(AudioManager.instance.buttonClickedSound);
        popupSettings.AddToClassList("hidden");
    }

    private void Start() {
        AudioManager.instance.PlayMusic(AudioManager.instance.mainMenuMusic);
        musicVolumeSlider.value = AudioManager.instance.musicSource.volume;
        soundVolumeSlider.value = AudioManager.instance.SFXsource.volume;
    }

    private void OnDisable() {
        startButton.UnregisterCallback<ClickEvent>(OnStartGameButtonClicked);
        settingsButton.UnregisterCallback<ClickEvent>(OnSettingsButtonClicked);
    }

    void OnStartGameButtonClicked(ClickEvent click){
        AudioManager.instance.PlaySound(AudioManager.instance.buttonClickedSound);
        SceneManager.LoadScene(GlobalConfig.LEVEL_SCENE_BUILD_INDEX);
    }

    void OnSettingsButtonClicked(ClickEvent click){
        AudioManager.instance.PlaySound(AudioManager.instance.buttonClickedSound);
        popupSettings.RemoveFromClassList("hidden");
    }
}
