using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;



namespace taskify.Middlewares
{
    public class UseAuthenticationMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {


            if (context.User.Identity.IsAuthenticated &&
                (context.Request.Path.Equals("/Auth/Login") || context.Request.Path.Equals("/Auth/Signup")))
            {
                context.Response.Redirect("/Todo");
                return;
            }

            await next(context);
        }
    }
}
