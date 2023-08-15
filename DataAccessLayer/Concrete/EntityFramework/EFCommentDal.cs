using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EFCommentDal : EFEntityRepositoryBase<Comment, CoreBlogDbContext>, ICommentDal
    {
        public List<Comment> GetListWithBlog(Expression<Func<Comment, bool>> Filter = null)
        {
            using(CoreBlogDbContext context = new CoreBlogDbContext())
            {
                return Filter == null ? context.Comments.Include(x => x.Blog).ToList() : context.Comments.Include(x => x.Blog).Where(Filter).ToList();
            }
        }
    }
}
