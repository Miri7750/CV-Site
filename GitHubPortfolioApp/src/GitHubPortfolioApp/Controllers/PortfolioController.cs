using Microsoft.AspNetCore.Mvc;
using Service;
using System.Threading.Tasks;

namespace GitHubPortfolioApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortfolioController : ControllerBase
    {
        private readonly GitHubService _gitHubService;

        public PortfolioController(GitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetPortfolio(string username)
        {
            var repositories = await _gitHubService.GetPortfolioAsync(username);
            return Ok(repositories);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchRepositories(string? name, string? language, string? user)
        {
            var searchResult = await _gitHubService.SearchRepositoriesAsync(name, language, user);
            return Ok(searchResult);
        }
    }
}