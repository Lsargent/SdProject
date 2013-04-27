using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Logic;
using Logic.Helpers;

namespace SdProject.Models.AddressModels {
    public class AddressModel {
        public AddressModel() {}

        public AddressModel(Address address, User currentUser) {
            AddressId = address.Id;
            StreetAddress = address.StreetAddress;
            StreetAddress2 = address.StreetAddress2;
            City = address.City;
            State = address.State;
            ZipCode = address.ZipCode;
            HasViewPermission = PermissionHelper.HasViewPermission(address.OwnedEntity, currentUser);
            HasEditPermisssion = PermissionHelper.HasEditPermission(address.OwnedEntity, currentUser);
        }

        public int AddressId { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Display(Name = "Street Address (Line 2)")]
        public string StreetAddress2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public bool HasViewPermission { get; set; }

        public bool HasEditPermisssion { get; set; }
    }
}