using System.ComponentModel.DataAnnotations.Schema;

namespace Logic {
    public class Image : IObjectState {
        public int Id { get; set; }

        public string Url { get; set; }

        public virtual OwnedEntity OEntity { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}