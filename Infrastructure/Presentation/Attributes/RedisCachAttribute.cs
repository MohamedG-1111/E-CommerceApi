using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.DependencyInjection;
using Services.Abstractions.Contracts;

namespace Presentation.Attributes
{
    public class RedisCachAttribute:ActionFilterAttribute
    {
        private readonly int timeToLive;

        public RedisCachAttribute(int TimeToLive = 5)
        {
            timeToLive = TimeToLive;
        }



        // If Data Not Exist, Get the Date and store in cach 
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Get Cach Service
            var Service = context.HttpContext.RequestServices.GetRequiredService<ICachServices>();
            var CachKey = CreateKey(context.HttpContext.Request);
            // Check Data 
            var CachValue = await Service.GetAsync(CachKey);
            // If Data Exist , Return 
            if (CachValue is not null)
            {
                context.Result = new ContentResult()
                {
                    Content = CachValue,
                    ContentType = "application/json",
                    StatusCode = StatusCodes.Status200OK

                };

                return;
            }
            var ExcutedContext= await next.Invoke();
            if(ExcutedContext.Result is OkObjectResult Result)
            {
                await Service.SetAsync(CachKey!, Result.Value!, TimeSpan.FromMinutes(timeToLive));
            }


        }

        private string CreateKey(HttpRequest request)
        {
            StringBuilder Key = new StringBuilder();
            Key.Append(request.Path);
            foreach (var item in request.Query.OrderBy(k=>k.Key))
            {
                Key.Append($"|{item.Key}{item.Value}");
            }
            return Key.ToString();
        }

        // context  ==> Deal with the current Request
        // Next     ==> Excute Next both Attribute orAction
    }
}
