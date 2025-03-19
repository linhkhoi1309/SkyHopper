using System.Collections;
using System.Collections.Generic;
using System.IO;
using SQLite;
using UnityEngine;

public class Stock
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Symbol { get; set; }
}

public class DatabaseManager : MonoBehaviour
{
    // Start is called before the first frame update

    SQLiteConnection _connection;

    void Start()
    {
        _connection = InitialiseConnection();
        _connection.CreateTable<Stock>();
        AddStock(_connection, "Cat");
    }

    public SQLiteConnection InitialiseConnection()
    {
        var DataSource = "skyhopper.sqlite3";

        SQLiteConnectionString options = new SQLiteConnectionString(Path.Combine(Application.persistentDataPath, DataSource), false);
        _connection = new SQLiteConnection(options);

        return _connection;
    }

    public static void AddStock(SQLiteConnection db, string symbol)
    {
        var stock = new Stock()
        {
            Symbol = symbol
        };
        db.Insert(stock);
        Debug.Log(stock.Symbol + " " + stock.Id);
    }
}
