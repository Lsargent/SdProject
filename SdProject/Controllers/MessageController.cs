using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using Logic;
using SdProject.Models.MessageModels;

namespace SdProject.Controllers
{
    public class MessageController : Controller {
        private IMessageRepository messageRepo = new MessageRepository();

        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateMessageModel message) {
            if (ModelState.IsValid) {
                var newMessage = new Message() {
                    MessageBody = message.MessageBody,
                    Created = DateTime.Now,
                    LastModified = DateTime.Now,
                    
                };
                messageRepo.AddMessage(newMessage);
                messageRepo.SaveMessages();
            }
            return RedirectToAction("Listing");
        }

        public ActionResult Listing() {
            var messages = messageRepo.Messages.Select(message => new MessageModel() {Message = message}).ToList();
            var model = new MessageListingModel() {Messages = messages};
            return View(model);
        }

    }
}
