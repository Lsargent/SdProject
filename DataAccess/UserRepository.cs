using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace DataAccess {
    public class UserRepository : RepositoryBase<SdDb> ,IUserRepository {
        public User GetUser(int id) {
            return Get<User>(user => user.Id == id);
        }
    }
}
