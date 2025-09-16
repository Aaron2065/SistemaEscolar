using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using SchoolData;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        #region
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("sql_connection"),
                x => x.MigrationsHistoryTable("_EFMigrationHistory", "Catalog"));
        });
        #endregion
        //Luego HealthChecks
        builder.Services.AddHealthChecks()
               .AddCheck("self", () => HealthCheckResult.Healthy())
               .AddDbContextCheck<ApplicationDbContext>();

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        #region Servicios de archivo de configuracion
        builder.Services.Configure<SchoolService.Settings.UploadSettings>(builder.Configuration.GetSection("UploadSettings"));
        #endregion


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