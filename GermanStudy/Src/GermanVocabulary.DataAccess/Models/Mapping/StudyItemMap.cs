
using System.Data.Entity.ModelConfiguration;


namespace GermanVocabulary.DataAccess.Models.Mapping
{
    public class StudyItemMap : EntityTypeConfiguration<StudyItem>
    {
        public StudyItemMap()
        {
            // Primary Key
            HasKey(t => t.StudyItemId);

            // Properties
            Property(t => t.German)
                .IsRequired()
                .HasMaxLength(200);

            Property(t => t.Chinese)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            ToTable("StudyItems");
            Property(t => t.StudyItemId).HasColumnName("StudyItemId");
            Property(t => t.Unit).HasColumnName("Unit");
            Property(t => t.German).HasColumnName("German");
            Property(t => t.Chinese).HasColumnName("Chinese");
        }
    }
}
