namespace ToDo
{
    internal class UI
    {
        private TaskList _taskList;

        public UI(TaskList taskList)
        {
            this._taskList = taskList;
        }

        public void Loop()
        {
            // Main Menu
            while (true)
            {
                IO.Clear();
                IO.WriteLine("Main Menu\n", ConsoleColor.DarkGray);
                IO.Write("("); IO.Write("1", ConsoleColor.DarkCyan); IO.WriteLine(") Show Task List");
                IO.Write("("); IO.Write("2", ConsoleColor.DarkCyan); IO.WriteLine(") Add new Task");
                IO.Write("("); IO.Write("3", ConsoleColor.DarkCyan); IO.WriteLine(") Edit Task");
                IO.Write("("); IO.Write("4", ConsoleColor.DarkCyan); IO.WriteLine(") Delete Task");
                IO.Write("("); IO.Write("5", ConsoleColor.DarkCyan); IO.WriteLine(") Quit and Save\n");

                var key = IO.ReadKey(": ");
                switch (key.KeyChar)
                {
                    case '1':
                        Show();
                        break;

                    case '2':
                        Add();
                        break;

                    case '3':
                        Edit();
                        break;

                    case '4':
                        Delete();
                        break;

                    case '5':
                        Quit();
                        break;
                }
            }
        }

        // Show Task List Menu
        private void Show()
        {
            IO.WriteLine("\n\nShow Tasks Menu\n", ConsoleColor.DarkGray);
            IO.Write("("); IO.Write("1", ConsoleColor.DarkCyan); IO.WriteLine(") Show Tasks by Date");
            IO.Write("("); IO.Write("2", ConsoleColor.DarkCyan); IO.WriteLine(") Show Tasks by Project\n");

            var key = IO.ReadKey(": ");
            switch (key.KeyChar)
            {
                case '1':
                    DisplayTasks(_taskList.GetTasksSortedByDate());
                    IO.WaitForAnyKey();
                    break;

                case '2':
                    DisplayTasks(_taskList.GetTasksSortedByProject());
                    IO.WaitForAnyKey();
                    break;
            }
        }

        // Add new Task Menu
        private void Add()
        {
            IO.WriteLine("\n\nAdd new Task\n", ConsoleColor.DarkGray);
            
            string title = IO.ReadString("Title: ");
            string project = IO.ReadString("Project: ", allowEmpty : true);
            DateTime date = IO.ReadDate("Date: ");

            _taskList.AddTask(title, project, date);
            IO.WaitForAnyKey();
        }

        // Edit Task Menu
        private void Edit()
        {
            IO.Write("\n\nEdit Task Menu", ConsoleColor.DarkGray);

            DisplayTasks(_taskList.GetTasks(), withIndex : true);

            IO.WriteLine("");
            int index = IO.ReadIndex(": ");
            if (index == -1 || !_taskList.IsIndexValid(index))
            {
                return;
            }

            IO.Write("\n("); IO.Write("1", ConsoleColor.DarkCyan); IO.WriteLine(") Edit Title");
            IO.Write("("); IO.Write("2", ConsoleColor.DarkCyan); IO.WriteLine(") Edit Project");
            IO.Write("("); IO.Write("3", ConsoleColor.DarkCyan); IO.WriteLine(") Edit Date");
            IO.Write("("); IO.Write("4", ConsoleColor.DarkCyan); IO.WriteLine(") Toggle Completed or Not Completed\n");

            var key = IO.ReadKey(": ");
            IO.WriteLine("\n");
            switch (key.KeyChar)
            {
                case '1':   // Title
                    IO.WriteLine(_taskList.GetItemToString(index) + "\n", ConsoleColor.Cyan);
                    string title = IO.ReadString("Title: ");
                    _taskList.EditTaskTitle(index, title: title);
                    break;

                case '2':   // Project
                    IO.WriteLine(_taskList.GetItemToString(index) + "\n", ConsoleColor.Cyan);
                    string project = IO.ReadString("Project: ", allowEmpty : true);
                    _taskList.EditTaskProject(index, project: project);
                    break;

                case '3':   // Date
                    IO.WriteLine(_taskList.GetItemToString(index) + "\n", ConsoleColor.Cyan);
                    DateTime date = IO.ReadDate("Date: ");
                    _taskList.EditTaskDate(index, date: date);
                    break;

                case '4':
                    _taskList.ToggleTaskStatus(index);
                    break;
            }
            IO.WaitForAnyKey();
        }

        // Delete Task Menu
        private void Delete()
        {
            IO.Write("\n\nDelete Task Menu", ConsoleColor.DarkGray);
            DisplayTasks(_taskList.GetTasks(), withIndex: true);
            IO.WriteLine("");
            
            int index = IO.ReadIndex(": ");
            if (index == -1)
            {
                return;
            }

            _taskList.DeleteTask(index);
            IO.WaitForAnyKey();
        }

        // Quit and Save Menu
        private void Quit()
        {
            _taskList.Save();
            Environment.Exit(0);
        }

        // Display list of tasks
        private void DisplayTasks(Task[] tasks, bool withIndex = false)
        {
            {
                int maxProjectLength = tasks.Max(task => task.Project.Length) + 2;
                if (maxProjectLength < 9)
                {
                    maxProjectLength = 9;
                }

                IO.WriteLine(
                    "\n\n"
                    + (withIndex ? "Index".PadRight(7) : "")
                        + "Project".PadRight(maxProjectLength)
                        + "Completed".PadRight(11)
                        + "Date".PadRight(12)
                        + "Title",
                    ConsoleColor.White
                );

                for (int i = 0; i < tasks.Length; i++)
                {
                    IO.Write((withIndex ? i.ToString().PadRight(7) : ""), ConsoleColor.DarkCyan);
                    IO.WriteLine(
                            tasks[i].Project.PadRight(maxProjectLength)
                            + (tasks[i].IsCompleted ? "Yes" : "No").PadRight(11)
                            + tasks[i].Date.ToString("yyyy/MM/dd").PadRight(12)
                            + tasks[i].Title,
                        (tasks[i].IsCompleted ? ConsoleColor.DarkGray : ConsoleColor.Gray)
                    );
                }
            }
        }
    }
}