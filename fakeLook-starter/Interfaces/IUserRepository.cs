using fakeLook_models.Models;

namespace fakeLook_starter.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public User GetByUsernameAndPassword(string username, string password);
    }
}
