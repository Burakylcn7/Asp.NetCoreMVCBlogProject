using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetAll();
        Comment GetByID(int Id);
        void CommentAdd(Comment comment);
        void CommentDelete(Comment comment);
        void CommentUpdate(Comment comment);
        List<Comment> GetCommentByID(int Id);
        List<Comment> GetCommentWithBlog();
    }
}
