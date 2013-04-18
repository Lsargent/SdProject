using DataAccess.IRepositories;
using Logic;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace DataAccess.Repositories {
    public class UserRepository : RepositoryBase<SdDb> ,IUserRepository {
        public User GetUser(int id) {
            return Get<User>(user => user.Id == id);
        }
        public User GetUserWithIncludes(int id, params Expression<Func<User, object>>[] includes) {
            var userQuery = GetAll<User>().Where(user => user.Id == id);
            foreach(var include in includes) {
                userQuery = userQuery.Include(include);
            }
            return userQuery.FirstOrDefault();
        }
    }
}
