using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SdProject.Models.HouseModels;
using SdProject.Models.ImageModels;

namespace SdProject.Models.AccountModels 
{
    public class AccountDisplayModel 
    {
        public User User { get; set; }
        public List<HouseDisplayModel> Houses { get; set; }
        public AccountDisplayModel(IEnumerable<User> users, User currentUser){
            Users = users.Select(u => new ProfilePreviewModel(u)).ToList();
            User = currentUser;
            //Images = Users.Images.Select(i => new ImageDisplayModel(i)).ToList();
        }

    public ICollection<ProfilePreviewModel> Users { get; set; }
    public ICollection<ImageDisplayModel> Images { get; set; }

    }
    
}