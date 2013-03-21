using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SdProject.Models.MessageModels {
    public class CreateMessageModel {
        [Required(ErrorMessage = "Every message needs a subject")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "A message cannot be empty")]
        public string MessageBody { get; set; }
    }
}