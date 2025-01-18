using SchoolAPI.Model;

namespace SchoolAPI.Repository
{
    public interface IUserRepository
    {
        User GetByUsername(string username);
        void Add(User user);
    }
}
