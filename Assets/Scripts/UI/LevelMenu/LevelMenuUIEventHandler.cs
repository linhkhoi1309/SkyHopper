using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LevelMenuUIEventHandler : MonoBehaviour
{
    UIDocument uIDocument;
    ScrollView scrollView;

    List<Level> levels = new List<Level>();

    private void Awake()
    {
        uIDocument = GetComponent<UIDocument>();
        scrollView = uIDocument.rootVisualElement.Q<ScrollView>(className: "level_scroll_view");
    }

    private void Start()
    {
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

    private void OnLevelButtonClicked(ClickEvent evt, Level level)
    {
        if (!level.IsCompleted) return;
        AudioManager.instance.PlaySound(AudioManager.instance.buttonClickedSound);
        SceneManager.LoadScene(level.LevelSceneBuildIndex);
        GameManager.instance.ResetGame();
        GameManager.instance.SetCurrentLevel(level);
    }
}
