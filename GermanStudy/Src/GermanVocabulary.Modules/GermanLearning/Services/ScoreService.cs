
using GermanVocabulary.DataAccess.Models;
using GermanVocabulary.Infrastructure.Base;
using System.Linq;
 
namespace GermanLearningModule.Services
{
    public class ScoreListService : ServiceBase<Score, VocabularyContext>, IScoreListService
    {

        public int Update(int unit, float score)
        {
            using (var context = GetDbContext())
            {
                var score2Change = context.Scores.FirstOrDefault(s => s.Unit == unit);
                if (score2Change != null) score2Change.ScoreNum = score;
                return context.SaveChanges();
            }

        }
    }

}
