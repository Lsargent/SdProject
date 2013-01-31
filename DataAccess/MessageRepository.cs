using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace DataAccess {
    public class MessageRepository : RepositoryBase<SdDb>, IMessageRepository {
        public Message GetMessage(int id) {
            return GetMessage(message => message.Id == id);
        }

        public Message GetMessage(Expression<Func<Message, bool>> wherePredicate) {
            return Get<Message>(wherePredicate);
        }

        private IEnumerable<Message> _messages;
        public IEnumerable<Message> Messages {
            get { return _messages ?? (_messages = GetAll<Message>()); }
        }

        

        public IEnumerable<Message> GetMessages<TKey>(Func<Message, TKey> orderByPredicate) {
            return GetAllOrderedBy(orderByPredicate);
        }

        public void SaveMessage(Message message) {
            Context.Messages.Add(message);
            Context.SaveChanges();
        }
    }
}
