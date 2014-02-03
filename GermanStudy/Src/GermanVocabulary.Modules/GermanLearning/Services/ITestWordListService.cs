using GermanLearningModule.Util;
using GermanVocabulary.Infrastructure.Base;
using GermanVocabulary.DataAccess.Models;
using System.Collections.Generic;

namespace GermanLearningModule.Services
{
    /// <summary>
    /// This is a interface that handles the Test Word services for 
    /// the Test Word View.
    /// </summary>
    public interface ITestWordListService: IServiceBase<StudyItem>
    {
        /// <summary>
        /// Get All words to study in the given unit.
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>A list of words that in unit</returns>
        List<StudyItem> GetStudyItemsWithUnit(int unit);

        /// <summary>
        /// Get the sequence of words for test.
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>A list of words for test.</returns>
        List<QnAModel> GetTestSequence(int unit);
    }
}
