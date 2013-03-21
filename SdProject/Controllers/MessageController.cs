using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using DataAccess.IRepositories;
using DataAccess.Repositories;
using Logic;
using SdProject.Filters;
using SdProject.Models.MessageModels;
using WebMatrix.WebData;
using SdProject.Models.MessageModels.EditMessageModels;

namespace SdProject.Controllers
{
    [Authorize]
    public class MessageController : Controller {

        [HttpGet]
        public ActionResult Create() {
            return (Request.IsAjaxRequest() ? (ActionResult)PartialView("_Create") : View("Create"));               
        }     
        
        [HttpPost]
        public ActionResult Create(CreateMessageModel message) {
            if (ModelState.IsValid) {
                User user;
                using (var userRepo = new UserRepository()) {
                     user = userRepo.GetUser(WebSecurity.CurrentUserId);
                }

                var newMessage = new Message(message.Subject,message.MessageBody,
                                    new OwnedEntity(user, ViewPolicy.Open,
                                        new OwnedEntityChange(Request, user)));
                using (var messageRepo = new MessageRepository()) {
                    messageRepo.InsertOrUpdate(newMessage);
                }
                return Listing(new List<int> { newMessage.Id });
            }
            return (Request.IsAjaxRequest() ? (ActionResult)PartialView("_Create", message) : View("Create", message));
        }

        public ActionResult Edit(int messageId) {
            EditMessageModel message;
            using (var messageRepo = new MessageRepository())
            {
                message = new EditMessageModel(messageRepo.GetMessage(messageId));
            }
            return View("_Edit", message);
        }

        public ActionResult EditMessageBody(int messageId) {
            if (Request.IsAjaxRequest())
            {
                EditMessageBodyModel message;
                using (var messageRepo = new MessageRepository())
                {
                    message = new EditMessageBodyModel(messageRepo.GetMessage(messageId));
                }
                return PartialView("_EditMessageBody", message);
            }
            return Edit(messageId);
        }
        
        [HttpPost]
        public ActionResult EditMessageBody(EditMessageBodyModel message) {
            User user = new UserRepository().GetUser(WebSecurity.CurrentUserId);
            if (ModelState.IsValid) {
                Message messageToUpdate;
                OperationStatus opStatus;
                using (var messageRepo = new MessageRepository())
                {
                    messageToUpdate = messageRepo.GetMessage(message.MessageId);
                    messageToUpdate.MessageBody = message.MessageBody;
                    messageToUpdate.OwnedEntity.AddEntityChange(new OwnedEntityChange(Request, user));
                    opStatus = messageRepo.InsertOrUpdate(messageToUpdate);
                }

                if (opStatus.WasSuccessful) { 
                    return Listing(new List<int> { messageToUpdate.Id });
                }
            }
            return PartialView("_EditMessageBody", message);
        }

        public ActionResult Listing(IList<int> messageIds) {
            List<DisplayMessageModel> messages;
            User user = new UserRepository().GetUser(WebSecurity.CurrentUserId);
            using (var messageRepo = new MessageRepository()) {
                messages = messageRepo.Messages.Where(message => messageIds.Any(id => id == message.Id)).ToList().Select(message => new DisplayMessageModel(message, user)).ToList();
            }
            var model = new MessageListingModel { Messages = messages };

            return (Request.IsAjaxRequest() ? (ActionResult)PartialView("_Listing", model) : View("Listing", model));
        }
    }
}
