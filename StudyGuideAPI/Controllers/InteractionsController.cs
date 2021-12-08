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
    public class InteractionsController : ControllerBase
    {
        private readonly IDataService _dataService;

        public InteractionsController(IDataService dataService)
        {
            _dataService = dataService;

        }

        [HttpGet]
        [Route("interactions")]
        public async Task<IActionResult> GetInteractions()
        {
            var inters = await _dataService.GetAllInteractions();
            return Ok(inters);
        }

        [HttpGet]
        [Route("interactions/questionId/{questionId}")]
        public async Task<IActionResult> GetInteractionByQuestionId(int questionId)
        {
            var question = await _dataService.GetInteractionByQuestionId(questionId);
            return Ok(question);
        }

        [HttpGet]
        [Route("interactions/answerId/{answerId}")]
        public async Task<IActionResult> GetInteractionByAnswerId(int answerId)
        {
            var answer = await _dataService.GetInteractionByAnswerId(answerId);
            return Ok(answer);
        }

        [HttpGet]
        [Route("interactions/{id}")]
        public async Task<IActionResult> GetInteractionById(int id)
        {
            var question = await _dataService.GetInteractionById(id);
            return Ok(question);
        }

        [HttpGet]
        [Route("interactions/comments/question/{questionId}")]
        public async Task<IActionResult> GetCommentsByQuestionId(int questionId)
        {
            var question = await _dataService.GetCommentsByQuestionId(questionId);
            return Ok(question);
        }

        [HttpGet]
        [Route("interactions/comments/answer/{answerId}")]
        public async Task<IActionResult> GetCommentsByAnswerId(int answerId)
        {
            var answer = await _dataService.GetCommentsByAnswerId(answerId);
            return Ok(answer);
        }
    }
}
