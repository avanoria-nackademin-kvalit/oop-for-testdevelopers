from todo import Todo

def add_todo(todos: list[Todo]):
    title = input("Ange en aktivitet: ").strip()
    todo = Todo(title)
    todos.append(todo)

def show_todos(todos: list[Todo]):
    for todo in todos:
        print(f"{todo.title} ({todo.is_completed})")

    print("")

def run():
    todos: list[Todo] = []

    while True:
        print("")
        print("###  TODO APP ###")
        print("1. Lägg till en aktivitet")
        print("2. Visa aktiviteter")
        print("0. Avsluta")
        
        choice = input("Välj ett alternativ: ").strip()

        match choice:
            case "1":
                add_todo(todos)

            case "2":
                show_todos(todos)
            
            case "0":
                print("Programmet avslutas.")
                break;
            
            case _:
                print("Ogiltigt val, försök igen.")



if __name__ == "__main__":
    run()
