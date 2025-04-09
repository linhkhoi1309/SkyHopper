using System.Collections;
using System.Collections.Generic;
using System.IO;
using SQLite;
using UnityEngine;

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
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        _connection = InitialiseConnection();
        _connection.CreateTable<Level>();
    }

    public SQLiteConnection InitialiseConnection()
    {
        string dbName = "skyhopper.sqlite3";
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
        return _connection;
    }

    public List<Level> GetLevels()
    {
        return _connection.Table<Level>().ToList();
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
