# WebAppInfo
* In .NET6.0, WebApplication(inside namespace Microsoft.AspNetCore.Builder) is the web application used to configure the HTTP pipeline, and routes.
* In .NET6.0, WebApplicationBuilder(inside namespace Microsoft.AspNetCore.Builder) is a builder for web application and services.
* WebApplication: The web application used to configure the HTTP pipeline, and routes.
* WebApplicationBuilder: A builder for web applications and services.
* WebApplicationOptions: Options for configuing the behavior for WebApplicationBuilder.
* HostBuilder: A program initialization utility. It configures services. It returns IHost and IHostBuilder.


**Q. How can you get hosting environment details of a running web application?**
<pre>var builder = new WebApplicationBuilder();
builder.Environment returns IWebHostEnvironment which provides the hosting environment details of a running web application. For example,</pre>
```
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
        var appName = builder.Environment.ApplicationName;
        var environmentName = builder.Environment.EnvironmentName;
        var contentRootPath = builder.Environment.ContentRootPath;
        var webRootPath = builder.Environment.WebRootPath;
        string result = $"ApplicationName: {appName}\nEnvironmentName: {environmentName}\nContentRootPath:{contentRootPath}\nWebRootPath:{webRootPath}";
        return result;
    }
}
```
**Q. What is ConfigurationManager?**
A collection of configuration providers for the web application to compose. This is useful to add new configuration sources and providers. 
ConfigurationManager configManager = builder.Configuration;
For example,
```
configManager.AddConfiguration(args);
configManager.AddEnvironmentVariables(args);


var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    ApplicationName = typeof(Program).Assembly.FullName,
    ContentRootPath = Directory.GetCurrentDirectory(),
    EnvironmentName = Environments.Staging,
    WebRootPath = "customwwwroot"
});

Console.WriteLine($"Application Name: {builder.Environment.ApplicationName}");
Console.WriteLine($"Environment Name: {builder.Environment.EnvironmentName}");
Console.WriteLine($"ContentRoot Path: {builder.Environment.ContentRootPath}");
Console.WriteLine($"WebRootPath: {builder.Environment.WebRootPath}");

var app = builder.Build();
```
