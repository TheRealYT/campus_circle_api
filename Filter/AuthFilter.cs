using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace campus_circle_api.Filter;

public class AuthFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // responds error to the client
        // context.Result = new UnauthorizedResult();

        // send authorized user_id the route
        context.HttpContext.Items["user_id"] = Guid.NewGuid().ToString();
        base.OnActionExecuting(context);
    }
}