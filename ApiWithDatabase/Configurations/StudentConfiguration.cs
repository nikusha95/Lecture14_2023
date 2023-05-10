using ApiWithDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiWithDatabase.Configurations;

public class StudentConfiguration: IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Student");
        builder.Property(x => x.FirstName).HasMaxLength(255);
        builder.Property(x => x.LastName).HasMaxLength(255);
        builder.Property(x => x.PersonalId).HasMaxLength(11);
        builder.Property(x => x.StartYear).IsRequired();

        builder.HasMany(x => x.StudentSubjects)
            .WithOne(x => x.Student)
            .HasForeignKey(x => x.StudentId);
    }
}