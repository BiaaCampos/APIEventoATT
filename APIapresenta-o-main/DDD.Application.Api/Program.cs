using DDD.Infra.SQLServer;
using DDD.Infra.SQLServer.Interfaces;
using DDD.Infra.SQLServer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using ApplicationServiceVenda;
using DDD.DomainService;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });

        // Adicione outros serviços necessários aqui
        services.AddScoped<IEventosRepository, EventosRepositorySqlServer>();
        services.AddScoped<ICompradorRepository, CompradorRepositorySqlServer>();
        services.AddScoped<IVendaRepository, VendaRepositorySqlServer>();
        services.AddScoped<AppServiceVenda, AppServiceVenda>();
        services.AddScoped<VendaDomainService, VendaDomainService>();
        services.AddScoped<SqlContext, SqlContext>();

        services.AddControllers().AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();

        app.UseCors("CorsPolicy"); // Coloque isso antes de UseAuthorization e UseEndpoints

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
