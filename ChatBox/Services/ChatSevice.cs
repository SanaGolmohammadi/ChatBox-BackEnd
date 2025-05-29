using ChatBox.Dtos;
using ChatBox.Models;
using ChatBox.Response;
using Microsoft.EntityFrameworkCore;

namespace ChatBox.Services
{
    public class ChatService : IChatService
    {
        private readonly ChatDbContext _context;

        public ChatService(ChatDbContext context)
        {
            _context = context;
        }

        public async Task<BotResponseDto> SendMessageAsync(UserRequestDto request)
        {
            var userMessage = new Message
            {
                Box = request.Box,
                Sender = "user",
                SentAt = DateTime.Now
            };
            _context.Messages.Add(userMessage);

            string botReply = GetBotResponse(request.Box);

            var botMessage = new Message
            {
                Box = botReply,
                Sender = "bot",
                SentAt = DateTime.Now
            };
            _context.Messages.Add(botMessage);

            await _context.SaveChangesAsync();

            return new BotResponseDto { Box = botReply };
        }

        public async Task<List<MessageDto>> GetMessagesAsync()
        {
            return await _context.Messages
                .OrderBy(m => m.SentAt)
                .Select(m => new MessageDto
                {
                    Box = m.Box,
                    Sender = m.Sender,
                    SentAt = m.SentAt
                })
                .ToListAsync();
        }

        private string GetBotResponse(string input)
        {
            if (Matches(input, RequestArrays.greetingRequest)) return GetRandomResponse(ChatResponses.greetingResponses);
            if (Matches(input, RequestArrays.howAreYouRequest)) return GetRandomResponse(ChatResponses.howAreYouResponses);
            if (Matches(input, RequestArrays.whatAreYouDoingRequest)) return GetRandomResponse(ChatResponses.whatAreYouDoingResponses);
            if (Matches(input, RequestArrays.nameRequest)) return GetRandomResponse(ChatResponses.nameResponses);
            if (Matches(input, RequestArrays.ageRequest)) return GetRandomResponse(ChatResponses.ageResponses);
            if (Matches(input, RequestArrays.girlfriendRequest)) return GetRandomResponse(ChatResponses.girlfriendResponses);
            if (Matches(input, RequestArrays.whereFromRequest)) return GetRandomResponse(ChatResponses.whereFromResponses);
            if (Matches(input, RequestArrays.hungryRequest)) return GetRandomResponse(ChatResponses.hungryResponses);
            if (Matches(input, RequestArrays.boredRequest)) return GetRandomResponse(ChatResponses.boredResponses);
            if (Matches(input, RequestArrays.jokeRequest)) return GetRandomResponse(ChatResponses.jokeResponses);
            if (Matches(input, RequestArrays.sleepyRequest)) return GetRandomResponse(ChatResponses.sleepyResponses);
            if (Matches(input, RequestArrays.skillsRequest)) return GetRandomResponse(ChatResponses.skillsResponses);
            if (Matches(input, RequestArrays.musicRequest)) return GetRandomResponse(ChatResponses.musicResponses);
            if (Matches(input, RequestArrays.tiredRequest)) return GetRandomResponse(ChatResponses.tiredResponses);
            if (Matches(input, RequestArrays.sadRequest)) return GetRandomResponse(ChatResponses.sadResponses);
            if (Matches(input, RequestArrays.goodNightRequest)) return GetRandomResponse(ChatResponses.goodNightResponses);
            if (Matches(input, RequestArrays.statusRequest)) return GetRandomResponse(ChatResponses.statusResponses);
            if (Matches(input, RequestArrays.loveRequest)) return GetRandomResponse(ChatResponses.loveResponses);
            if (Matches(input, RequestArrays.freeTimeRequest)) return GetRandomResponse(ChatResponses.freeTimeResponses);
            if (Matches(input, RequestArrays.badFeelingRequest)) return GetRandomResponse(ChatResponses.badFeelingResponses);

            return "متوجه منظورت نشدم 😅 دوباره بپرس!";
        }

        private bool Matches(string input, string[] patterns)
        {
            foreach (var pattern in patterns)
            {
                if (input.Trim() == pattern)
                    return true;
            }
            return false;
        }

        private string GetRandomResponse(string[] responses)
        {
            var rand = new Random();
            return responses[rand.Next(responses.Length)];
        }
    }
}
