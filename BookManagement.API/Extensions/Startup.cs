using System.Reflection;
using System.Text.Json.Serialization;

using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

using FluentValidation;
using FluentValidation.AspNetCore;

using BookManagement.Domain.Interfaces;
using BookManagement.Application.Services;
using BookManagement.Infrastructure.Data;
using BookManagement.Infrastructure.Repositories;

namespace BookManagement.API.Extensions;

public static class Startup
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        var connectionString = 
            builder.Configuration.GetValue<string>("DatabaseSettings:BookManagementConnectionString");

        // Contexts
        builder.Services.AddDbContext<BooksDbContext>(opts => 
                        opts.UseSqlServer(connectionString));

        // Validations
        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), ServiceLifetime.Transient);
        builder.Services.AddFluentValidationAutoValidation();

        // Automapper
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // Repositories
        builder.Services.AddTransient<IBookRepository, BookRepository>();
        builder.Services.AddTransient<IUserRepository, UserRepository>();
        builder.Services.AddTransient<IBorrowRepository, BorrowRepository>();

        // Services
        builder.Services.AddTransient<IBookService, BookService>();
        builder.Services.AddTransient<IUserService, UserService>();
        builder.Services.AddTransient<IBorrowService, BorrowService>();

        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.WriteIndented = true;
        });

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(s =>
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
