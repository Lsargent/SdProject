using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic {
    public class OperationStatus<TClass> : OperationStatus where TClass : class, new() {        
        public OperationStatus() {
            EffectedItems = new List<TClass>();
        }
        public List<TClass> EffectedItems { get; set; }       
    }
    public class  OperationStatus {
        public bool WasSuccessful { get; set; }
        public Exception Exception { get; set; }
    }
}
