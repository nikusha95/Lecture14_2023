using ApiWithDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiWithDatabase.Configurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable("Subject");
        builder.Property(x => x.Name).HasMaxLength(255);
        
        builder.HasMany(x => x.StudentSubjects)
            .WithOne(x => x.Subject)
            .HasForeignKey(x => x.SubjectId);
    }
}