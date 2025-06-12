namespace ToDo
{
    internal class Task
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
        public String Project { get; set; }

        public Task(string title, string project, DateTime date, bool isCompleted)
        {
            Title = title;
            Project = project;
            Date = date;
            IsCompleted = isCompleted;
        }

        public override string ToString()
        {
            return $"TITLE: \"{Title}\" PROJECT: \"{Project}\" DATE: \"{Date}\" COMPLETED: \"{(IsCompleted ? "Yes" : "No")}\"";
        }
    }
}