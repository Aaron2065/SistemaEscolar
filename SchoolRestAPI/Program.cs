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

        // Obtiene la cadena de conexión
        /*var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        */
        #region
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found");

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
        #endregion

        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

        // Registro de servicios
        builder.Services.AddScoped<ICourseService, CourseService>();
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();
        builder.Services.AddScoped<IGroupService, GroupService>();
        builder.Services.AddScoped<IEmergencyContactService, EmergencyContactService>();
        builder.Services.AddScoped<IPayTypeServices, PayTypeServices>();
        builder.Services.AddScoped<IClassService, ClassService>();
        builder.Services.AddScoped<IPayTypeServices,PayTypeServices>();
        builder.Services.AddScoped<IStudentCourseService,StudentCourseService>();
        builder.Services.AddScoped<IStudentService,StudentService>();
        builder.Services.AddScoped<ITeacherService,TeacherService>();
        builder.Services.AddScoped<ITutorService,TutorService>();
        
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
            builder.Configuration.GetSection("UploadSettings"));

        // 1️⃣ Registrar la política de CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAngularApp", builder =>
            {
                builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        var app = builder.Build();

        // Pipeline de la aplicación
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        // Usar CORS
        app.UseCors("AllowAngularApp");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
