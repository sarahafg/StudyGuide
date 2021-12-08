using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Question
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(300)]
        public string? Questions { get; set; }

        public DateTime? AddedOn { get; set; }

        public ICollection<Interaction> Interactions { get; set; }
    }
}
