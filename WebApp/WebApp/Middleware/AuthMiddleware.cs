namespace App.Api.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AuthMiddleware> _logger;
        private readonly IConfiguration _configuration;

        public AuthMiddleware(RequestDelegate next, ILogger<AuthMiddleware> logger, IConfiguration configuration)
        {
            _next = next;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //we could use a constant for api-key header
            if(!context.Request.Headers.TryGetValue("api-key", out var providedApiKey))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("You must provide an API key in the header");
                return;
            }

            //we could use a constant for ApiKey
            if (!providedApiKey.Equals(_configuration.GetValue<string>("ApiKey")))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                _logger.LogWarning("Invalid API key provided");
                await context.Response.WriteAsync("You must provide a valid API key");
                return;
            }

            await _next(context);
        }
    }
}
