using Microsoft.AspNetCore.Mvc;
namespace LoggingDemo.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoggingController : ControllerBase
{
    private readonly ILogger<LoggingController> logger;
    public LoggingController(ILogger<LoggingController> logger)
    {
        this.logger = logger;
    }
    [HttpGet]
    [Route("structured-logging")]
    public ActionResult StructuredLoggingSample()
    {
        logger.LogInformation("This is a logging message with args: Today is {Week}. It is {Time}.",
                              DateTime.Now.DayOfWeek, DateTime.Now.ToLongTimeString());
        logger.LogInformation($"This is a logging message with string concatenation: Today is {DateTime.Now.DayOfWeek}. It is {DateTime.Now.ToLongTimeString()}.");
        return Ok("This is to test the difference between structured logging and string concatenation.");
    }

    [HttpGet]
    [Route("print-base-directory")]
    public ActionResult PrintBaseDirectory()
    {
        // Lấy đường dẫn của AppDomain.CurrentDomain.BaseDirectory
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        // In đường dẫn ra console
        Console.WriteLine(baseDirectory);

        // Hoặc ghi log đường dẫn
        logger.LogInformation("AppDomain.CurrentDomain.BaseDirectory: {BaseDirectory}", baseDirectory);

        // Trả về kết quả
        return Ok($"Base Directory: {baseDirectory}");
    }
}
