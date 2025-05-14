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

    private void Awake()
    {
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
        PlayerPrefs.SetFloat(GlobalConfig.MUSIC_VOLUME_PREFS_KEY, musicVolumeSlider.value);
        PlayerPrefs.SetFloat(GlobalConfig.SOUND_VOLUME_PREFS_KEY, soundVolumeSlider.value);
        PlayerPrefs.Save();
    }

    private void Start()
    {
        if(!AudioManager.instance.IsMusicPlaying()) AudioManager.instance.PlayMusic(AudioManager.instance.mainMenuMusic);
        if (PlayerPrefs.HasKey(GlobalConfig.MUSIC_VOLUME_PREFS_KEY))
        {
            musicVolumeSlider.value = PlayerPrefs.GetFloat(GlobalConfig.MUSIC_VOLUME_PREFS_KEY);
        }
        else
        {
            musicVolumeSlider.value = AudioManager.instance.musicSource.volume;
        }
        if (PlayerPrefs.HasKey(GlobalConfig.SOUND_VOLUME_PREFS_KEY))
        {
            soundVolumeSlider.value = PlayerPrefs.GetFloat(GlobalConfig.SOUND_VOLUME_PREFS_KEY);
        }
        else
        {
            soundVolumeSlider.value = AudioManager.instance.SFXsource.volume;
        }
    }

    private void OnDisable()
    {
        startButton.UnregisterCallback<ClickEvent>(OnStartGameButtonClicked);
        settingsButton.UnregisterCallback<ClickEvent>(OnSettingsButtonClicked);
        closePopupButton.UnregisterCallback<ClickEvent>(OnClosePopupButtonClicked);
        musicVolumeSlider.UnregisterValueChangedCallback(OnMusicVolumeSliderValueChanged);
        soundVolumeSlider.UnregisterValueChangedCallback(OnSoundVolumeSliderValueChanged);
    }

    void OnStartGameButtonClicked(ClickEvent click)
    {
        AudioManager.instance.PlaySound(AudioManager.instance.buttonClickedSound);
        SceneManager.LoadScene(GlobalConfig.LEVEL_SCENE_BUILD_INDEX);
    }

    void OnSettingsButtonClicked(ClickEvent click)
    {
        AudioManager.instance.PlaySound(AudioManager.instance.buttonClickedSound);
        popupSettings.RemoveFromClassList("hidden");
    }
}
