using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SdProject.CustomValidators;

namespace SdProject.Models.ImageModels
{
    public class UploadImageModel
    {
        [FileSize(702400)]
        [FileTypes("jpg,jpeg,png")]
        public HttpPostedFileBase File { get; set; }
    }
}
