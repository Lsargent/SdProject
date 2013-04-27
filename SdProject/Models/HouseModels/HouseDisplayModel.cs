using System;
using System.ComponentModel.DataAnnotations;
using Logic;
using System.Web;
using SdProject.CustomValidators;

namespace SdProject.Models.HouseModels {
    public class HouseDisplayModel {
        public HouseDisplayModel(House house) {
            houseId = house.Id;
            StreetAddress = house.Address.StreetAddress;
            City = house.Address.City;
            ZipCode = Convert.ToInt32(house.Address.ZipCode);
            State = house.Address.State;
            Style = house.Style;
            FloorSpace = house.FloorSpace;
            RoomCount = house.RoomCount;
            StoryCount = house.StoryCount;
            Bedrooms = house.Bedrooms;
            Bathrooms = house.Bathrooms;
            HeatingType = house.HeatingType;
            Extras = house.Extras;
        }

        public HouseDisplayModel()
        {

        }

        public int houseId { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Style { get; set; }
        public double FloorSpace { get; set; }
        public int RoomCount { get; set; }
        public int StoryCount { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public string HeatingType { get; set; }
        public string Extras { get; set; }
    }
  
    public class UploadImageModel
    {
        [FileSize(10240)]
        [FileTypes("jpg,jpeg,png")]
        public HttpPostedFileBase File { get; set; }
    }

}