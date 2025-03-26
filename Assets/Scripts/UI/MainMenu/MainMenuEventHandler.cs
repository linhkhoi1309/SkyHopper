using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuEventHandler : MonoBehaviour
{
    UIDocument uIDocument;
    Button startButton;

    private void Awake() {
        uIDocument = GetComponent<UIDocument>();
        startButton = uIDocument.rootVisualElement.Q<Button>(GlobalConfig.START_BUTTON_NAME);
        startButton.RegisterCallback<ClickEvent>(OnStartGameButtonClicked);
    }

    private void OnDisable() {
        startButton.UnregisterCallback<ClickEvent>(OnStartGameButtonClicked);
    }

    void OnStartGameButtonClicked(ClickEvent click){
        SceneManager.LoadScene(GlobalConfig.LEVEL_SCENE_BUILD_INDEX);
    }
}
