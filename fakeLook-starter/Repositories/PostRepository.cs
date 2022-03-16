using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeLook_starter.Repositories
{
    public class PostRepository : IPostRepository
    {
        readonly private DataContext _context;
        public PostRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Post> Add(Post item)
        {
            var res = _context.Posts.Add(item);
            await _context.SaveChangesAsync();
            return res.Entity;
        }
        public User Post(User item)
        {
            item.Password = item.Password.GetHashCode().ToString();
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }


        public async Task<Post> Edit(Post item)
        {
            var res = _context.Posts.Update(item);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public ICollection<Post> GetAll()
        {
            return _context.Posts.OrderByDescending(result=>result.Date).ToList();
        }

        public Post GetById(int id)
        {
            return _context.Posts.SingleOrDefault(p => p.Id == id);
        }

        public ICollection<Post> GetByPredicate(Func<Post,bool> predicate)
        {
            return _context.Posts.Where(predicate).ToList();
        }

        public Post Post(Post item)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> Delete(int id)
        {
            var post=GetById(id);
            _context.Posts.Remove(post);
            _context.SaveChangesAsync();
            return post;
        }
    }
}
