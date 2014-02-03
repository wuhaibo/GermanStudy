

using GermanVocabulary.DataAccess.Models;
using GermanVocabulary.Infrastructure.Base;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;


namespace GermanLearningModule.Services
{
    public class MyWordListService: ServiceBase<MyWord,VocabularyContext>,IMyWordListService
    {
        public int Add(string german, string chinese)
        {
            var word = new MyWord {German = german, Chinese = chinese};
            return Add(word);     
        }

        public int Add(MyWord word)
        {
            try
            {
                using (var context = GetDbContext())
                {
                    context.Set<MyWord>().Add(word);
                    return context.SaveChanges();
                }
            }
            catch (DbUpdateException ex)
            {
                var sqlException = ex.InnerException.InnerException as SqlException;

                if (sqlException != null &&  sqlException.Number == 2627 /* PK/UKC violation */)
                {
                    // do nothing just ignore the violation of Unique constraint exception
                }
                else
                {
                    throw;
                }
                return 0;
            }
        }

        public int RemoveByMyWordId(int myWordId)
        {
            using (var context = GetDbContext())
            {
                var word = new MyWord {MyWordId = myWordId};
                context.MyWords.Attach(word);
                context.MyWords.Remove(word);
                return context.SaveChanges();
            }
        }
    }
}
