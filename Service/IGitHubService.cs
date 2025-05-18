using Octokit;

namespace CV_Site.Service
{
    public interface IGitHubService
    {
        public Task<int> GetUserFollowersAsync(string userName);
        public Task<List<Repository>> SearchRepositoriesInCSharp();

    }
}
