using System.Text.Json;
using ToDo;

internal class Program
{
    private static void Main(string[] args)
    {
        TaskList taskList = new();
        UI ui = new(taskList);
        ui.Loop();
    }
}