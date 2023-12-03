using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Hosting;
using Services;
using System;
using System.Threading.Tasks;

namespace MyFirstWebApiProject.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware
    {
        private readonly RequestDelegate _next;
        private IRatingService _ratingService;

        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IRatingService ratingService)
        {
            _ratingService = ratingService;

            Rating rating = new Rating();
            rating.Host = httpContext.Request.GetDisplayUrl();
            rating.Method = httpContext.Request.Method;
            rating.Path = httpContext.Request.Path;
            rating.Referer = httpContext.Request.Host.ToString();
            rating.UserAgent = httpContext.Request.Headers.UserAgent;
            rating.RecordDate = DateTime.Now;
            
           await _ratingService.AddRatingAsync(rating);

//            •	HOST - כתובת האתר בה אנו גולשים כעת
//•	METHOD - המתודה אליה נגשנו)
//•	[PATH] URL ה-אליו בוצעה הפניה
//•	REFERER - הדף ממנו התבצעה הפניה
//•	USER_AGENT - מכיל את שם הדפדפן, גירסתו, מערכת ההפעלה ושפתה
//•	RECORD_DATE

            _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
