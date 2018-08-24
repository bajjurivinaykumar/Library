namespace Library.Services
{
    public interface IAuthorizationService
    {
        bool Authorize(string userType, string permission);

        void ReadXML();
    }
}