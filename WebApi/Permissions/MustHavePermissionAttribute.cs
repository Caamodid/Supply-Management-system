using Microsoft.AspNetCore.Authorization;

namespace WebApi.Permissions
{
    public class MustHavePermissionAttribute : AuthorizeAttribute
    {
        public MustHavePermissionAttribute(string feature, string action)
        {
            Policy = $"{feature}.{action}";
        }
    }
}
