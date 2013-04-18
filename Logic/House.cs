using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Logic.Helpers;

namespace Logic {
    public class House : IObjectState, IEquatable<House> {
        
        public House() {}

        public House(Address address, string style, double floorSpace, int roomCount, int storyCount, int bedrooms, int bathrooms, string extras, BaseComponent baseComponent, string heatingType = "None") {
            TrackingEnabled = true;
            ObjectState = ObjectState.Added;
            AddressId = address.Id;
            Address = address;
            Style = style;
            FloorSpace = floorSpace;
            RoomCount = roomCount;
            StoryCount = storyCount;
            HeatingType = heatingType;
            Bedrooms = bedrooms;
            Bathrooms = bathrooms;
            Extras = extras;
            BaseComponentId = baseComponent.Id;
            BaseComponent = baseComponent;
            OwnerId = address.OwnedEntity.UserOwnedEntities.FirstOrDefault().UserId;
        }

        #region Backing Fields
        private Address _address;
        private string _style;
        private double _floorSpace;
        private int _roomCount;
        private int _storyCount;
        private string _heatingType;
        private int _bedrooms;
        private int _bathrooms;
        private string _extras;
        private BaseComponent _baseComponent;
        private int _baseComponentId;
        private int _addressId;

        #endregion


        [Key]
        public int Id { get; set; }

        public int AddressId {
            get { return _addressId; }
            set { _addressId = ChangeTracker.Set(this, AddressId, value); }
        }

        [ForeignKey("AddressId")]
        public Address Address {
            get { return _address; }
            set { _address = ChangeTracker.Set(this, Address, value); }
        }

        [Required]
        public string Style {
            get { return _style; }
            set { _style = ChangeTracker.Set(this, Style, value); }
        }

        [Required]
        public double FloorSpace {
            get { return _floorSpace; }
            set { _floorSpace = ChangeTracker.Set(this, FloorSpace, value); }
        }

        [Required]
        [Range(1, int.MaxValue)]
        public int RoomCount {
            get { return _roomCount; }
            set { _roomCount = ChangeTracker.Set(this, RoomCount, value); }
        }

        [Required]
        [Range(1,int.MaxValue)]
        public int StoryCount {
            get { return _storyCount; }
            set { _storyCount = ChangeTracker.Set(this, StoryCount, value); }
        }

        [Required]
        public string HeatingType {
            get { return _heatingType; }
            set { _heatingType = ChangeTracker.Set(this, HeatingType, value); }
        }

        [Required]
        public int Bedrooms {
            get { return _bedrooms; }
            set { _bedrooms = ChangeTracker.Set(this, Bedrooms, value); }
        }

        [Required]
        public int Bathrooms {
            get { return _bathrooms; }
            set { _bathrooms = ChangeTracker.Set(this, Bathrooms, value); }
        }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Extras {
            get { return _extras; }
            set { _extras = ChangeTracker.Set(this, Extras, value); }
        }

        public int BaseComponentId {
            get { return _baseComponentId; }
            set { _baseComponentId = ChangeTracker.Set(this, BaseComponentId, value); }
        }

        [ForeignKey("BaseComponentId")]
        public virtual BaseComponent BaseComponent {
            get { return _baseComponent; }
            set { _baseComponent = ChangeTracker.Set(this, BaseComponent, value); }
        }

        public int OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual User Owner { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        [NotMapped]
        public bool TrackingEnabled { get; set; }

        public bool Equals(House other) {
            return Id == other.Id;
        }
    }
}