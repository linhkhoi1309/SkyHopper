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
        string dataSource = "skyhopper.sqlite3";
        SQLiteConnectionString options = new SQLiteConnectionString(Path.Combine(Application.persistentDataPath, dataSource), false);
        _connection = new SQLiteConnection(options);
        return _connection;
    }

    public List<Level> GetLevels()
    {
        return _connection.Table<Level>().ToList();
    }

    private void OnDestroy() {
        if (_connection != null)
        {
            _connection.Close();
            _connection.Dispose();
            _connection = null;
        }
    }
}
