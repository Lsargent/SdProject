using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Logic;
using SdProject.Models.AddressModels;
using SdProject.Models.ImageModel;
using SdProject.Models.ImageModels;

namespace SdProject.Models.HouseModels {
    public class HousePreviewModel {
        public HousePreviewModel() {}

        public HousePreviewModel(House house) {
            HouseId = house.Id;
            RoomCount = house.RoomCount;
            Bedrooms = house.Bedrooms;
            Bathrooms = house.Bathrooms;
            Address = new AddressDisplayModel(house.Address);
            //if(house.BaseComponent.Images != null) {
            //    Image = new ImageDisplayModel(house.BaseComponent.Images.First());
            //}
            //default the image.
        }

        public int HouseId { get; set; }

        public AddressDisplayModel Address { get; set; }

        [DisplayName("Room Count")]
        public int RoomCount { get; set; }

        public int Bedrooms { get; set; }

        public int Bathrooms { get; set; }

        public int FloorSpace { get; set; }

        public ImageDisplayModel Image { get; set; }

        public string UpdateTargetId { get; set; }

    }
}