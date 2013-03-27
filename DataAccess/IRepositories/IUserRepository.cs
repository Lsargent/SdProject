using Logic;
using System;
using System.Linq.Expressions;

namespace DataAccess.IRepositories {
    public interface IUserRepository : IBaseRepository {
        User GetUser(int id);
        User GetUserWithIncludes(int id, params Expression<Func<User, object>>[] includes);
    }
}
