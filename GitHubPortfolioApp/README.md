# GitHubPortfolioApp/GitHubPortfolioApp/README.md

# GitHub Portfolio Application

This is a .NET Core Web API application that interacts with the GitHub API to retrieve and display a user's GitHub portfolio. It utilizes the Octokit library to facilitate communication with the GitHub API.

## Project Structure

- **GitHubPortfolioApp.sln**: Solution file that organizes the projects within the solution.
- **src/GitHubPortfolioApp**: Main application project.
  - **Controllers/PortfolioController.cs**: Handles HTTP requests related to the user's GitHub portfolio.
  - **Models/RepositoryModel.cs**: Defines the structure of a GitHub repository.
  - **Services/GitHubService.cs**: Interacts with the GitHub API using Octokit.
  - **Program.cs**: Entry point of the application.
  - **Startup.cs**: Configures services and the application's request pipeline.
  - **appsettings.json**: Contains configuration settings for the application.
- **src/GitHubPortfolioApp.Tests**: Test project for unit testing.
  - **Services/GitHubServiceTests.cs**: Unit tests for the GitHubService class.
  - **GitHubPortfolioApp.Tests.csproj**: Project file for the test project.
- **.gitignore**: Specifies files and directories to be ignored by Git.

## Setup Instructions

1. Clone the repository:
   ```
   git clone <repository-url>
   ```

2. Navigate to the project directory:
   ```
   cd GitHubPortfolioApp
   ```

3. Restore the dependencies:
   ```
   dotnet restore
   ```

4. Configure your GitHub API token in `appsettings.json`.

5. Run the application:
   ```
   dotnet run --project src/GitHubPortfolioApp
   ```

## Usage

- Access the API endpoints to retrieve portfolio data and search for repositories.
- Use tools like Postman or your web browser to interact with the API.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any enhancements or bug fixes.

## License

This project is licensed under the MIT License. See the LICENSE file for details.