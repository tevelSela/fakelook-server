using fakeLook_starter.Interfaces;
using fakeLook_models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace auth_example.Repositories
{
    public class UsersRepository : IRepository<User>
    {
        private List<User> _db;
        public UsersRepository()
        {
            _db = new List<User>() {
                new User() {
                    Name = "UserOne",
                    Id = Guid.NewGuid().ToString()
                    ,Password = "12345".GetHashCode().ToString() },
                new User() {
                    Name = "UserTwo",
                    Id = Guid.NewGuid().ToString()
                    ,Password = "12345".GetHashCode().ToString(),
                     }};
        }
        public User GetById(string id)
        {
            return _db.Where(user => user.Id == id).Single();
        }

        public User FindItem(User item)
        {
            item.Password = item.Password.GetHashCode().ToString();
            return _db.Where(user => user.Name == item.Name &&  user.Password == item.Password).SingleOrDefault();
        }

        public User Post(User item)
        {
            item.Id = Guid.NewGuid().ToString();
            item.Password = item.Password.GetHashCode().ToString();
            _db.Add(item);
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

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> GetByPredicate(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
