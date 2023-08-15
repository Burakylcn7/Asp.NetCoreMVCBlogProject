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
    public class EFMessageDal : EFEntityRepositoryBase<Message, CoreBlogDbContext> , IMessageDal
    {
        public List<Message> GetListWithMessageByWriter(Expression<Func<Message, bool>> Filter = null)
        {
            using (CoreBlogDbContext context = new CoreBlogDbContext())
            {
                return Filter == null ? context.Messages.Include(x => x.SenderWriter).Include(x => x.ReceiverWriter).ToList() : context.Messages.Include(x => x.SenderWriter).Include(x => x.ReceiverWriter).Where(Filter).ToList();
            }
        }
    }
}
