using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeLook_starter.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        readonly private DataContext _context;

        public LikeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Like> Add(Like item)
        {
            var res = _context.Likes.Add(item);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Like> Delete(int id)
        {
            var like = GetById(id);
            _context.Likes.Remove(like);
            _context.SaveChangesAsync();
            return like;
        }

        public Task<Like> Edit(Like item)
        {
            throw new NotImplementedException();
        }

        public ICollection<Like> GetAll()
        {
            throw new NotImplementedException();
        }

        public Like GetById(int id)
        {
            return _context.Likes.SingleOrDefault(p => p.Id == id);
        }

        public ICollection<Like> GetByPredicate(Func<Like, bool> predicate)
        {
            return _context.Likes.Where(predicate).ToList();
        }

        public Like Post(Like item)
        {
            throw new NotImplementedException();
        }
    }
}
