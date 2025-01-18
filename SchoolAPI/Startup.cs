using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using SchoolAPI.Model;
using SchoolAPI.Repository;
using SchoolAPI.Service;
using SchoolAPI.Configuration;
using System.Reflection;

namespace SchoolAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Configures services for the application.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddControllers();

            // Swagger Configuration
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // AutoMapper Configuration
            services.AddAutoMapper(typeof(StudentMapper));

            // FluentValidation Configuration
            services.AddFluentValidation(fv =>
            {
                fv.ImplicitlyValidateChildProperties = true;
                fv.ImplicitlyValidateRootCollectionElements = true;
                fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });

            // Dependency Injection for Services and Repositories
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Database Context Configuration
            services.AddDbContext<StudentDBContext>(options =>
            {
                var connectionString = _configuration.GetConnectionString("DBConnection");
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
        }

        /// <summary>
        /// Configures middleware for the application.
        /// </summary>
        public void Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
