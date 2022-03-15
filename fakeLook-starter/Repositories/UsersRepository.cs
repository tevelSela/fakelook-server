using fakeLook_starter.Interfaces;
using fakeLook_models.Models;
using fakeLook_dal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeLook_starter.Repositories
{
    public class UsersRepository : IUserRepository
    {
        readonly private DataContext _db;
        public UsersRepository(DataContext context)
        {
            _db = context;
        }
        public User GetById(string id)
        {
            return _db.Users.SingleOrDefault(p => p.Id.ToString().Equals(id));
        }

        public User FindItem(User item)
        {
            item.Password = item.Password.GetHashCode().ToString();
            return _db.Users.Where(user =>  user.Name == item.Name && user.Password == item.Password).SingleOrDefault();
        }

        public User Post(User item)
        {
            item.Password = item.Password.GetHashCode().ToString();
            _db.Add(item);
            _db.SaveChanges();
            return item;
        }

        public Task<User> Add(User item)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> Edit(User item)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> GetByPredicate(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            return _db.Users.SingleOrDefault(u=>u.Name == username && u.Password == password);
        }
    }
}
