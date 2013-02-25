namespace Logic {
    public class Address : OwnedEntity {
        public virtual string StreetAddress { get; set; }

        public virtual string StreetAddress2 { get; set; }

        public virtual string City { get; set; }

        public virtual string State { get; set; }

        public virtual string ZipCode { get; set; }
    }
}