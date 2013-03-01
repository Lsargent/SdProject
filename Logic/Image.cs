namespace Logic {
    public class Image {
        public int Id { get; set; }

        public string Url { get; set; }

        public virtual OwnedEntity OEntity { get; set; }
    }
}