
//using Service;
using Microsoft.OpenApi.Models;
using Service;

namespace CV_site
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddMemoryCache();
            builder.Services.AddGitHub(options => builder.Configuration.GetSection(nameof(GitHubOptions)).Bind(options));
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi(); // Ensure this is correctly configured
            builder.Services.AddSwaggerGen(); // Add Swagger generation service

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(); 
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
                app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
