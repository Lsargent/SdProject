using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Logic;
using Logic.Helpers;

namespace SdProject.Models.MessageModels {
    public class MessageDisplayModel 
    {
        public MessageDisplayModel() {}

        public MessageDisplayModel(Message message, User currentUser) 
        {
            MessageId = message.Id;
            Author = message.OwnedEntity.OwnedHistory.First().EditedbyUser.UserName;
            Subject = message.Subject;
            MessageBody = message.MessageBody;
            Created = message.OwnedEntity.OwnedHistory.First().EditedOn;
            LastModified = message.OwnedEntity.OwnedHistory.Last().EditedOn;
            LastModifiedBy = message.OwnedEntity.OwnedHistory.Last().EditedbyUser.UserName;
            HasEditPermision = PermissionHelper.HasEditPermission(message.OwnedEntity, currentUser);
            HasViewPermision = PermissionHelper.HasViewPermission(message.OwnedEntity, currentUser);
        }
        public int MessageId { get; set; }

        public bool HasEditPermision { get; set; }

        public bool HasViewPermision { get; set; }

        public string LastModifiedBy { get; set; }

        public string Author { get; set; }

        public string Subject { get; set; }

        public string MessageBody { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastModified { get; set; }

        public string UpdateTargetId { get; set; }
    }
}