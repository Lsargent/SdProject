using System.Collections.Generic;

namespace SdProject.Models.MessageModels 
{
    public class MessageListingModel 
    {
        public ICollection<MessageDisplayModel> Messages { get; set; }
    }
}