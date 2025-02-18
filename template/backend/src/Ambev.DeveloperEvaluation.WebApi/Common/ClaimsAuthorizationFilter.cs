namespace Ambev.DeveloperEvaluation.WebApi.Common;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

[AttributeUsage(AttributeTargets.Method)]
public class ClaimsAuthorizeAttribute : TypeFilterAttribute
{
    public ClaimsAuthorizeAttribute(string claimType, string claimValue) : base(typeof(ClaimsAuthorizationFilter))
    {
        Arguments = [claimType, claimValue];
    }
}

public class ClaimsAuthorizationFilter : IAuthorizationFilter
{
    private readonly string _claimType;
    private readonly string _claimValue;

    public ClaimsAuthorizationFilter(string claimType, string claimValue)
    {
        _claimType = claimType;
        _claimValue = claimValue;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;
        if (!user.HasClaim(c => c.Type == _claimType && c.Value == _claimValue))
        {
            context.Result = new ForbidResult();
        }
    }
}



