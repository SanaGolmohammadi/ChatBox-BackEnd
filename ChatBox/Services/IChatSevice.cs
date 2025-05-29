using ChatBox.Dtos;

namespace ChatBox.Services
{
    public interface IChatService
    {
        Task<BotResponseDto> SendMessageAsync(UserRequestDto request);
        Task<List<MessageDto>> GetMessagesAsync();
    }
}
