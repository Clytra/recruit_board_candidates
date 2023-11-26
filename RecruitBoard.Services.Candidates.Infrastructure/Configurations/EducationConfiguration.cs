using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecruitBoard.Services.Candidates.Domain.Entities;

namespace RecruitBoard.Services.Candidates.Infrastructure.Configurations;

public class EducationConfiguration 
    : IEntityTypeConfiguration<Education>
{
    public void Configure(
        EntityTypeBuilder<Education> builder)
    {
        builder.ToTable("educations");
        builder.HasKey(edu => edu.Id);

        builder
            .Property(edu => edu.Id)
            .HasColumnName("id")
            .IsRequired();
        builder
            .Property(edu => edu.InstitutionName)
            .HasColumnName("institution_name")
            .HasMaxLength(50);
        builder
            .Property(edu => edu.Degree)
            .HasColumnName("degree")
            .HasMaxLength(15);
        builder
            .Property(edu => edu.YearOfCompletion)
            .HasColumnName("year_of_completion");
    }
}