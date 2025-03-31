using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuEventHandler : MonoBehaviour
{
    UIDocument uIDocument;
    Button startButton;
    Button settingsButton;

    private void Awake() {
        uIDocument = GetComponent<UIDocument>();
        startButton = uIDocument.rootVisualElement.Q<Button>(GlobalConfig.START_BUTTON_NAME);
        settingsButton = uIDocument.rootVisualElement.Q<Button>(GlobalConfig.SETTINGS_BUTTON_NAME);
        startButton.RegisterCallback<ClickEvent>(OnStartGameButtonClicked);
        settingsButton.RegisterCallback<ClickEvent>(OnSettingsButtonClicked);
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
        Debug.Log("Settings button clicked");
    }
}
