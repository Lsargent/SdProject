using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Helpers {
    public static class ChangeTracker {
        public static T Set<T>(IObjectState obj, T oldValue, T newValue) where T : System.IEquatable<T> {
            if (obj.TrackingEnabled && (oldValue == null || (!oldValue.Equals(newValue)))) {               
                if (obj.ObjectState == ObjectState.Unchanged) {
                    obj.ObjectState = ObjectState.Modified;
                }
            }
            return newValue;
        }
        public static T? Set<T>(IObjectState obj, T? oldValue, T? newValue) where T : struct, System.IEquatable<T> {
            if (obj.TrackingEnabled && (oldValue.HasValue != newValue.HasValue || newValue.HasValue && oldValue.Value.Equals(newValue.Value))) {
                if (obj.ObjectState == ObjectState.Unchanged) {
                    obj.ObjectState = ObjectState.Modified;
                }
            }
            return newValue;
        }

        public static void AddToCollection<T>(IObjectState obj, ICollection<T> collection, T newValue) {           
            if (obj.TrackingEnabled && obj.ObjectState == ObjectState.Unchanged) {
                obj.ObjectState = ObjectState.Modified;
            }
            collection.Add(newValue);
        }
    }
}
