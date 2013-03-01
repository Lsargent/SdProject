using System.ComponentModel.DataAnnotations.Schema;

namespace Logic {
    public class Address : IObjectState {
        public int Id { get; set; }

        public string StreetAddress { get; set; }

        public string StreetAddress2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public  virtual OwnedEntity OEntity { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}