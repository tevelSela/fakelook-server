using fakeLook_models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeLook_starter.Interfaces
{
    public interface IRepository<T>
    {
        public Task<T> Add(T item);
        public ICollection<T> GetAll();
        public Task<T> Edit(T item);
        public T GetById(int id);
        public ICollection<T> GetByPredicate(Func<T, bool> predicate);
        public T Post(T item);
        public Task<T> Delete(int id);
    }
    public interface IUserRepository : IRepository<User>
    {

    }
    public interface IPostRepository : IRepository<Post>
    {

    }
    public interface ILikeRepository : IRepository<Like>
    {

    }
    public interface ICommentRepository : IRepository<Comment>
    {
        public Task<UserTaggedComment> AddCommentTag(UserTaggedComment tag);
    }
    public interface ITagRepository : IRepository<Tag>
    {

    }
}
