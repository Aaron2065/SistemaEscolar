using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using SchoolData;
using SchoolService.Services.Interfaces;
using SchoolService.Services.Implementations;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Obtiene la cadena de conexi�n
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))
        {
            Console.WriteLine("[ERROR] No se encontr� la cadena de conexi�n.");
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }
        else
        {
            Console.WriteLine($"[DEBUG] Cadena de conexi�n usada: {connectionString}");
        }

        // DbContext
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString,
                x => x.MigrationsHistoryTable("_EFMigrationHistory", "Catalog"));
        });

        // Registro de servicios
        builder.Services.AddScoped<ICourseService, CourseService>();
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();
        builder.Services.AddScoped<IGroupService, GroupService>();
        builder.Services.AddScoped<IEmergencyContactService, EmergencyContactService>();

        // HealthChecks
        builder.Services.AddHealthChecks()
               .AddCheck("self", () => HealthCheckResult.Healthy())
               .AddDbContextCheck<ApplicationDbContext>();

        // Controllers y Swagger
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Configuraci�n de UploadSettings
        builder.Services.Configure<SchoolService.Settings.UploadSettings>(
            builder.Configuration.GetSection("UploadSettings"));

        var app = builder.Build();

        // Pipeline de la aplicaci�n
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
