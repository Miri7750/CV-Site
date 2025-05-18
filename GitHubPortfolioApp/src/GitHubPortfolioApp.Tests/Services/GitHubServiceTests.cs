using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Octokit;
using Xunit;

namespace GitHubPortfolioApp.Tests.Services
{
    public class GitHubServiceTests
    {
        private readonly Mock<IGitHubClient> _mockGitHubClient;
        private readonly GitHubService _gitHubService;

        public GitHubServiceTests()
        {
            _mockGitHubClient = new Mock<IGitHubClient>();
            _gitHubService = new GitHubService("fake_token")
            {
                Client = _mockGitHubClient.Object
            };
        }

        [Fact]
        public async Task GetPortfolioAsync_ReturnsRepositories()
        {
            // Arrange
            var username = "testuser";
            var expectedRepositories = new List<Repository>
            {
                new Repository { Name = "Repo1" },
                new Repository { Name = "Repo2" }
            };

            _mockGitHubClient.Setup(client => client.Repository.GetAllForUser(username))
                .ReturnsAsync(expectedRepositories);

            // Act
            var result = await _gitHubService.GetPortfolioAsync(username);

            // Assert
            Assert.Equal(expectedRepositories.Count, result.Count);
        }

        [Fact]
        public async Task SearchRepositoriesAsync_ReturnsSearchResults()
        {
            // Arrange
            var name = "testrepo";
            var language = "C#";
            var user = "testuser";
            var expectedResult = new SearchRepositoryResult
            {
                TotalCount = 1,
                Items = new List<Repository> { new Repository { Name = "testrepo" } }
            };

            _mockGitHubClient.Setup(client => client.Search.SearchRepo(It.IsAny<SearchRepositoriesRequest>()))
                .ReturnsAsync(expectedResult);

            // Act
            var result = await _gitHubService.SearchRepositoriesAsync(name, language, user);

            // Assert
            Assert.Equal(expectedResult.TotalCount, result.TotalCount);
        }
    }
}