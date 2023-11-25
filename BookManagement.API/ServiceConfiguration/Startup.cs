using System.Text.Json.Serialization;

using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

using BookManagement.Application.Services;
using BookManagement.Domain.Interfaces.Services;
using BookManagement.Domain.Interfaces.Repositories;
using BookManagement.Infrastructure.Data;
using BookManagement.Infrastructure.Repositories;

namespace BookManagement.API.ServiceConfiguration;

public static class Startup
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetValue<string>("DatabaseSettings:BookManagementConnectionString");

        services.AddDbContext<BooksDbContext>(opts => opts.UseSqlServer(connectionString));

        services.AddTransient<IBookRepository, BookRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ILoanRepository, LoanRepository>();

        services.AddTransient<IBookService, BookService>();
        //services.AddTransient<IUserService, UserService>();
        //services.AddTransient<ILoanService, LoanService>();

        //services.AddAutoMapper(typeof(CustomerProfile).Assembly);

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
