using System.Collections.Generic;

namespace GermanVocabulary.Infrastructure.Base
{
    /// <summary>
    /// This is the interface of basic data operations.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IServiceBase<TEntity> 
    {
        /// <summary>
        /// Get All entities
        /// </summary>
        /// <returns>A list of all entities</returns>
        List<TEntity> GetAll();

        /*
        /// <summary>
        /// Add one entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>number of added item</returns>
        int Add(TEntity entity);*/

        /// <summary>
        /// Remove one entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>number of removed item</returns>
        int Remove(TEntity entity);
        
    }
}
