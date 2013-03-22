﻿using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SdProject.Models
{
    public class HouseDisplayModel
    {
        public HouseDisplayModel(House house)
        {
            StreetAddress = house.StreetAddress;
            City = house.City;
            ZipCode = house.ZipCode;
            Style = house.Style;
            FloorSpace = house.FloorSpace;
            RoomCount = house.RoomCount;
            StoryCount = house.StoryCount;
            Bedrooms = house.Bedrooms;
            Bathrooms = house.Bathrooms;
            HeatingType = house.HeatingType;
            Extras = house.Extras;
        }

        public string StreetAddress { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public string Style { get; set; }
        public double FloorSpace { get; set; }
        public int RoomCount { get; set; }
        public int StoryCount { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public string HeatingType { get; set; }
        public string Extras { get; set; }

        public class EnterInfo
        {
            public int maximumRooms{get; set;}

            [Display(Name = "Street Address")]
            public string streetAddress { get; set; }

            [Required(ErrorMessage= "Name of city required.")]
            [Display(Name = "City*")]
            public string city { get; set; }

            [Required(ErrorMessage = "Zip code required.")]
            [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Zip code must be five characters.")]
            [Display(Name = "Zip Code*")]
            public int zipCode { get; set; }

            [Required(ErrorMessage = "Type of house required.")]
            [Display(Name = "House Style (Ranch, Victorian, etc.)")]//should this be required?
            public string style { get; set; }

            [Required(ErrorMessage = "Square footage required.")]//Will they know this number?
            [Display(Name = "Square Footage (ft²)")]
            public double floorSpace { get; set; }

            [Required(ErrorMessage = "Number of rooms required.")]
            [Range (typeof(int), "1", "999")]
            [Display(Name = "Number of Rooms*")]
            public int roomCount { get; set; }

            [Required(ErrorMessage = "Number of floors required.")]
            [Range(typeof(int), "1", "999")]
            [Display(Name = "Number of Floors*")]
            public int storyCount { get; set; }

            [Required(ErrorMessage = "Number of bedrooms required.")]
            [RoomsValidator("roomCount", ErrorMessage="Number of bedrooms must be less than the total number of rooms in the house.")]
            [Display(Name = "Number of Bedrooms*")]
            public int bedrooms { get; set; }
            

            [Required(ErrorMessage = "Number of bathrooms required.")]
            [RoomsValidator("roomCount", ErrorMessage = "Number of bathrooms must be less than the total number of rooms in the house.")]
            [Display(Name = "Number of Bathrooms*")]
            public int bathrooms { get; set; }

            [Required(ErrorMessage = "Heat source type required.")] //should this be required?
            [Display(Name = "Heating Type*")]
            public string heatingType { get; set; }

            [Required(ErrorMessage = "Extra description required.")] //should this be required?
            [DataType(DataType.MultilineText)]
            [Display(Name = "Description/Extras*")]
            public string extras { get; set; }
        }
    }
}