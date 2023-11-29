using System.Reflection;
using System.Text.Json.Serialization;

using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

using BookManagement.Domain.Interfaces;
using BookManagement.Application.Services;
using BookManagement.Infrastructure.Data;
using BookManagement.Infrastructure.Repositories;

namespace BookManagement.API.ServiceConfiguration;

public static class Startup
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetValue<string>("DatabaseSettings:BookManagementConnectionString");

        // Contexts
        services.AddDbContext<BooksDbContext>(opts => 
                        opts.UseSqlServer(connectionString));

        // Automapper
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // Repositories
        services.AddTransient<IBookRepository, BookRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IBorrowRepository, BorrowRepository>();

        // Services
        services.AddTransient<IBookService, BookService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IBorrowService, BorrowService>();

        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.WriteIndented = true;
        });

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "BookManagement.API",
                Version = "v1",
                Contact = new OpenApiContact
                {
                    Name = "Eduardo Dörr",
                    Email = "edudorr@hotmail.com",
                    Url = new Uri("https://github.com/EduardoDorr")
                }
            });
        });
    }
}
