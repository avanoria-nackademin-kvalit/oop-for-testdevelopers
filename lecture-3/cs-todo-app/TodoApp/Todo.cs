namespace TodoApp;

public class Todo(string title)
{
    public string Title { get; set; } = title;
    public bool IsCompleted { get; set; }
}
