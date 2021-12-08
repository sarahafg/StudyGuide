using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterface;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class AnswerRepository : EfRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(StudyGuideDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Answer>> GetAnswers()
        {
            var answer = await GetAll();
            return (IEnumerable<Answer>)answer;
        }

        public async Task<Answer> GetAnswerById(int id)
        {
            return await studyGuideDbContext.Answers.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Answer> GetAnswerByName(string name)
        {
            return await studyGuideDbContext.Answers.FirstOrDefaultAsync(a => a.Name == name);
        }
    }
}
