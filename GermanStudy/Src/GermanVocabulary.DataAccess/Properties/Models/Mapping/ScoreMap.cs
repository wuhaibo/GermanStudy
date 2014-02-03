using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ConsoleApplication1.Models.Mapping
{
    public class ScoreMap : EntityTypeConfiguration<Score>
    {
        public ScoreMap()
        {
            // Primary Key
            this.HasKey(t => t.ScoreId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Scores");
            this.Property(t => t.ScoreId).HasColumnName("ScoreId");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.Score1).HasColumnName("Score");
        }
    }
}
