using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logic;
using SdProject.Models.AccountModels;

namespace SdProject.Models.FriendshipModels {
    public class CreateFriendshipModel : FriendshipModel {
        public CreateFriendshipModel(IEnumerable<User> candidateUsers, User currentUser ) {
            CandidateUsers = candidateUsers.Select(u => new ProfilePreviewModel(u)).ToList();
            InitiatorId = currentUser.Id;
        }

        public ICollection<ProfilePreviewModel> CandidateUsers { get; set; }
    }
}