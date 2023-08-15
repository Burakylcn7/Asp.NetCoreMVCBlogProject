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
    public class MessageManager : IMessageService
    {
        private IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetAll()
        {
            return _messageDal.GetAll();
        }

        public Message GetByID(int Id)
        {
            return _messageDal.GetByID(Id);
        }

        public List<Message> GetInboxListByWriter(int Id)
        {
            return _messageDal.GetListWithMessageByWriter(x => x.ReceiverID == Id);
        }

        public List<Message> GetSendboxListByWriter(int Id)
        {
            return _messageDal.GetListWithMessageByWriter(x =>x.SenderID == Id);
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Add(message);
        }
    }
}
