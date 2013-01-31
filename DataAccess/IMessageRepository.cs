using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Logic;

namespace DataAccess {
    public interface IMessageRepository {
        Message GetMessage(int id);
        Message GetMessage(Expression<Func<Message, bool>> wherePredicate);
        IEnumerable<Message> Messages { get; }
        IEnumerable<Message> GetMessages<TKey>(Func<Message, TKey> orderByPedicate);
        void SaveMessage(Message message);
    }
}
