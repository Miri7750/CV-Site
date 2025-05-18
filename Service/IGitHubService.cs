using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IGitHubService
    {

        public Task<List<Repository>> GetPortfolio();

        public Task<SearchRepositoryResult> SearchRepositories(string name, string language, string username);
        
        Task<List<GitHubEvent>> ListPublicEventsForUser();
    }

}
