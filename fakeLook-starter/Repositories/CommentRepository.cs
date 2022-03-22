using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeLook_starter.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        readonly private DataContext _context;

        public CommentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Comment> Add(Comment item)
        {
            var res = _context.Comments.Add(item);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<UserTaggedComment> AddCommentTag(UserTaggedComment tag)
        {
            var res = _context.UserTaggedComments.Add(tag);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Comment> Delete(int id)
        {
            var comment = GetById(id);
            _context.Comments.Remove(comment);
            _context.SaveChangesAsync();
            return comment;
        }

        public Task<Comment> Edit(Comment item)
        {
            throw new NotImplementedException();
        }

        public ICollection<Comment> GetAll()
        {
            throw new NotImplementedException();
        }
        public ICollection<Comment> GetAll(int postId)
        {
            return _context.Comments.Where(c => c.PostId == postId).ToList();
        }
        public Comment GetById(int id)
        {
            return _context.Comments.SingleOrDefault(p => p.Id == id);
        }

        public ICollection<Comment> GetByPredicate(Func<Comment, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Comment Post(Comment item)
        {
            throw new NotImplementedException();
        }
    }
}
