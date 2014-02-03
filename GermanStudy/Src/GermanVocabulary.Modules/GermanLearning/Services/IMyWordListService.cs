
using GermanVocabulary.Infrastructure.Base;
using GermanVocabulary.DataAccess.Models;

namespace GermanLearningModule.Services
{
    /// <summary>
    /// This is the interface that gives the list of my word.
    /// </summary>
    public interface IMyWordListService : IServiceBase<MyWord>
    {
        /// <summary>
        /// Method to add one item to myword list
        /// </summary>
        /// <param name="german"></param>
        /// <param name="chinese"></param>
        /// <returns>number of added item</returns>
        int Add( string german,  string chinese);

        /// <summary>
        /// Method to add one item to myword list
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        int Add(MyWord word);
        

        /// <summary>
        /// Method to romove one item
        /// </summary>
        /// <param name="myWordId"></param>
        /// <returns>number of removed item</returns>
        int RemoveByMyWordId( int myWordId);
    }
}
