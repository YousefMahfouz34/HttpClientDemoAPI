
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using TestApiForTestHttpClient.context;
using TestApiForTestHttpClient.Services;

namespace TestApiForTestHttpClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors(option =>
            {
                option.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); 
                });
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
          
            builder.Services.AddDbContext<HttpClientContextTest>(option=>option.UseSqlServer(builder.Configuration.GetConnectionString("CS")));
            builder.Services.AddScoped<IPostServices, PostServices>();
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
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
