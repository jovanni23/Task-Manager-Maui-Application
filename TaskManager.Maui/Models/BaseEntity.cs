using SQLite;

namespace TaskManager.Maui.Models;

public abstract class BaseEntity
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
}