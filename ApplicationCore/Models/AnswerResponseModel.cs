using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class AnswerResponseModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Answers { get; set; }

        public string? Comments { get; set; }
    }
}
