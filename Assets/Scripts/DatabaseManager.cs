using System.Collections;
using System.Collections.Generic;
using System.IO;
using SQLite;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    SQLiteConnection _connection;

    void Start()
    {
        _connection = InitialiseConnection();
    }

    public SQLiteConnection InitialiseConnection()
    {
        string dataSource = "skyhopper.sqlite3";
        SQLiteConnectionString options = new SQLiteConnectionString(Path.Combine(Application.persistentDataPath, dataSource), false);
        _connection = new SQLiteConnection(options);
        return _connection;
    }
}
