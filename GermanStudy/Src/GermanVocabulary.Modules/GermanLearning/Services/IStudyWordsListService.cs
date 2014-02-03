using GermanVocabulary.Infrastructure.Base;
using GermanVocabulary.DataAccess.Models;
using System.Collections.Generic;


namespace GermanLearningModule.Services
{
    /// <summary>
    /// This is a interface that gives the word to study for 'study word view'. 
    /// </summary>
    public interface IStudyWordsListService : IServiceBase<StudyItem>
    {
        /// <summary>
        /// Method return all the words in the given unit.
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        List<StudyItem> GetStudyItemsWithUnit(int unit);
    }
}
