using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameOverMenuUIEventHandler : MonoBehaviour
{
    UIDocument uIDocument;

    Button primaryButton;
    Button secondaryButton;
    private void Awake()
    {
        uIDocument = GetComponent<UIDocument>();
    }
    void Start()
    {
        Level level = DatabaseManager.Instance.GetLevelById(GameManager.instance.currentLevelId);
        Label levelNameLabel = uIDocument.rootVisualElement.Q<Label>(name: "game_over_level_name");
        primaryButton = uIDocument.rootVisualElement.Q<Button>(name: "game_over_primary_button");
        secondaryButton = uIDocument.rootVisualElement.Q<Button>(name: "game_over_secondary_button");
        primaryButton.RegisterCallback<ClickEvent>(OnPrimaryButtonClicked);
        secondaryButton.RegisterCallback<ClickEvent>(OnSecondaryButtonClicked);
        if(level != null) levelNameLabel.text = "Level " + int.Parse(level.LevelName).ToString("D3");
    }

    private void OnPrimaryButtonClicked(ClickEvent evt)
    {
        AudioManager.instance.PlaySound(AudioManager.instance.buttonClickedSound);
    }
    private void OnSecondaryButtonClicked(ClickEvent evt)
    {
        AudioManager.instance.PlaySound(AudioManager.instance.buttonClickedSound);
    }
}
