using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;
using OpenAI_API.Models;

namespace Chatgpt.ASP.NET.Integration.Controllers
{
    [Route("bot/[controller]")]
    public class ChatController : Controller
    {
        private readonly OpenAIAPI _chatGPT;

        public ChatController(OpenAIAPI chatGPT)
        {
            _chatGPT = chatGPT;
        }

        [HttpGet()]
        public async Task<IActionResult> Chat([FromQuery(Name = "prompt")] string prompt)
        {
            var response = "";

            var completion = new CompletionRequest 
            { 
                Prompt = prompt, 
                Model = Model.DavinciText, 
                MaxTokens = 200
            };

            var result = await _chatGPT.Completions.CreateCompletionAsync(completion);
            result.Completions.ForEach(resultText => response += resultText);

            return Ok(response);   
        }
    }
}
