using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class QuestionResponseModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Questions { get; set; }

        public DateTime? AddedOn { get; set; }
    }
}
