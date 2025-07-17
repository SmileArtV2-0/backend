using SmileArtLab.Auth.Application.Interfaces;

namespace SmileArtLab.API.Middleware
{
    public class TenantMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context, ITenantService tenantService)
        {
            var tenantId = context.Request.Headers["X-TenantId"];
            if (!string.IsNullOrEmpty(tenantId))
            {
                context.Items["TenantId"] = tenantId;
                tenantService.TenantId = Guid.Parse(tenantId);
            }


            await next(context);
        }
    }
}
