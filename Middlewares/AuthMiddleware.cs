namespace taskify.Middlewares
{



    public class UseAuthentication(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task Invoke(HttpContext context)
        {
            var user = context.User;
            if (user?.Identity?.IsAuthenticated == true && context?.Request?.Path != null && context.Request.Path.Value?.Contains("auth") == true)
            {
                context.Response.Redirect("/todo");
                return;
            }

            if (context != null)
            {

                await _next(context);

            }

        }

    }
}