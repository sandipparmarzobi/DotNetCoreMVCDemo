using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DotNetCoreMVCDemo.Models;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Globalization;

namespace DotNetCoreMVCDemo.Middleware
{
    public class MyMiddleware 
    {
        private readonly RequestDelegate _next;

        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var cultureQuery = context.Request.Query["culture"];
            if (!string.IsNullOrWhiteSpace(cultureQuery))
            {
                var culture = new CultureInfo(cultureQuery);

                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }

            // Call the next delegate/middleware in the pipeline.
            await _next(context);
        }
    }

    //public static class MiddlewareExtensions
    //{
    //    public static IApplicationBuilder UseMyMiddleware(
    //        this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<MyMiddleware>();
    //    }
    //}
}
