using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SdProject.Controllers
{
    public class AddressController : Controller
    {
        public ActionResult Display(int addressId) {
            //Return a view that displays an address given its Id.
            throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult Create() {
            //Return a view that contains the form required to create an address
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Create(object model) {
            //Take the form info supplied and use it to create a new address object.
            //Save the object to the database using a respository.
            //Replace the "object model" with the final model
            throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult Edit(int addressId) {
            //Using the addressId, populate the edit form and return it.
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Edit(object model) {
            //Replace the "object model" with the final model
            //Similar to the Create action except for update.
            throw new NotImplementedException();
        }
    }
}
