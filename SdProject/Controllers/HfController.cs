using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using DataAccess.Repositories;
using Logic;
using WebMatrix.WebData;

namespace SdProject.Controllers {
    public class HfController : Controller {
        private User _currentUser;

        public User CurrentUser {
            get {
                if (_currentUser == null && WebSecurity.CurrentUserId != 0) {
                    using (var userRepo = new UserRepository()) {
                        if (CurrentUserIncludes != null) {
                            _currentUser = userRepo.Get<User>(u => u.Id == WebSecurity.CurrentUserId, CurrentUserIncludes);
                        }
                        else {
                            _currentUser = userRepo.Get<User>(u => u.Id == WebSecurity.CurrentUserId);
                        }
                    }
                }
                return _currentUser;
            }
            private set { _currentUser = value; }
        }

        public Expression<Func<User, object>>[] CurrentUserIncludes { get; set; }

        public void SetCurrentUserWithIncludes(params Expression<Func<User, object>>[] includes) {
            CurrentUserIncludes = includes;
            CurrentUser = null;
        }
    }
}