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
        levels = DatabaseManager.Instance.GetLevels();
        backButton.style.backgroundImage = new StyleBackground(backSprite);
        if(GameManager.instance.levels.Count == 0) GameManager.instance.levels = levels;
        for (int i = 0; i < levels.Count ; i++)
        {
            Button button = new Button();
            button.AddToClassList("level_button");
            if (!levels[i].IsUnlocked) button.AddToClassList("level_button_locked");
            button.text = levels[i].Id.ToString(); 
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
        if (!level.IsUnlocked) return;
        GameManager.instance.SetCurrentLevelId(level.Id);
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
