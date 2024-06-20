using Application.Interfaces;
using System.Security.Claims;

namespace WebAPI.Service
{
    public class ClaimServices :IClaimsService
    {
        public ClaimServices(IHttpContextAccessor httpContextAccessor)
        {
            var Id = httpContextAccessor.HttpContext?.User?.FindFirstValue("Id");
            GetCurrentUserId = string.IsNullOrEmpty(Id) ? 0 : Convert.ToInt32(Id);
        }

        public int GetCurrentUserId { get; }
    }
}
