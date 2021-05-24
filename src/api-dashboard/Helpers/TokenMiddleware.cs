using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAProjetct.API.Helpers
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault().Split(":").Last();

                if (token != null)
                    adicionarTokenNoContext(context, token);
            }

            await _next(context);
        }

        private void adicionarTokenNoContext(HttpContext context, string token)
        {
            context.Items["Token"] = token;
        }
    }
}
