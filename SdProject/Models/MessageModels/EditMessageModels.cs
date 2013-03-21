using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SdProject.Models.MessageModels.EditMessageModels
{
    public class EditMessageModel
    {
        public EditMessageModel() {}
        public EditMessageModel(Message message) {
            MessageId = message.Id;
            Subject = message.Subject;
            MessageBody = message.MessageBody;
        }
        [Required]
        public int MessageId { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string MessageBody { get; set; }
    }

    public class EditMessageBodyModel {
        public EditMessageBodyModel() {}
        public EditMessageBodyModel(Message message) {
            MessageId = message.Id;
            MessageBody = message.MessageBody;
        }
        public EditMessageBodyModel(EditMessageModel message) {
            MessageId = message.MessageId;
            MessageBody = message.MessageBody;
        }

        [Required]
        public int MessageId { get; set; }
        [Required]
        public string MessageBody { get; set; }
    }
}