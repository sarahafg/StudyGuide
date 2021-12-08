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
    public class QuestionRepository : EfRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(StudyGuideDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Question>> GetQuestions()
        {
            var question = await GetAll();

            return question;
        }

        public async Task<Question> GetQuestionByName(string name)
        {
            return await studyGuideDbContext.Questions.FirstOrDefaultAsync(q => q.Name == name);
        }

        public async Task<Question> GetQuestionById(int id)
        {
            return await studyGuideDbContext.Questions.FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
