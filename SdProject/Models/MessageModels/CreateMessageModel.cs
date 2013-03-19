﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SdProject.Models.MessageModels {
    public class CreateMessageModel {
        [Required]
        public string Subject { get; set; }
        [Required]
        public string MessageBody { get; set; }
    }
}