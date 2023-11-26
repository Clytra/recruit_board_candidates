using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecruitBoard.Services.Candidates.Domain.Entities;

namespace RecruitBoard.Services.Candidates.Infrastructure.Configurations;

public class ExperienceConfiguration 
    : IEntityTypeConfiguration<Experience>
{
    public void Configure(
        EntityTypeBuilder<Experience> builder)
    {
        builder.ToTable("experiences");
        builder.HasKey(exp => exp.Id);

        builder
            .Property(exp => exp.Id)
            .HasColumnName("id")
            .IsRequired();
        builder
            .Property(exp => exp.CompanyName)
            .HasColumnName("company_name")
            .HasMaxLength(50)
            .IsRequired();
        builder
            .Property(exp => exp.StartDate)
            .HasColumnName("start_date")
            .IsRequired();
        builder
            .Property(exp => exp.Position)
            .HasColumnName("position")
            .IsRequired();
        builder
            .Property(exp => exp.EndDate)
            .HasColumnName("end_date");
    }
}