using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterface
{
    public interface IInteractionRepository : IAsyncRepository<Interaction>
    {
        Task<IEnumerable<Interaction>> GetInteractions();
        Task<Interaction> GetInteractionById(int id);
        Task<IEnumerable<Interaction>> GetInteractionByQuestionId(int questionId);
        Task<IEnumerable<Interaction>> GetInteractionByAnswerId(int answerId);
        Task<Interaction> GetCommentsByAnswerId(int answerId);
        Task<Interaction> GetCommentsByQuestionId(int questionId);
    }
}
