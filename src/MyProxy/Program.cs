using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using MyProxy;
using Yarp.ReverseProxy;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = CreateHostBuilder(args);

        builder.Configuration.AddJsonFile("appsettings.json");
        builder.Configuration.AddJsonFile("appsettings.proxy.json");
        builder.Configuration.AddJsonFile("appsettings.jwt.json");

        var startup = new Startup(builder.Configuration);
        startup.ConfigureServices(builder.Services);

        var app = builder.Build();
        startup.Configure(app, app.Environment);

        app.Run();
    }

    public static WebApplicationBuilder CreateHostBuilder(string[] args)
    {
        var options = new WebApplicationOptions
        {
            ApplicationName = "MyProxy",
            Args = args,
            WebRootPath = "wwwroot/next"
        };

        return WebApplication.CreateBuilder(options);
    }
}
