using System.Collections.Generic;

namespace SdProject.Models.MessageModels 
{
    public class MessageListingModel 
    {
        public ICollection<DisplayMessageModel> Messages { get; set; }
    }
}