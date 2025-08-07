using System.Reflection;
using bookapi_minimal.AppContext;
using bookapi_minimal.Exceptions;
using bookapi_minimal.Interfaces;
using bookapi_minimal.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
namespace bookapi_minimal.Extensions

{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            ArgumentNullException.ThrowIfNull(builder);
            if (builder.Configuration == null) throw new ArgumentNullException(nameof(builder.Configuration));
            builder.Services.AddDbContext<ApplicationContext>(configure =>
            {
                configure.UseMySQL(builder.Configuration.GetConnectionString("mySqlConnection"));
            });

            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();
        }
    }
}