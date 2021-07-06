using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PWeb.Server.Services;
using PWeb.Shared;

namespace PWeb.Server.Controllers
{
    [Route("api/chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ChatService _chatService;

        public ChatController(ChatService chatService)
        {
            _chatService = chatService;
        }

        // GET: api/values
        [HttpGet]
        public ActionResult<List<Message>> Get()
        {
           return _chatService.Get();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetMessage")]
        public ActionResult<Message> Get(string messageId)
        {
            var message = _chatService.Get(messageId);

            if(message == null)
            {
                return NotFound();
            }

            return message;
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Message> Post(Message message)
        {
            _chatService.Create(message);

            return message;
        }
    }
}
