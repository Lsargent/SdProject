﻿using System;
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

namespace SdProject.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class MessageController : Controller {

        [HttpGet]
        public PartialViewResult Create() {
            return PartialView("_Create");
        }

        [HttpPost]
        public ActionResult Create(CreateMessageModel message) {
            if (ModelState.IsValid) {
                User user;
                using (var userRepo = new UserRepository()) {
                     user = userRepo.GetUser(WebSecurity.CurrentUserId);
                }

                var newMessage = new Message(message.Subject,message.MessageBody, new OwnedEntityParams(Request, user));
                using (var messageRepo = new MessageRepository()) {
                    messageRepo.AddMessage(newMessage);
                }
            }
            return RedirectToAction("Listing");
        }

        public ActionResult Listing() {
            List<MessageModel> messages;
            using (var messageRepo = new MessageRepository()) {
                messages = messageRepo.Messages.Select(message => new MessageModel {Message = message}).ToList();
            }
            var model = new MessageListingModel {Messages = messages};
            return View(model);
        }

    }
}
