using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using SdProject.Models.MessageModels;

namespace SdProject.Controllers
{
    public class MessageController : Controller {
        private IMessageRepository messageRepo = new MessageRepository();
        
        public ActionResult MessageListing() {
            var messages = messageRepo.Messages.Select(message => new MessageModel() {Message = message}).ToList();
            var model = new MessageListingModel() {Messages = messages};
            return View();
        }

    }
}
