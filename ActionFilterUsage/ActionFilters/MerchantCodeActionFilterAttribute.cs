﻿using ActionFilterUsage.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilterUsage.ActionFilters
{
    public class MerchantCodeActionFilterAttribute : ActionFilterAttribute
    {
        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var key = "merchantCode";
            //GetData
            var merchantCode = context.RouteData.Values[key];

            //Set Data
            var baseRequest = context.ActionArguments
                            .FirstOrDefault(i => i.Value != null && typeof(MerchantBaseRequest)
                            .IsAssignableFrom(i.Value.GetType()));
            if (baseRequest.Value is not null)
            {
                var req = baseRequest.Value as MerchantBaseRequest;
                req.MerchantCode = merchantCode.ToString();
            }
            else
            {
                if (!context.ActionArguments.ContainsKey(key))
                    context.ActionArguments.Add(key, merchantCode);
                else
                    context.ActionArguments[key] = merchantCode;
            }


            await next();
            
        }
    }
}
