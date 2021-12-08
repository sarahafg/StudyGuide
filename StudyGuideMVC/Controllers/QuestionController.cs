using ApplicationCore.Models;
using ApplicationCore.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using StudyGuideMVC.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StudyGuideMVC.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IDataService _dataService;

        public QuestionController(IDataService dataService)
        {
            _dataService = dataService;

        }

        [HttpGet]
        public async Task<IActionResult> Index()

        {
            QuestionPageViewModel intModel = new QuestionPageViewModel { header = new HeaderViewModel() };
            intModel.header.questionDropDown = await _dataService.GetAllQuestions();
            intModel.header.answerDropDown = await _dataService.GetAllAnswers();
            if (intModel == null)
            {
                return View();
            }
            return View(intModel);
            //return View();
        }

        //[HttpGet]
        //public async Task<IActionResult> ClientList()

        //{

        //    InteractionPageViewModel intModel = new InteractionPageViewModel { header = new HeaderViewModel() };
        //    intModel.header.clientDropDown = await _dataService.GetAllClient();
        //    intModel.header.employeeDropDown = await _dataService.GetAllEmployee();
        //    if (intModel == null)
        //    {
        //        return View();
        //    }
        //    return View(intModel);
        //    //return View();
        //}

        public async Task<IActionResult> Privacy()
        {
            var questionCards = await _dataService.GetAllQuestions();
            if (!questionCards.Any())
            {
                return View();
            }
            return View(questionCards);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
