using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Level currentLevel{ get; private set; }= null;
    public int currentCoinCount{ get; private set; } = 0;

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

    public void SetCurrentLevel(Level level)
    {
        currentLevel = level;
    }

    public void IncreaseCurrentCoinCount()
    {
        currentCoinCount++;
    }

    public void ResetGame()
    {
        currentLevel = null;
        currentCoinCount = 0;
    }
}
