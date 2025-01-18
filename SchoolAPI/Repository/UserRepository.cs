using SchoolAPI.Model;

namespace SchoolAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly StudentDBContext _dbContext;
        public UserRepository(StudentDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public User GetByUsername(string username)
        {
            return _dbContext.Users.Find(username);
        }

        public void Add(User user)
        {
            _dbContext.Users.Add(user);
        }
    }

}
