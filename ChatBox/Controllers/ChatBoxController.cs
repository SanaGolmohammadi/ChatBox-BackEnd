using ChatBox.Dtos;
using ChatBox.Models;
using ChatBox.Response;
using ChatBox.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatBoxController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatBoxController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] UserRequestDto request)
        {
            var response = await _chatService.SendMessageAsync(request);
            return Ok(new BotResponseDto { Box = response.Box });
        }

        [HttpGet("messages")]
        public async Task<IActionResult> GetMessages()
        {
            var allMessages = await _chatService.GetMessagesAsync();
            return Ok(allMessages);
        }
    }
}
