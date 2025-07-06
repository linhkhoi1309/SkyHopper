using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverMenuUIEventHandler : MonoBehaviour
{
    UIDocument uIDocument;
    Button primaryButton;
    VisualElement secondaryButtonIcon;
    VisualElement secondaryButton;
    VisualElement quitButton;
    Level currentLevel;
    Label levelNameLabel;
    Label levelFailedLabel;
    Label levelCompletedLabel;
    AdsManager adsManager;

    [SerializeField] Sprite nextLevelIcon;

    private void Awake()
    {
        uIDocument = GetComponent<UIDocument>();
        adsManager = FindFirstObjectByType<AdsManager>();
    }
    void Start()
    {
        currentLevel = DatabaseManager.Instance.GetLevelById(GameManager.instance.currentLevelId);

        levelNameLabel = uIDocument.rootVisualElement.Q<Label>(name: "game_over_level_name");
        levelFailedLabel = uIDocument.rootVisualElement.Q<Label>(name: "game_over_level_failed");
        levelCompletedLabel = uIDocument.rootVisualElement.Q<Label>(name: "game_over_level_completed");
        primaryButton = uIDocument.rootVisualElement.Q<Button>(name: "game_over_primary_button");
        secondaryButtonIcon = uIDocument.rootVisualElement.Q<VisualElement>(name: "game_over_secondary_button_icon");
        secondaryButton = uIDocument.rootVisualElement.Q<VisualElement>(name: "game_over_secondary_button");
        quitButton = uIDocument.rootVisualElement.Q<VisualElement>(name: "game_over_quit_button");

        primaryButton.RegisterCallback<ClickEvent>(OnPrimaryButtonClicked);
        secondaryButton.RegisterCallback<ClickEvent, bool>(OnSecondaryButtonClicked, currentLevel.IsCompleted);
        quitButton.RegisterCallback<ClickEvent>(OnQuitButtonClicked);

        LocalizeLevelName();
        if (currentLevel.IsCompleted)
        {
            primaryButton.style.display = DisplayStyle.None;
            levelFailedLabel.style.display = DisplayStyle.None;
            secondaryButtonIcon.style.backgroundImage = new StyleBackground(nextLevelIcon);
            secondaryButtonIcon.style.scale = new Scale(new Vector2(1f, 1f));
            secondaryButtonIcon.style.width = new StyleLength(new Length(80, LengthUnit.Pixel));
            secondaryButtonIcon.style.height = new StyleLength(new Length(80, LengthUnit.Pixel));
        }
        else
        {
            levelCompletedLabel.style.display = DisplayStyle.None;
        }
    }

    private void OnEnable()
    {
        adsManager.OnRewardedAdClosedEvent += OnRewardedAdClosed;
    }

    private void OnRewardedAdClosed()
    {
        if (currentLevel.LevelSceneBuildIndex + 1 <= GameManager.instance.levels.Count)
        {
            SceneManager.LoadScene(currentLevel.LevelSceneBuildIndex + 1);
            GameManager.instance.SetCurrentLevelId(currentLevel.Id + 1);
        }
    }

    private void OnQuitButtonClicked(ClickEvent evt)
    {
        AudioManager.instance.PlaySound(AudioManager.instance.buttonClickedSound);
        SceneManager.LoadScene(GlobalConfig.LEVEL_SCENE_BUILD_INDEX);
    }

    private void OnPrimaryButtonClicked(ClickEvent evt)
    {
        AudioManager.instance.PlaySound(AudioManager.instance.buttonClickedSound);
        if (currentLevel.LevelSceneBuildIndex + 1 <= GameManager.instance.levels.Count){
            adsManager.ShowRewardedAd();
        }
    }
    private void OnSecondaryButtonClicked(ClickEvent evt, bool isCompleted)
    {
        AudioManager.instance.PlaySound(AudioManager.instance.buttonClickedSound);
        if (isCompleted)
        {
            if (currentLevel.LevelSceneBuildIndex + 1 <= GameManager.instance.levels.Count){
                SceneManager.LoadScene(currentLevel.LevelSceneBuildIndex + 1);
                GameManager.instance.SetCurrentLevelId(currentLevel.Id + 1);
            }
        }
        else SceneManager.LoadScene(currentLevel.LevelSceneBuildIndex);
    }
    private void LocalizeLevelName(){
        if (currentLevel != null) {
            var binding = levelNameLabel.GetBinding("text") as LocalizedString;
            var levelName = binding["level"] as StringVariable;
            levelName.Value = currentLevel.Id.ToString("D3");
        }
    }

    private void OnDisable()
    {
        adsManager.OnRewardedAdClosedEvent -= OnRewardedAdClosed;
    }
}
