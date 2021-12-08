using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class HeaderViewModel
    {
        public List<QuestionResponseModel> questionDropDown { get; set; }
        public List<AnswerResponseModel> answerDropDown { get; set; }
    }
}
