using ApplicationCore.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyGuideAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IDataService _dataService;

        public AnswersController(IDataService dataService)
        {
            _dataService = dataService;

        }

        [HttpGet]
        [Route("answers")]
        public async Task<IActionResult> GetAnswers()
        {
            var answer = await _dataService.GetAllAnswers();
            return Ok(answer);
        }

        [HttpGet]
        [Route("answers/name/{name}")]
        public async Task<IActionResult> GetAnswerByName(string name)
        {
            var answer = await _dataService.GetAnswerByName(name);
            return Ok(answer);
        }

        [HttpGet]
        [Route("answers/id/{id}")]
        public async Task<IActionResult> GetAnswerById(int id)
        {
            var answer = await _dataService.GetAnswerById(id);
            return Ok(answer);
        }
    }
}
