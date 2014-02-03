
using System.Data.Entity.ModelConfiguration;


namespace GermanVocabulary.DataAccess.Models.Mapping
{
    public class ScoreMap : EntityTypeConfiguration<Score>
    {
        public ScoreMap()
        {
            // Primary Key
            HasKey(t => t.ScoreId);

            // Properties
            // Table & Column Mappings
            ToTable("Scores");
            Property(t => t.ScoreId).HasColumnName("ScoreId");
            Property(t => t.Unit).HasColumnName("Unit");
            Property(t => t.ScoreNum).HasColumnName("Score");
        }
    }
}
