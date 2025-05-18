//using Octokit;

//namespace Service
//{
//    public class GitHubService
//    {
//        private readonly GitHubClient _client;

//        public GitHubService(string token)
//        {
//            _client = new GitHubClient(new ProductHeaderValue("CV-Site"))
//            {
//                Credentials = new Credentials(token)
//            };
//        }

//        public async Task<IReadOnlyList<Repository>> GetPortfolioAsync(string username)
//        {
//            return await _client.Repository.GetAllForUser(username);
//        }

//        public async Task<SearchRepositoryResult> SearchRepositoriesAsync(string? name, string? language, string? user)
//        {
//            var request = new SearchRepositoriesRequest(name)
//            {
//                Language = language != null ? new Language(language) : null,
//                User = user
//            };

//            return await _client.Search.SearchRepo(request);
//        }
//    }
//}
using CV_Site.Service;
using Octokit;

public class GitHubService : IGitHubService
{
    private readonly GitHubClient _client;
    public GitHubService()
    {
        _client = new GitHubClient(new ProductHeaderValue("my-github-app"));
    }
    public async Task<int> GetUserFollowersAsync(string userName)
    {
        var user = await _client.User.Get(userName);
        return user.Followers;
    }
    public async Task<List<Repository>> SearchRepositoriesInCSharp()
    {
        var request = new SearchRepositoriesRequest("repo-name") { Language = Language.CSharp };
        var result = await _client.Search.SearchRepo(request);
        return result.Items.ToList();
    }
}