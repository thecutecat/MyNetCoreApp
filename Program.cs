using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.Models;
using WebApplication1.Data.Repo;
using WebApplication1.Data.Services;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<TodoContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddScoped<ITodolistRepo, TodolistRepo>();
            //to enable route
            builder.Services.AddControllers();

            //Http Clients
            var BaseUri = "https://localhost:7129/"; 
            builder.Services.AddHttpClient<TodoService>(client =>
            {
                client.BaseAddress = new Uri(BaseUri);
            });

            var app = builder.Build();

            

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.UseMigrationsEndPoint();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}