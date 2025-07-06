using System.Collections;
using System.Collections.Generic;
using System.IO;
using SQLite;
using UnityEngine;
using UnityEngine.Networking;

public class DatabaseManager : MonoBehaviour
{
    SQLiteConnection _connection;
    public static DatabaseManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    void Start()
    {
        StartCoroutine(InitialiseConnectionRoutine());
    }

    public IEnumerator InitialiseConnectionRoutine()
    {
        string dbName = "skyhopper.db";
        string persistentPath = Path.Combine(Application.persistentDataPath, dbName);
        string streamingPath = Path.Combine(Application.streamingAssetsPath, dbName);

        if (!File.Exists(persistentPath))
        {
            #if UNITY_ANDROID
            UnityWebRequest loadDb = UnityWebRequest.Get(streamingPath);
            loadDb.SendWebRequest();
            while (!loadDb.isDone) {}
            File.WriteAllBytes(persistentPath, loadDb.downloadHandler.data);
            #else
            File.Copy(streamingPath, persistentPath);
            #endif
        }

        SQLiteConnectionString options = new SQLiteConnectionString(persistentPath, false);
        _connection = new SQLiteConnection(options);
        yield return null;
    }

    public List<Level> GetLevels()
    {
        return _connection.Table<Level>().ToList();
    }

    public Level GetLevelById(int id)
    {
        return _connection.Find<Level>(id);
    }

    public void UpdateLevelCompletion(int id, bool isCompleted)
    {
        var level = _connection.Find<Level>(id);
        if (level != null)
        {
            level.IsCompleted = isCompleted;
            _connection.Update(level);
        }
    }

    public void UpdateLevelUnlockStatus(int id, bool isUnlocked)
    {
        var level = _connection.Find<Level>(id);
        if (level != null)
        {
            level.IsUnlocked = isUnlocked;
            _connection.Update(level);
        }
    }

    private void OnDestroy()
    {
        if (_connection != null)
        {
            _connection.Close();
            _connection.Dispose();
            _connection = null;
        }
    }
}
