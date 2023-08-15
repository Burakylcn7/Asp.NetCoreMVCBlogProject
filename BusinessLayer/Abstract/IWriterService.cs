using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
		List<Writer> GetAll();
		Writer GetByID(int Id);
		void WriterAdd(Writer writer);
		void WriterUpdate(Writer writer);
		List<Writer> GetWriterByID(int Id);
        List<Writer> GetByMail(string p);
    }
}
