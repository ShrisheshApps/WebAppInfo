using Microsoft.AspNetCore.Mvc;
namespace WebAppInfo.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    [HttpGet]
    public string Get()
    {
        var builder = WebApplication.CreateBuilder();
        //get web hosting environment details
        var appName = builder.Environment.ApplicationName;
        var environmentName = builder.Environment.EnvironmentName;
        var contentRootPath = builder.Environment.ContentRootPath;
        var webRootPath = builder.Environment.WebRootPath;
        string result1 = $"ApplicationName: {appName}\nEnvironmentName: {environmentName}\nContentRootPath:{contentRootPath}\nWebRootPath:{webRootPath}";
        
        //
        var configurationProviders =builder.Configuration;
        //string basePath = typeof(Program).Assembly.Location;
        string basePath = Directory.GetCurrentDirectory();
        //set file path for file based configuration providers
        _ = configurationProviders.SetBasePath(basePath);
        //configuration file path relative to base path
        IConfigurationBuilder configuration = configurationProviders.AddJsonFile("appsettings.json");
        IConfigurationRoot appSettings= configuration.Build();
        //read key-value
        string result2 = appSettings.GetSection("Logging:LogLevel:Microsoft.AspNetCore").Value;

        return result1 + Environment.NewLine + "Microsoft.AspNetCore: " + result2;
    }
}