using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterface
{
    public interface IQuestionRepository : IAsyncRepository<Question>
    {
        Task<IEnumerable<Question>> GetQuestions();
        Task<Question> GetQuestionByName(string name);
        Task<Question> GetQuestionById(int id);
    }
}
