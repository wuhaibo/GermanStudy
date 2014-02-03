
using System.Data.Entity.ModelConfiguration;


namespace GermanVocabulary.DataAccess.Models.Mapping
{
    public class MyWordMap : EntityTypeConfiguration<MyWord>
    {
        public MyWordMap()
        {
            // Primary Key
            HasKey(t => t.MyWordId);

            // Properties
            Property(t => t.German)
                .IsRequired()
                .HasMaxLength(200);

            Property(t => t.Chinese)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            ToTable("MyWords");
            Property(t => t.MyWordId).HasColumnName("MyWordId");
            Property(t => t.German).HasColumnName("German");
            Property(t => t.Chinese).HasColumnName("Chinese");
        }
    }
}
