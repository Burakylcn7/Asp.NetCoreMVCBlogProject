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
	public class BlogManager : IBlogService
	{
		private IBlogDal _blogDal;
		public BlogManager(IBlogDal blogDal)
		{
			_blogDal = blogDal;
		}

		public void BlogAdd(Blog blog)
		{
			_blogDal.Add(blog);
		}

		public void BlogDelete(Blog blog)
		{
			_blogDal.Delete(blog);
		}

		public void BlogUpdate(Blog blog)
		{
			_blogDal.Update(blog);
		}

		public List<Blog> GetAll()
		{
			return _blogDal.GetAll();
		}

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

		public List<Blog> GetBlogByID(int Id)
		{
			return _blogDal.GetAll(x => x.BlogID == Id);
		}

		public Blog GetByID(int Id)
		{
			return _blogDal.GetByID(Id);
		}

        public List<Blog> GetBlogListByWriter(int Id)
        {
			return _blogDal.GetListWithCategory(x => x.WriterID == Id);
        }

		public List<Blog> GetLastThreePost()
		{
			return _blogDal.GetAll().TakeLast(3).ToList();
		}
	}
}
