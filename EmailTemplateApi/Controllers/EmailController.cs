using Microsoft.AspNetCore.Mvc;
using EmailTemplateApi.Models;
using EmailTemplateApi.Services;

namespace EmailTemplateApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly OpenAiEmailService _emailService;

        public EmailController(OpenAiEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> GenerateEmail([FromBody] EmailRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Purpose) ||
                string.IsNullOrWhiteSpace(request.RecipientName) ||
                string.IsNullOrWhiteSpace(request.Tone))
            {
                return BadRequest("All fields are required");
            }

            var result = await _emailService.GenerateEmailAsync(request);
            return Ok(result);
        }
    }
}
