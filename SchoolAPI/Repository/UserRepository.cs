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
            return _dbContext.Users.Where(x=>x.Username==username).FirstOrDefault();
        }

        public void Add(User user)
        {
            _dbContext.Users.Add(user);
        }
    }

}
