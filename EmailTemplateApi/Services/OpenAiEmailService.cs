using OpenAI;
using OpenAI.Chat;
using EmailTemplateApi.Models;

namespace EmailTemplateApi.Services
{
    public class OpenAiEmailService
    {
        private readonly ChatClient _chatClient;

        public OpenAiEmailService(IConfiguration configuration)
        {
            var apiKey = configuration["OpenAI:ApiKey"];
            var client = new OpenAIClient(apiKey);
            _chatClient = client.GetChatClient("gpt-4o-mini");
        }

        public async Task<EmailResponse> GenerateEmailAsync(EmailRequest request)
        {
            var startTime = DateTime.UtcNow;

            try
            {
                ChatMessage[] messages =
                {
                    ChatMessage.CreateSystemMessage(
                        "You generate short, professional, customer-friendly emails."
                    ),
                    ChatMessage.CreateUserMessage(
                        $"Purpose: {request.Purpose}\n" +
                        $"Recipient Name: {request.RecipientName}\n" +
                        $"Tone: {request.Tone}\n\n" +
                        "Write a short email."
                    )
                };

                var result = await _chatClient.CompleteChatAsync(messages);
                var emailText = result.Value.Content[0].Text;

                var endTime = DateTime.UtcNow;

                return new EmailResponse
                {
                    EmailBody = emailText,
                    ResponseTimeMs = (endTime - startTime).TotalMilliseconds
                };
            }
            catch
            {
                return new EmailResponse
                {
                    EmailBody = "Unable to generate email at this time.",
                    ResponseTimeMs = 0
                };
            }
        }
    }
}
