﻿namespace Logic {
    public interface IObjectState {
        ObjectState ObjectState { get; set; }
        bool TrackingEnabled { get; set; }
    }
    public enum ObjectState {       
        Unchanged,
        Added,
        Modified,
        Deleted
    }
}
