using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Helpers {
    public static class ChangeTracker {
        public static T SetChange<T>(IObjectState obj, T oldValue, T newValue) where T : System.IEquatable<T> {
            if (oldValue == null || (!oldValue.Equals(newValue))) {
                
                if (obj.ObjectState == ObjectState.Unchanged) {
                    obj.ObjectState = ObjectState.Modified;
                }
                return newValue;
            }
            return oldValue;
        }
        public static T? SetChange<T>(IObjectState obj, T? oldValue, T? newValue) where T : struct, System.IEquatable<T> {
            if (oldValue.HasValue != newValue.HasValue || newValue.HasValue && oldValue.Value.Equals(newValue.Value)) {
                if (obj.ObjectState == ObjectState.Unchanged) {
                    obj.ObjectState = ObjectState.Modified;
                }
                return newValue;
            }
            return oldValue;
        }
    }
}
