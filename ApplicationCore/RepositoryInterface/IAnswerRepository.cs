using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterface
{
    public interface IAnswerRepository : IAsyncRepository<Answer>
    {
        Task<IEnumerable<Answer>> GetAnswers();

        Task<Answer> GetAnswerByName(string name);

        Task<Answer> GetAnswerById(int id);

    }
}
