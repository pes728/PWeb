using System;
using System.Collections.Generic;
using MongoDB.Driver;
using PWeb.Server.Models;
using PWeb.Shared;

namespace PWeb.Server.Services
{
    public class ChatService
    {
        private readonly IMongoCollection<MessageData> _messages;

        public ChatService(IChatDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _messages = database.GetCollection<MessageData>(settings.ChatCollectionName);
        }

        public List<Message> Get()
        {
            List<MessageData> messageData = _messages.Find(message => true).ToList();
            List<Message> messages = new(messageData.Count);
            foreach(MessageData data in messageData)
            {
                messages.Add(data.ToMessage());
            }
            return messages;
        }

        public Message Get(string messageId) => _messages.Find(message => message.messageId == messageId).FirstOrDefault().ToMessage();


        public Message Create(Message message)
        {
            MessageData data = new MessageData(message);
            _messages.InsertOne(data);
            return message;
        }
    }
}
