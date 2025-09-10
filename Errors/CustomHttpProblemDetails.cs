using Microsoft.AspNetCore.Mvc;
namespace OneHelper.Errors
{
    public class CustomHttpProblemDetails : ValidationProblemDetails
    {
        public CustomHttpProblemDetails(HttpContext context)
        {
            Title = "Bad Request";
            Status = StatusCodes.Status400BadRequest;
            Detail = "HTTP requests are not allowed. Please use HTTPS.";
            Instance = $"{context.Request.Path} ({context.TraceIdentifier})";

            Dictionary<string, string?> relevantHeaders = new Dictionary<string, string?>
            {
                {"Host", context.Request.Headers["Host"] },
                {"User-Agent", context.Request.Headers["UserAgent"] },
                {"X-Forwarded-Proto", context.Request.Headers["XForwarded-Proto"] },
                {"X-Forwarded-For", context.Request.Headers["XForwarded-For"] }
            };
            Extensions["headers"] = relevantHeaders;
        }
    }
}
