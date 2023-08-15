using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
		List<Blog> GetAll();
		Blog GetByID(int Id);
		void BlogAdd(Blog blog);
		void BlogDelete(Blog blog);
		void BlogUpdate(Blog blog);
        List<Blog> GetBlogListWithCategory();
		List<Blog> GetBlogByID(int Id);
        List<Blog> GetBlogListByWriter(int Id);
		List<Blog> GetLastThreePost();
	}
}
