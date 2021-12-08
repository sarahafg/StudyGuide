using ApplicationCore.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClientInformationSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IDataService _dataService;

        public QuestionsController(IDataService dataService)
        {
            _dataService = dataService;

        }

        [HttpGet]
        [Route("questions")]
        public async Task<IActionResult> GetQuestions()
        {
            var questions = await _dataService.GetAllQuestions();
            return Ok(questions);
        }

        [HttpGet]
        [Route("questions/name/{name}")]
        public async Task<IActionResult> GetQuestionByName(string name)
        {
            var question = await _dataService.GetQuestionByName(name);
            return Ok(question);
        }

        [HttpGet]
        [Route("questions/id/{id}")]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            var question = await _dataService.GetQuestionById(id);
            return Ok(question);
        }
    }
}
