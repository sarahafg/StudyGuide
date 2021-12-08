using ApplicationCore.Models;
using ApplicationCore.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudyGuideMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StudyGuideMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataService _dataService;

        public HomeController(IDataService dataService)
        {
            _dataService = dataService;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            InteractionPageViewModel intModel = new InteractionPageViewModel { header = new HeaderViewModel() };
            intModel.header.questionDropDown = await _dataService.GetAllQuestions();
            intModel.header.answerDropDown = await _dataService.GetAllAnswers();
            if (!intModel.header.questionDropDown.Any())
            {
                return View(intModel);
            }
            return View(intModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
