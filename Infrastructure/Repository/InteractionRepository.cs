using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterface;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class InteractionRepository : EfRepository<Interaction>, IInteractionRepository
    {
        public InteractionRepository(StudyGuideDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Interaction>> GetInteractions()
        {
            return await studyGuideDbContext.Interactions.Include(i => i.Question).Include(i => i.Answer)
                .ToListAsync();
            //var inter = await GetAll();

            //return inter;
        }

        public async Task<Interaction> GetInteractionById(int id)
        {
            return await studyGuideDbContext.Interactions.Include(i => i.Question).Include(i => i.Answer)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Interaction>> GetInteractionByQuestionId(int questionId)
        {
            return await studyGuideDbContext.Interactions.Include(i => i.Question).Include(i => i.Answer)
                .Where(i => i.QuestionId == questionId).ToListAsync();
        }

        public async Task<IEnumerable<Interaction>> GetInteractionByAnswerId(int answerId)
        {
            return await studyGuideDbContext.Interactions.Include(i => i.Question).Include(i => i.Answer)
                .Where(i => i.AnswerId == answerId).ToListAsync();
        }

        public async Task<Interaction> GetCommentsByQuestionId(int questionId)
        {
            return await studyGuideDbContext.Interactions.Include(i => i.Question).Include(i => i.Answer)
                .FirstOrDefaultAsync(i => i.QuestionId == questionId);
        }

        public async Task<Interaction> GetCommentsByAnswerId(int answerId)
        {
            return await studyGuideDbContext.Interactions.Include(i => i.Question).Include(i => i.Answer)
                .FirstOrDefaultAsync(i => i.AnswerId == answerId);
        }
    }
}
