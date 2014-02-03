using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ConsoleApplication1.Models.Mapping
{
    public class StudyItemMap : EntityTypeConfiguration<StudyItem>
    {
        public StudyItemMap()
        {
            // Primary Key
            this.HasKey(t => t.StudyItemId);

            // Properties
            this.Property(t => t.German)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Chinese)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("StudyItems");
            this.Property(t => t.StudyItemId).HasColumnName("StudyItemId");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.German).HasColumnName("German");
            this.Property(t => t.Chinese).HasColumnName("Chinese");
        }
    }
}
