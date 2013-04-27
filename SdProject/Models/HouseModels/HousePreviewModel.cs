using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Logic;
using Logic.Helpers;
using SdProject.Models.AddressModels;
using SdProject.Models.ImageModels;

namespace SdProject.Models.HouseModels {
    public class HousePreviewModel {
        public HousePreviewModel() {}

        public HousePreviewModel(House house, User user) {
            HouseId = house.Id;
            RoomCount = house.RoomCount;
            Bedrooms = house.Bedrooms;
            Bathrooms = house.Bathrooms;
            Address = new AddressModel(house.Address, user);
            HasViewPermission = PermissionHelper.HasViewPermission(house.BaseComponent.OEntity, user);
            //if(house.BaseComponent.Images != null) {
            //    Image = new ImageDisplayModel(house.BaseComponent.Images.First());
            //}
            //default the image.
        }

        public int HouseId { get; set; }

        public AddressModel Address { get; set; }

        [DisplayName("Room Count")]
        public int RoomCount { get; set; }

        public int Bedrooms { get; set; }

        public int Bathrooms { get; set; }

        public int FloorSpace { get; set; }

        public ImageDisplayModel Image { get; set; }

        public string UpdateTargetId { get; set; }

        public bool HasViewPermission { get; set; }
    }
}