using System.Text;
using TodoApp;

void AddTodo(List<Todo> todos)
{
    Console.Clear();
    Console.Write("Ange en aktivitet: ");
    var title = Console.ReadLine();

    var todo = new Todo(title);
    todos.Add(todo);
}

void ShowTodos(List<Todo> todos)
{
    Console.Clear();
    foreach (var todo in todos)
        Console.WriteLine($"{todo.Title} ({todo.IsCompleted})");

    Console.ReadKey();
}

void Run()
{
    List<Todo> todos = [];

    while (true)
    {
        Console.WriteLine("### TODO APP ###");
        Console.WriteLine("1. Ange ny aktivitet");
        Console.WriteLine("2. Visa aktiviteter");
        Console.WriteLine("0. Avsluta");

        Console.Write("Ange ett alternativ: ");
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                AddTodo(todos);
                break;

            case "2":
                ShowTodos(todos);
                break;

            case "0":
                Console.WriteLine("Avslutar applikationen");
                break;

            default:
                Console.WriteLine("Ogitligt val, försök igen");
                break;
        }

        Console.Clear();
    }
}

Run();