using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using Logic;
using Logic.Extensions;
using Logic.Helpers;
using SdProject.Models.AddressModels;
using SdProject.Models.FriendshipModels;
using SdProject.Models.HouseModels;
using SdProject.Models.ImageModels;

namespace SdProject.Models.AccountModels {
    public class ProfileModel {
        public ProfileModel() {}

        public ProfileModel(User profileUser, User requestingUser) {
            UserId = profileUser.Id;
            UserName = profileUser.UserName.ToTitleCase();
            Email = profileUser.Email;
            //PrimaryAddress = new AddressModel(profileUser.PrimaryAddress, requestingUser);
            Friends = profileUser.Friends.Select(f => new ProfileFriendshipModel(f, profileUser, requestingUser)).ToList();
            Houses = profileUser.Houses.Select(h => new HousePreviewModel(h, requestingUser)).ToList();
            Images = profileUser.Images.Select(i => new ImageDisplayModel(i)).ToList();
            HasViewPermision = PermissionHelper.HasProfileViewPermission(profileUser, requestingUser);
            HasEditPermision = PermissionHelper.HasProfileEditPermission(profileUser, requestingUser);
            IsProfileOwner = profileUser.Equals(requestingUser);
        }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public bool IsProfileOwner { get; set; }

        public bool HasViewPermision { get; set; }

        public bool HasEditPermision { get; set; }

        public AddressModel PrimaryAddress { get; set; }

        public ICollection<ProfileFriendshipModel> Friends { get; set; }

        public ICollection<HousePreviewModel> Houses { get; set; }

        public ICollection<ImageDisplayModel> Images { get; set; }
 
        public string ProfileHeading() {
            return IsProfileOwner ? ProfileName() + "r Profile" : ProfileName().ToTitleCase();
        }

        public string ProfileName() {
            return IsProfileOwner ? "You" : UserName;
        }
    }
}