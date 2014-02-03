using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ConsoleApplication1.Models.Mapping;

namespace ConsoleApplication1.Models
{
    public  class vocabularyContext : DbContext
    {
        static vocabularyContext()
        {
            Database.SetInitializer<vocabularyContext>(null);
        }

        public vocabularyContext()
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
