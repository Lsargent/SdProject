using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic {
    public class House : IObjectState {
        public House() {}

        public House(Address address,string style, double floorSpace, int roomCount, int storyCount, int bedrooms, int bathrooms, string extras, BaseComponent baseComponent, string heatingType = "None") {
            TrackingEnabled = true;
            ObjectState = ObjectState.Added;
            Style = style;
            FloorSpace = floorSpace;
            RoomCount = roomCount;
            StoryCount = storyCount;
            HeatingType = heatingType;
            Bedrooms = bedrooms;
            Bathrooms = bathrooms;
            Extras = extras;
            BaseComponent = baseComponent;           
        }

        [Key]
        public int Id { get; set; }

        public Address Address { get; set; }

        [Required]
        public string Style { get; set; }

        [Required]
        public double FloorSpace { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int RoomCount { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int StoryCount { get; set; }

        [Required]
        public string HeatingType { get; set; }

        [Required]
        public int Bedrooms { get; set; }

        [Required]
        public int Bathrooms { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Extras { get; set; }

        [Required]
        public virtual BaseComponent BaseComponent { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        [NotMapped]
        public bool TrackingEnabled { get; set; }
    }
}