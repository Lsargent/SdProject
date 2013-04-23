using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Logic.Helpers;

namespace Logic {
    public class Entity : IObjectState, IEquatable<Entity> {    
 
        public Entity() {
        }

        public Entity(EntityChange entityChange) {
            TrackingEnabled = true;
            ObjectState = ObjectState.Added;
            History = new List<EntityChange>();
            AddEntityChange(entityChange);          
        }

        #region Backing Fields

        #endregion

        [Key]
        public int Id { get; set; }

        public virtual ICollection<EntityChange> History { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }

        [NotMapped]
        public bool TrackingEnabled { get; set; }


        public void AddEntityChange(EntityChange change) {
            ChangeTracker.AddToCollection(this, History, change);
        }

        public bool Equals(Entity other) {
            return Id == other.Id;
        }
    }
}