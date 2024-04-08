# YakimGames

This project is built using .NET 8 and Entity Framework Core 8, demonstrating a simple task management system with progress tracking of tasks.

## Getting Started

### Prerequisites

-   .NET 8,0
-   MySQL Server (Version 8.0 or later recommended)

### Installation

1.  Clone the repository:

    `git clone https://github.com/Degril/YakimGamesTaskBundle.git`

2.  Navigate to the project directory:

    `cd your-project-directory`

3.  Restore the .NET packages:

    `dotnet restore`

4.  Update the `appsettings.json` with your MySQL connection string.

5.  Apply the migrations to your database:

    `dotnet ef database update`


### Running the Project

Run the project using the .NET CLI:

`dotnet run`

Or, open the project in Visual Studio/VS Code and run using the IDE.

## Testing the Application

For testing the API endpoints, you can use the integrated Swagger UI:

-   Navigate to [http://localhost:5246/swagger/index.html](http://localhost:5246/swagger/index.html) in your web browser while the application is running.
-   You will see the Swagger UI with all the available API endpoints.
-   You can test each endpoint directly from the UI by clicking on an endpoint, filling in the required parameters, and clicking "Try it out".

## Viewing Entity Relationship Diagrams

To view the entity relationship diagrams for the MySQL database, you have multiple options:

### MySQL Workbench

1.  Open MySQL Workbench and connect to your database.
2.  Navigate to `Database` > `Reverse Engineer` in the top menu.
3.  Follow the steps in the wizard to generate the ER diagram from your database schema.

### Using Entity Framework Core Power Tools (For EF Core)

1.  Ensure Entity Framework Core Power Tools is installed in Visual Studio.
2.  Right-click on your project in Solution Explorer and select `EF Core Power Tools` > `Reverse Engineer`.
3.  Follow the prompts, selecting your MySQL database to generate entity and context classes.
4.  After generation, use `EF Core Power Tools` > `Add DbContext Model Diagram` to create and view the ER diagram.
