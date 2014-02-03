using GermanVocabulary.DataAccess.Models;
using GermanVocabulary.Infrastructure.Base;
using System.Collections.Generic;
using System.Linq;

namespace GermanLearningModule.Services
{
    public class StudyWordListService : ServiceBase<StudyItem,VocabularyContext>, IStudyWordsListService
    {
        public List<StudyItem> GetStudyItemsWithUnit(int unit)
        {
            using (var context = GetDbContext())
            {

               return context.StudyItems.Where(studyItem => studyItem.Unit == unit).ToList();
            }         
        }

    }
}
