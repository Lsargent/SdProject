using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Logic.Helpers;

namespace Logic {
    public class Address : IObjectState, IEquatable<Address> {
        

        public Address() {}

        public Address(string streetAddress, string streetAddress2, string city, string state, string zipCode,
                             OwnedEntity ownedEntity) {
            TrackingEnabled = true;
            ObjectState = ObjectState.Added;          
            StreetAddress = streetAddress;
            StreetAddress2 = streetAddress2;
            City = city;
            State = state;
            ZipCode = zipCode;
            OwnedEntity = ownedEntity;           
        }

        #region Backing Fields
        private string _streetAddress;
        private string _streetAddress2;
        private string _city;
        private string _state;
        private string _zipCode;
        private OwnedEntity _ownedEntity;
        #endregion

        [Key]
        public int Id { get; set; }
        
        [Required]
        public string StreetAddress {
            get { return _streetAddress; }
            set { _streetAddress = ChangeTracker.Set(this, StreetAddress, value); }
        }

        public string StreetAddress2 {
            get { return _streetAddress2; }
            set { _streetAddress2 = ChangeTracker.Set(this, StreetAddress2, value); }
        }

        [Required]
        public string City {
            get { return _city; }
            set { _city = ChangeTracker.Set(this, City, value); }
        }

        [Required]
        public string State {
            get { return _state; }
            set { _state = ChangeTracker.Set(this, State, value); }
        }

        [Required]
        public string ZipCode {
            get { return _zipCode; }
            set { _zipCode = ChangeTracker.Set(this, ZipCode, value); }
        }

        [Required]
        public  virtual OwnedEntity OwnedEntity {
            get { return _ownedEntity; }
            set { _ownedEntity = ChangeTracker.Set(this, OwnedEntity, value); }
        }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        [NotMapped]
        public bool TrackingEnabled { get; set; }

        public bool Equals(Address other) {
            return Id == other.Id;
        }
    }
}