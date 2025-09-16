using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using SchoolData;
using SchoolService.Services.Interfaces;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Obtener cadena de conexión
        var connection = builder.Configuration.GetConnectionString("DefaultConnection")
                         ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found");

        // Registrar DbContext con SQL Server y resiliencia
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(
                connection,
                sqlOptions =>
                {
                    sqlOptions.MigrationsHistoryTable("_EFMigrationHistory", "Catalog"); // tabla de historial
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null
                    ); // resiliencia
                }
            );
        });

        // Registrar servicios
        builder.Services.AddScoped<ICourseService, CourseService>();
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();

        // HealthChecks
        builder.Services.AddHealthChecks()
               .AddCheck("self", () => HealthCheckResult.Healthy())
               .AddDbContextCheck<ApplicationDbContext>();

        // Controllers y Swagger
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Configuración de UploadSettings
        builder.Services.Configure<SchoolService.Settings.UploadSettings>(
            builder.Configuration.GetSection("UploadSettings")
        );

        var app = builder.Build();

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
