using SQLite;

[Table("Level")]
public class Level {
    [PrimaryKey, AutoIncrement]
    [Column("id")]		
    public int Id { get; set; }	

    [Column("levelName")]
    public string LevelName { get; set; }

    [Column("levelSceneBuildIndex")]
    public int LevelSceneBuildIndex { get; set; }

    [Column("isCompleted")]
    public bool IsCompleted { get; set; }
}
