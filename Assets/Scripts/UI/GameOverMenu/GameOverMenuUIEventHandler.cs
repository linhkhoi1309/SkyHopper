using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverMenuUIEventHandler : MonoBehaviour
{
    UIDocument uIDocument;
    Button primaryButton;
    VisualElement secondaryButton;
    Level currentLevel;
    Label levelNameLabel;
    Label levelStateLabel;

    [SerializeField] Sprite nextLevelIcon;

    private void Awake()
    {
        uIDocument = GetComponent<UIDocument>();
    }
    void Start()
    {
        currentLevel = DatabaseManager.Instance.GetLevelById(GameManager.instance.currentLevelId);

        levelNameLabel = uIDocument.rootVisualElement.Q<Label>(name: "game_over_level_name");
        levelStateLabel = uIDocument.rootVisualElement.Q<Label>(name: "game_over_level_state");
        primaryButton = uIDocument.rootVisualElement.Q<Button>(name: "game_over_primary_button");
        secondaryButton = uIDocument.rootVisualElement.Q<VisualElement>(name: "game_over_secondary_button_icon");

        primaryButton.RegisterCallback<ClickEvent>(OnPrimaryButtonClicked);
        secondaryButton.RegisterCallback<ClickEvent, bool>(OnSecondaryButtonClicked, currentLevel.IsCompleted);

        if (currentLevel != null) levelNameLabel.text = "Level " + int.Parse(currentLevel.LevelName).ToString("D3");
        if (currentLevel.IsCompleted)
        {
            levelStateLabel.text = "COMPLETED";
            primaryButton.style.display = DisplayStyle.None;
            secondaryButton.style.backgroundImage = new StyleBackground(nextLevelIcon);
            secondaryButton.style.scale = new Scale(new Vector2(1f, 1f));
            secondaryButton.style.width = new StyleLength(new Length(80, LengthUnit.Pixel));
            secondaryButton.style.height = new StyleLength(new Length(80, LengthUnit.Pixel));
        }
        else
        {
            levelStateLabel.text = "FAILED";
            primaryButton.text = "Skip";
        }
    }

    private void OnPrimaryButtonClicked(ClickEvent evt)
    {
        AudioManager.instance.PlaySound(AudioManager.instance.buttonClickedSound);
        if (currentLevel.LevelSceneBuildIndex + 1 <= GameManager.instance.levels.Count)
            SceneManager.LoadScene(currentLevel.LevelSceneBuildIndex + 1);
    }
    private void OnSecondaryButtonClicked(ClickEvent evt, bool isCompleted)
    {
        AudioManager.instance.PlaySound(AudioManager.instance.buttonClickedSound);
        if (isCompleted)
        {
            if (currentLevel.LevelSceneBuildIndex + 1 <= GameManager.instance.levels.Count)
                SceneManager.LoadScene(currentLevel.LevelSceneBuildIndex + 1);
        }
        else SceneManager.LoadScene(currentLevel.LevelSceneBuildIndex);
    }
}
