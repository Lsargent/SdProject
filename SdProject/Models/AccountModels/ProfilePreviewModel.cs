using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logic;

namespace SdProject.Models.AccountModels {
    public class ProfilePreviewModel {
        public ProfilePreviewModel() {}

        public ProfilePreviewModel(User user) {
            UserId = user.Id;
            UserName = user.UserName;
        }

        public int UserId { get; set; }

        public string UserName { get; set; }
    }
}