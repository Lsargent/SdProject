using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;



    public class MaxRoomsAttribute : ValidationAttribute
    {
        public int maximumRooms { get; set; }

        public override bool IsValid(object value)
        {
            var rooms = (int)value;
            if (rooms >= maximumRooms)
                return false;

            return true;
        }

    }

