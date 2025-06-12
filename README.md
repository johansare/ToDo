# **ToDo (Console Application)**

This is a straightforward console-based application for managing your to-do list. The program allows you to add, edit, delete, view, and save tasks.

## **Description**

This application is a basic To-Do list that runs directly in your console (terminal). It's designed to be easy to use and provides you with the ability to keep track of your tasks with core functionalities like saving and loading your list from a file.

## **Features**

* View Tasks: Display all your tasks, sorted either by date or by project.
* Add New Task: Create new tasks with a title, project, and due date.
* Edit Task: Modify the title, project, date, or status (completed/not completed) of existing tasks.
* Delete Task: Remove tasks from your list.
* Save and Load: Your to-do list is automatically saved to a JSON file when you exit the program and loaded when you start it again. If no file is found, a sample list will be created.

## **How to Use the Program**

1. Start the program: When the program starts, you'll be presented with the main menu.
2. Navigate the menu: Use the numbers 1-5 to select options from the menu:
   * 1: Show Task List.
   * 2: Add new Task.
   * 3: Edit Task.
   * 4: Delete Task.
   * 5: Quit and Save.
3. Follow the instructions: The program will guide you through the various steps when you select a menu option, such as entering a title, project, or date for a task.

## **Program Structure (Classes)**

The program is divided into several classes, each with specific responsibilities:

* Program: The entry point of the application. It initializes TaskList and UI and starts the user interface loop.
* UI: Handles all user interaction, displays menus, receives input, and presents task information. It acts as the bridge between the user and the task logic.
* TaskList: Responsible for managing the collection of tasks (Task objects). This includes adding, deleting, editing, sorting, and saving/loading tasks to/from a JSON file.
* Task: A simple model class that represents a single task with properties like Title, Project, Date, and IsCompleted.
* IO: A static helper class that handles all low-level console input and output, such as writing text, reading input, and managing colors.

## **Installation and Compilation**

To run this program, you will need the .NET SDK installed on your machine.

1. Clone the repository:
   git clone https://github.com/johansare/ToDo.git

2. Navigate to the project directory:
   cd ToDo

3. Compile and run the program:
   dotnet run
