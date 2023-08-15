using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetAll();
        Message GetByID(int Id);
        void MessageAdd(Message message);
        List<Message> GetInboxListByWriter(int Id);
        List<Message> GetSendboxListByWriter(int Id);
    }
}
