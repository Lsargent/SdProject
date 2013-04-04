using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Logic {
    public class Entity : IObjectState {
        

        public Entity() {
        }

        public Entity(EntityChange entityChange) {
            TrackingEnabled = true;
            ObjectState = ObjectState.Added;
            History = new List<EntityChange>();
            AddEntityChange(entityChange);
            
        }

        #region Backing Fields

        private bool _trackingEnabled;

        #endregion


        [Key]
        public int Id { get; set; }

        public virtual ICollection<EntityChange> History { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        [NotMapped]
        public bool TrackingEnabled {
            get { return _trackingEnabled; }
            set { _trackingEnabled = value; }
        }


        public void AddEntityChange(EntityChange change) {
            History.Add(change);
        }
    }
}