using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Logic {
    public class Entity : IObjectState{
        public Entity() {}

        public Entity(EntityParams eParams) {
            History = new List<EntityChange> { new EntityChange(eParams.ChangeParams) };
        }

        public int Id { get; set; }

        public virtual EntityChange LastEdited { get; set; }

        public virtual EntityChange Created { get; set; }

        public virtual List<EntityChange> History { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }

    public class EntityParams {
        public EntityParams(HttpRequestBase request) {
            ChangeParams = new EntityChangeParams(request);
        }

        public EntityChangeParams ChangeParams { get; set; }
    }
}