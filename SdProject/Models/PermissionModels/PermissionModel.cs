using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logic;
using Logic.Helpers;

namespace SdProject.Models {
    public class PermissionModel {

        public PermissionModel() {
            
        }

        public PermissionModel(OwnedEntity entity, User currentUser) {
            OwnedEntityId = entity.Id;
            Policy = entity.ViewPolicy;
            HasEditPermission = PermissionHelper.HasEditPermission(entity, currentUser);
        }

        public int OwnedEntityId { get; set; }

        public ViewPolicy Policy { get; set; }

        public bool HasEditPermission { get; set; }
    }
}