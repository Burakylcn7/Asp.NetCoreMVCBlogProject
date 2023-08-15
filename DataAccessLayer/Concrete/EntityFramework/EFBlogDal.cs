using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EFBlogDal : EFEntityRepositoryBase<Blog, CoreBlogDbContext>, IBlogDal
    {
        public List<Blog> GetListWithCategory(Expression<Func<Blog, bool>> Filter = null)
        {
            using(CoreBlogDbContext context = new CoreBlogDbContext()) 
            {
                return Filter == null ? context.Blogs.Include(x => x.Category).ToList() : context.Blogs.Include(x => x.Category).Where(Filter).ToList();
            }
        }
    }
}
