using Octokit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitHubPortfolioApp.Services
{
    public class GitHubService
    {
        private readonly GitHubClient _client;

        public GitHubService(string token)
        {
            _client = new GitHubClient(new ProductHeaderValue("GitHubPortfolioApp"))
            {
                Credentials = new Credentials(token)
            };
        }

        public async Task<IReadOnlyList<Repository>> GetPortfolioAsync(string username)
        {
            return await _client.Repository.GetAllForUser(username);
        }

        public async Task<SearchRepositoryResult> SearchRepositoriesAsync(string? name, string? language, string? user)
        {
            var request = new SearchRepositoriesRequest(name)
            {
                Language = language != null ? new Language(language) : null,
                User = user
            };

            return await _client.Search.SearchRepo(request);
        }
    }
}