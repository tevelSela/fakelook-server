using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fakeLook_models.Models
{
    public interface IPost
    {
        public double X_Position { get; set; }
        public double Y_Position { get; set; }
        public double Z_Position { get; set; }
        public DateTime toDate { get; set; }
        public DateTime fromDate { get; set; }
        public int[] UserIds { get; set; }
    }
    public class Post
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public string ImageSorce { get; set; }
        public double X_Position { get; set; }
        public double Y_Position { get; set; }
        public double Z_Position { get; set; }
        public DateTime Date { get; set; }

        /* EF Relations */
        public virtual ICollection<Like> Likes { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<UserTaggedPost> UserTaggedPost { get; set; }
    }

    public class QueryRequest: IPost
    {
        public double X_Position { get; set; }
        public double Y_Position { get; set; }
        public double Z_Position { get; set; }
        public DateTime toDate { get; set; }
        public DateTime fromDate { get; set; }
        public int[] UserIds { get; set; }
        public string[] tags { get; set; }
    }
}
