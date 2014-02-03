using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace GermanVocabulary.Infrastructure.Base
{
    /// <summary>
    /// Abstract class implements IServiceBase interface.
    /// This class implements the basic database operations.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TDbContext"></typeparam>
    public abstract class ServiceBase<TEntity, TDbContext> : IServiceBase<TEntity>
                                            where TEntity : class
                                            where TDbContext:DbContext,new()
    {
        /// <summary>
        /// Get the DatabaseContext
        /// </summary>
        /// <returns>database context</returns>
        protected TDbContext GetDbContext()
        {
            return new TDbContext();
        }

        /// <summary>
        /// Get All items
        /// </summary>
        /// <returns></returns>
        public List<TEntity> GetAll()
        {
            using (var context = GetDbContext())
            {
                return context.Set<TEntity>().ToList();
            } 
        }
        
        /// <summary>
        /// Save changes.
        /// </summary>
        /// <param name="context"></param>
        public int Save(DbContext context)
        {
           return context.SaveChanges();            
        }

        /*
        /// <summary>
        /// Add one entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>number of added item</returns>
        public int Add(TEntity entity)
        {
            using (var context = GetDbContext())
            {
                context.Set<TEntity>().Add(entity);
                return Save(context);
            } 
        }
        */
        
        /// <summary>
        /// Remove one entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>number of removed item</returns>
        public int Remove(TEntity entity)
        {
            using (var context = GetDbContext())
            {
                context.Set<TEntity>().Remove(entity);
                return Save(context);
            } 
            
        }
    }
}
