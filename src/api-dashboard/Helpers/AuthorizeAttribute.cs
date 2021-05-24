using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;

namespace WAProjetct.API.Helpers
{
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private const string _authenticationToken = "3a871d4a35134007bdcb74f5dbdd3e23";

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Items["Token"].ToString();

            if (string.IsNullOrEmpty(token) || !token.Equals(_authenticationToken))
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }

}
