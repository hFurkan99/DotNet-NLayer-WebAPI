using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace App.Services.ExceptionHandlers;

public class CriticalExceptionHandler() : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        // Business Logic
        if (exception is CriticalException)
        {
            Console.WriteLine("Hata ile sms gönderildi.");
        }

        return ValueTask.FromResult(false);
    }
}
