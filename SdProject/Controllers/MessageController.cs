using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using Logic;
using SdProject.Models.MessageModels;
using WebMatrix.WebData;

namespace SdProject.Controllers
{
    [Authorize]
    public class MessageController : Controller {
        private IMessageRepository messageRepo = new MessageRepository();
        private IUserRepository userRepo = new UserRepository();

        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateMessageModel message) {
            if (ModelState.IsValid) {
                var user = userRepo.GetUser(WebSecurity.CurrentUserId);
                var newMessage = new Message {
                    MessageBody = message.MessageBody,
                    Subject = message.Subject,
                    History = new List<OwnedEntityChange>(),
                    Owners = new List<User> { user }
                };
                var opStatus = messageRepo.AddMessage(newMessage);
                if (opStatus.WasSuccessful) {
                    newMessage = opStatus.EffectedItems.First();
                    newMessage.History.Add(new OwnedEntityChange {
                        Editedby = user,
                        EditedOn = DateTime.Now,
                        IpAddress = HttpContext.Request.UserHostAddress,
                        UserAgent = HttpContext.Request.UserAgent,
                        OwnedEntity = newMessage,
                        Entity = newMessage,
                    });
                    messageRepo.UpdateMessage(newMessage);
                }
            }
            return RedirectToAction("Listing");
        }

        public ActionResult Listing() {
            var messages = messageRepo.Messages.Select(message => new MessageModel {Message = message} ).ToList();
            var model = new MessageListingModel {Messages = messages};
            return View(model);
        }

    }
}
