using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github
{
    public static class Extensions
    {
        public static void AddGitHub(this IServiceCollection services, Action<GitHubOptions> configureOptions)
        {
            services.AddHttpClient();
            services.Configure(configureOptions);
            services.AddScoped<IGitHubService, GitHubService>();
        }
    }
}
