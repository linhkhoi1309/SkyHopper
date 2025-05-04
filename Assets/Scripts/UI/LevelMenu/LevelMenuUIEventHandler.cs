using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LevelMenuUIEventHandler : MonoBehaviour
{
    UIDocument uIDocument;
    ScrollView scrollView;

    Button backButton;

    List<Level> levels = new List<Level>();

    [SerializeField] Sprite backSprite;

    private void Awake()
    {
        uIDocument = GetComponent<UIDocument>();
        scrollView = uIDocument.rootVisualElement.Q<ScrollView>(className: "level_scroll_view");
        backButton = uIDocument.rootVisualElement.Q<Button>(className: "level_back_button");
        backButton.RegisterCallback<ClickEvent>(OnBackButtonClicked);
    }

    private void Start()
    {
        backButton.style.backgroundImage = new StyleBackground(backSprite);
        
        levels = DatabaseManager.Instance.GetLevels();
        for (int i = 0; i < levels.Count ; i++)
        {
            Button button = new Button();
            button.AddToClassList("level_button");
            if (!levels[i].IsCompleted) button.AddToClassList("level_button_locked");
            button.text = levels[i].LevelName; 
            scrollView.Add(button);
            button.RegisterCallback<ClickEvent, Level>(OnLevelButtonClicked, levels[i]);
        }
    }

    private void OnBackButtonClicked(ClickEvent evt)
    {
        AudioManager.instance.PlaySound(AudioManager.instance.buttonClickedSound);
        SceneManager.LoadScene(0);
    }

    private void OnLevelButtonClicked(ClickEvent evt, Level level)
    {
        if (!level.IsCompleted) return;
        AudioManager.instance.PlaySound(AudioManager.instance.buttonClickedSound);
        SceneManager.LoadScene(level.LevelSceneBuildIndex);
    }

    private void OnDisable() {
        backButton.UnregisterCallback<ClickEvent>(OnBackButtonClicked);
        List<Button> levelButtons = new List<Button>();
        scrollView.Query<Button>(className: "level_button").ToList(levelButtons);
        for (int i = 0; i < levelButtons.Count; i++)
        {
            levelButtons[i].UnregisterCallback<ClickEvent, Level>(OnLevelButtonClicked);
        }
    }
}
