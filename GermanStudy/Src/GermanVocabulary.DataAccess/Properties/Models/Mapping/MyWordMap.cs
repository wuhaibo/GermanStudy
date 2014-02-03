using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ConsoleApplication1.Models.Mapping
{
    public class MyWordMap : EntityTypeConfiguration<MyWord>
    {
        public MyWordMap()
        {
            // Primary Key
            this.HasKey(t => t.MyWordId);

            // Properties
            this.Property(t => t.German)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Chinese)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("MyWords");
            this.Property(t => t.MyWordId).HasColumnName("MyWordId");
            this.Property(t => t.German).HasColumnName("German");
            this.Property(t => t.Chinese).HasColumnName("Chinese");
        }
    }
}
