using System;
using System.Text.Json.Serialization;

namespace PWeb.Shared
{
    public class Message
    {
        [JsonConstructor]
        public Message(string messageId, string user, string message)
        {
            this.messageId = messageId;
            this.user = user;
            this.message = message;
        }

        public Message(string user, string message)
        {
            messageId = Guid.NewGuid().ToString();
            this.user = user;
            this.message = message;
        }
        
        public string messageId { get; set; }
        public string user { get; set; }
        public string message { get; set; }
        
    }
}
