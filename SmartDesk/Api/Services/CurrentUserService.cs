using Application.Interfaces;

namespace Api.Services
{
    public class CurrentUserService(IHttpContextAccessor accessor) : ICurrentUserService
    {
        public Guid? userId 
        { 
            get
            {
                var claim = accessor.HttpContext?.User?.FindFirst("userId");
                if (claim != null && Guid.TryParse(claim.Value, out Guid userID))
                {
                    return userID;
                }
                return null;
            }

        }
    }
}
