using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int currentLevelId{ get; private set; } = -1;
    public int currentCoinCount{ get; private set; } = 0;
    public List<Level> levels = new List<Level>();
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCurrentLevelId(int levelId)
    {
        currentLevelId = levelId;
    }

    public void IncreaseCurrentCoinCount()
    {
        currentCoinCount++;
    }

    public void GameOver(){
        Invoke("LoadGameOverScene", 2f);
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene(GlobalConfig.GAME_OVER_SCENE_BUILD_INDEX);
    }

    public void ResetGame()
    {
        currentLevelId = -1;
        currentCoinCount = 0;
    }
}
