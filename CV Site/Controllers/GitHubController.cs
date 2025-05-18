using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using ; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory; 
using Microsoft.Extensions.Options;
using Service;

namespace CV_site.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GitHubController : ControllerBase
    {
        private readonly IGitHubService _gitHubService;
        private readonly IMemoryCache _cache; 

        public GitHubController(IOptions<GitHubOptions> options, IGitHubService githubService, IMemoryCache cache)
        {
            _gitHubService = githubService;
            _cache = cache;
        }

        [HttpGet("portfolio")]
        public async Task<IActionResult> GetPortfolio()
        {
            var cacheKey = "GitHubPortfolio";
            var lastFetchedTimeKey = "LastFetchedTime";

            if (_cache.TryGetValue(cacheKey, out List<RepositoryInfo> cachedRepos) &&
                _cache.TryGetValue(lastFetchedTimeKey, out DateTime lastFetchedTime))
            {
                var events = await _gitHubService.ListPublicEventsForUser("Miri7750"); 
                if (events.Any(e => e.CreatedAt > lastFetchedTime))
                {
                    _cache.Remove(cacheKey);
                }
                else
                {
                    return Ok(cachedRepos);
                }
            }

            var repositories = await _gitHubService.GetPortfolio();

            _cache.Set(cacheKey, repositories, TimeSpan.FromMinutes(10));
            _cache.Set(lastFetchedTimeKey, DateTime.UtcNow, TimeSpan.FromMinutes(10));
            return Ok(repositories);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchRepositories(string name = null, string language = null, string username = null)
        {
            var result = await _gitHubService.SearchRepositories(name, language, username);
            return Ok(result.Items);
        }
    }
}
