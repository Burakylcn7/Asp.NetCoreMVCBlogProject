using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void CommentAdd(Comment comment)
        {
            _commentDal.Add(comment);
        }

        public void CommentDelete(Comment comment)
        {
            _commentDal.Delete(comment);
        }

        public void CommentUpdate(Comment comment)
        {
            _commentDal.Update(comment);
        }

        public List<Comment> GetAll()
        {
            return _commentDal.GetAll();
        }

        public Comment GetByID(int Id)
        {
            return _commentDal.GetByID(Id);
        }

        public List<Comment> GetCommentByID(int Id)
        {
            return _commentDal.GetAll(x => x.BlogID == Id);
        }

        public List<Comment> GetCommentWithBlog()
        {
            return _commentDal.GetListWithBlog();
        }
    }
}
