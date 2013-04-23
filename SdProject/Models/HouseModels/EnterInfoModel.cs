using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SdProject.Models.HouseModels {
    public class EnterInfo {

        //public 
        public int houseId { get; set; }

        public int MaximumRooms { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "Name of city required.")]
        [Display(Name = "City*")]
        public string City { get; set; }

        [Required(ErrorMessage = "Zip code required.")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Zip code must be five characters.")]
        [Display(Name = "Zip Code*")]
        public int ZipCode { get; set; }

        [Required(ErrorMessage = "Type of house required.")]
        [Display(Name = "House Style (Ranch, Victorian, etc.)")]
        public string Style { get; set; }

        [Required(ErrorMessage = "Square footage required.")]
        [Display(Name = "Square Footage (ft²)")]
        public double FloorSpace { get; set; }

        [Required(ErrorMessage = "Number of rooms required.")]
        [Range(typeof(int), "1", "999")]
        [Display(Name = "Number of Rooms*")]
        public int RoomCount { get; set; }

        [Required(ErrorMessage = "Number of floors required.")]
        [Range(typeof(int), "1", "999")]
        [Display(Name = "Number of Floors*")]
        public int StoryCount { get; set; }

        [Required(ErrorMessage = "Number of bedrooms required.")]
        [RoomsValidator("RoomCount", ErrorMessage = "Number of bedrooms must be less than the total number of rooms in the house.")]
        [Display(Name = "Number of Bedrooms*")]
        public int Bedrooms { get; set; }

        [Required(ErrorMessage = "Number of bathrooms required.")]
        [RoomsValidator("RoomCount", ErrorMessage = "Number of bathrooms must be less than the total number of rooms in the house.")]
        [Display(Name = "Number of Bathrooms*")]
        public int Bathrooms { get; set; }

        [Required(ErrorMessage = "Heat source type required.")]
        [Display(Name = "Heating Type*")]
        public string HeatingType { get; set; }

        [Required(ErrorMessage = "Extra description required.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description/Extras*")]
        public string Extras { get; set; }
    }
}