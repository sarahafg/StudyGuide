using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly StudyGuideDbContext studyGuideDbContext;

        public EfRepository(StudyGuideDbContext dbContext)
        {
            studyGuideDbContext = dbContext;
        }

        public async Task<T> GetById(int id)
        {
            var entity = await studyGuideDbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var data = await studyGuideDbContext.Set<T>().ToListAsync();
            return data;
        }

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate)
        {
            return await studyGuideDbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<int> GetCount(Expression<Func<T, bool>> predicate)
        {
            return await studyGuideDbContext.Set<T>().CountAsync();
        }

        public async Task<T> Add(T entity)
        {
            await studyGuideDbContext.Set<T>().AddAsync(entity);
            await studyGuideDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            studyGuideDbContext.Entry(entity).State = EntityState.Modified;
            await studyGuideDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            studyGuideDbContext.Set<T>().Remove(entity);
            await studyGuideDbContext.SaveChangesAsync();
        }
    }
}
