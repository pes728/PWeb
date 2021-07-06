using System;
using MongoDB.Bson.Serialization.Attributes;
using PWeb.Shared;

namespace PWeb.Server.Models
{
    public class MessageData
    {
        public MessageData(Message message)
        {
            messageId = message.messageId.ToString();
            user = message.user;
            this.message = message.message;
        }

        [BsonId]
        public string messageId { get; set; }
        public string user { get; set; }
        public string message { get; set; }

        public Message ToMessage()
        {
            return new Message(messageId, user, message);
        }
    }
}
