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
	public class WriterManager : IWriterService
	{
		private IWriterDal _writerDal;

		public WriterManager(IWriterDal writerDal)
		{
			_writerDal = writerDal;
		}

		public List<Writer> GetAll()
		{
			return _writerDal.GetAll();
		}

		public Writer GetByID(int Id)
		{
			return _writerDal.GetByID(Id);
		}

        public List<Writer> GetByMail(string p)
        {
			return _writerDal.GetAll(x => x.WriterMail==p);
        }

        public List<Writer> GetWriterByID(int Id)
        {
            return _writerDal.GetAll(x => x.WriterID == Id);
        }

        public void WriterAdd(Writer writer)
		{
			_writerDal.Add(writer);
		}

        public void WriterUpdate(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
