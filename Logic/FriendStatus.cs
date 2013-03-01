using System.ComponentModel.DataAnnotations.Schema;

namespace Logic {
    public class FriendStatus : IObjectState {
        public int Id { get; set; }

        public string Value { get; set; }

        public virtual Entity Entity { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}