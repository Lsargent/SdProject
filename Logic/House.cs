using System;

namespace Logic {
    public class House : BaseComponent {
        public virtual string HeatingType { get; set; }

        public virtual int StoryCount { get; set; }

        public virtual int RoomCount { get; set; }

        public virtual Double FloorSpace { get; set; }

        public virtual Address Address { get; set; }
    }
}