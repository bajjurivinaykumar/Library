using Library.BusinessObjects.enums;

namespace Library.Services
{
    public interface IAuthorizationService
    {
        bool Authorize(UserType userType, string permission);
        
    }
}