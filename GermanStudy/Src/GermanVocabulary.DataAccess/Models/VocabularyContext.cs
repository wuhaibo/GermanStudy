using GermanVocabulary.DataAccess.Models.Mapping;
using System.Data.Entity;

namespace GermanVocabulary.DataAccess.Models
{
    public class VocabularyContext : DbContext
    {
        static VocabularyContext()
        {
            Database.SetInitializer<VocabularyContext>(null);
        }

        public VocabularyContext()
            : base("Name=vocabularyContext")
        {
        }

        public DbSet<MyWord> MyWords { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<StudyItem> StudyItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MyWordMap());
            modelBuilder.Configurations.Add(new ScoreMap());
            modelBuilder.Configurations.Add(new StudyItemMap());
        }
    }
}
