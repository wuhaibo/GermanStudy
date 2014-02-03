using GermanVocabulary.Infrastructure.Base;
using GermanVocabulary.DataAccess.Models;

namespace GermanLearningModule.Services
{
    /// <summary>
    /// This is the interface that gives the score of each unit
    /// </summary>
    public interface IScoreListService:IServiceBase<Score>
    {
        /// <summary>
        /// The method update the score of the given unit
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="score"></param>
        /// <returns>number of updated item</returns>
         int Update( int unit, float score);

    }
}
