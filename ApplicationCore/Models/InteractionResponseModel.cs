using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class InteractionResponseModel
    {
        public int Id { get; set; }

        public string QuestionName { get; set; }

        public string AnswerName { get; set; }

        public string? IntType { get; set; }

        public DateTime? IntDate { get; set; }

        public string? Comments { get; set; }
    }
}
