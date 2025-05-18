using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Service
{

    public class GitHubService:IGitHubService
    {
        private readonly GitHubClient _client;
        private readonly GitHubOptions _options;
        private readonly HttpClient _httpClient;

        public GitHubService(IOptions<GitHubOptions> options, HttpClient httpClient)
        {
            _client = new GitHubClient(new ProductHeaderValue("CV-SITE"));
            _options = options.Value;
            _client.Credentials = new Credentials(_options.Token);
            _httpClient = httpClient;
        }

        public async Task<List<Repository>> GetPortfolio()
        {
            var repositories = await _client.Repository.GetAllForCurrent();
            return repositories.ToList();
        }

        public async Task<SearchRepositoryResult> SearchRepositories(string name, string language, string username)
        {
            Language? parsedLanguage = null;

            if (Enum.TryParse(language, true, out Language result))
            {
                parsedLanguage = result;
            }

            var request = new SearchRepositoriesRequest(name)
            {
                Language = parsedLanguage,
                User = username,
            };
            return await _client.Search.SearchRepo(request);
        }

        public async Task<List<GitHubEvent>> ListPublicEventsForUser()
        {
            string username = _options.Username;
            var url = $"https://api.github.com/users/{username}/events/public";

            // הוספת כותרת User-Agent לפי דרישות GitHub API
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "YourAppName");

            var events = await _httpClient.GetFromJsonAsync<List<GitHubEvent>>(url);
            return events;
        }
    }

}
