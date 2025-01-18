namespace SchoolAPI.Service
{
    public interface IAuthService
    {
        string GenerateToken(string username);
        bool ValidateUser(string username, string password);
        void RegisterUser(string username, string password, string email);

    }

}
