using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Interaction
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public int AnswerId { get; set; }

        [MaxLength(1)]
        public string? IntType { get; set; }

        [MaxLength(100)]
        public DateTime? IntDate { get; set; }

        [MaxLength(500)]
        public string? Comments { get; set; }

        public Question Question { get; set; }
        public Answer Answer { get; set; }
    }
}
