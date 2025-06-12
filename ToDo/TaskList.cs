using System.Text.Json;

namespace ToDo
{
    internal class TaskList
    {
        private List<Task> _tasks = [];
        private readonly string _fileName = string.Format(@"{0}\ToDo.json", Environment.CurrentDirectory);

        public TaskList()
        {
            // Load tasks from file or CreateFirstTimeList()
            Open();
        }

        // Add a new task to TaskList
        public void AddTask(
            string project,
            string title,
            DateTime date,
            bool isCompleted = false
        )
        {
            try
            {
                Task task = new(project.Trim(), title.Trim(), date, false);
                _tasks.Add(task);
                IO.WriteLine("\nTask Added.", ConsoleColor.Green);
            }
            catch (Exception)
            {
                IO.WriteLine("\nTask not Added.", ConsoleColor.Red);
            }
        }

        // Delete task from TaskList
        public void DeleteTask(int index)
        {
            try
            {
                _tasks.RemoveAt(index);
                IO.WriteLine("\nTask Removed.", ConsoleColor.Green);
            }
            catch (Exception)
            {
                IO.WriteLine("\nTask not Removed.", ConsoleColor.Red);
            }
        }

        // Edit title for task
        public void EditTaskTitle(int index, string title)
        {
            try
            {
                _tasks[index].Title = title;
                IO.WriteLine("\nTitle Updated.", ConsoleColor.Green);
            }
            catch (Exception)
            {
                IO.WriteLine("\nTitle not Updated.", ConsoleColor.Red);
            }
        }

        // Edit project name for task
        public void EditTaskProject(int index, string project)
        {
            try
            {
                _tasks[index].Project = project;
                IO.WriteLine("\nProject Updated.", ConsoleColor.Green);
            }
            catch (Exception)
            {
                IO.WriteLine("\nProject not Updated.", ConsoleColor.Red);
            }
        }

        // Edit date for task
        public void EditTaskDate(int index, DateTime date)
        {
            try
            {
                _tasks[index].Date = date;
                IO.WriteLine("\nDate Updated.", ConsoleColor.Green);
            }
            catch (Exception)
            {
                IO.WriteLine("\nDate not Updated.", ConsoleColor.Red);
            }
        }

        // Toogle task between completed and not completed
        public void ToggleTaskStatus(int index)
        {
            try
            {
                _tasks[index].IsCompleted = _tasks[index].IsCompleted ? false : true;

                IO.WriteLine("\nIsCompleted Updated.", ConsoleColor.Green);
            }
            catch (Exception)
            {
                IO.WriteLine("\nIsCompleted not Updated.", ConsoleColor.Red);
            }
        }

        // Return all tasks
        public Task[] GetTasks()
        {
            return DeepCopyTasks(_tasks.ToArray());
        }

        // Return all tasks sorted by date
        public Task[] GetTasksSortedByDate()
        {
            return DeepCopyTasks(_tasks.OrderBy(task => task.Date).ToArray());
        }

        // Return all tasks sorted by project
        public Task[] GetTasksSortedByProject()
        {
            return DeepCopyTasks(_tasks.OrderBy(task => task.Project).ToArray());
        }

        // Deep copy tasks
        private Task[] DeepCopyTasks(Task[] tasks)
        {
            Task[] copiedTasks = new Task[tasks.Length];
            for (int i = 0; i < _tasks.Count; i++)
            {
                copiedTasks[i] = new Task(
                    tasks[i].Title,
                    tasks[i].Project,
                    DateTime.Parse(_tasks[i].Date.ToString()),
                    tasks[i].IsCompleted);
            }
            return copiedTasks;
        }

        // Return true if index is present in list else false
        public bool IsIndexValid(int index)
        {
            return _tasks.Count > index;
        }

        // Return string representation of task
        public string GetItemToString(int index)
        {
            return IsIndexValid(index) ? _tasks[index].ToString() : "";
        }

        // Tries to save the list in a JSON file
        public void Save()
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(_tasks);
                File.WriteAllText(_fileName, jsonString);
                IO.WriteLine("\n\nYour To-do list has been saved\n", ConsoleColor.Green);
            }
            catch (Exception)
            {
                IO.WriteLine("\n\nFiled to save To-Do List!", ConsoleColor.Red);
            }
        }

        // If a file exists, load it. Otherwise, create a sample list of tasks.
        public void Open()
        {
            if (File.Exists(_fileName))
                Load();
            else
                CreateFirstTimeList();
        }

        // Try to load a list
        private void Load()
        {
            try
            {
                string jsonString = File.ReadAllText(_fileName);
                _tasks = JsonSerializer.Deserialize<List<Task>>(jsonString) ?? [];
//                IO.WriteLine("Opened your saved list\n", ConsoleColor.Green);
            }
            catch (Exception)
            {
                IO.WriteLine("Failed to open saved To-Do List\n", ConsoleColor.Red);
            }
        }

        // Create a populated list of tasks
        private void CreateFirstTimeList()
        {
            _tasks =
                [
                    new Task("Do dishes", "Chores", DateTime.Parse("2025/2/20"), false),
                    new Task("Take out trash", "Chores", DateTime.Parse("2025/2/22"), true),
                    new Task("Read a book", "", DateTime.Parse("2025/3/25"), false),
                    new Task("Mini Project", "C# .NET", DateTime.Parse("2025/2/16"), true),
                    new Task("Individual Project", "C# .NET", DateTime.Parse("2025/2/22"), true),
                    new Task("HTML & CSS", "C# .NET", DateTime.Parse("2025/2/25"), false)
                ];

            IO.WriteLine("Did not find a saved list to load. Created a sample list with some tasks\n", ConsoleColor.Yellow);
            IO.WaitForAnyKey();
        }
    }
}