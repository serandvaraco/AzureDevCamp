using Blueyonder.DataAccess.Interfaces;
using Blueyonder.Entities;
using System;
using System.Linq;

namespace Blueyonder.DataAccess.Repositories
{
    public class FrequentFlyerRepository : IFrequentFlyerRepository
    {
        FrequentFlyersContext context;

        public FrequentFlyerRepository(string connectionName)
        {
            context = new FrequentFlyersContext(connectionName);
        }

        public FrequentFlyerRepository()
        {
            context = new FrequentFlyersContext();
        }

        public FrequentFlyerRepository(FrequentFlyersContext dbContext)
        {
            context = dbContext;
        }

        public FrequentFlyer GetSingle(int entityKey)
        {
            var query = from t in context.FrequentFlyers
                        where t.FrequentFlyerId == entityKey
                        select t;

            return query.SingleOrDefault();
        }

        public IQueryable<FrequentFlyer> GetAll()
        {
            return context.FrequentFlyers.AsQueryable<FrequentFlyer>();
        }

        public IQueryable<FrequentFlyer> FindBy(System.Linq.Expressions.Expression<Func<FrequentFlyer, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public void Add(FrequentFlyer entity)
        {
            context.FrequentFlyers.Add(entity);
        }

        public void Delete(FrequentFlyer entity)
        {
            context.FrequentFlyers.Find(entity.FrequentFlyerId);
            context.FrequentFlyers.Remove(entity);
        }

        public void Edit(FrequentFlyer entity)
        {
            var originalEntity = context.FrequentFlyers.Find(entity.FrequentFlyerId);
            context.Entry(originalEntity).CurrentValues.SetValues(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
                context = null;
            }
        }
    }
}
