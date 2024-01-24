using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecruitBoard.Services.Candidates.Domain.Entities;

namespace RecruitBoard.Services.Candidates.Infrastructure.Configurations;

public class CandidateConfiguration 
    : IEntityTypeConfiguration<Candidate>
{
    public void Configure(
        EntityTypeBuilder<Candidate> builder)
    {
        builder.ToTable("candidates");
        builder.HasKey(c => c.Id);

        builder
            .Property(c => c.Id)
            .HasColumnName("id")
            .IsRequired();
        builder
            .Property(c => c.Firstname)
            .HasColumnName("firstname")
            .IsRequired()
            .HasMaxLength(15);
        builder
            .Property(c => c.Lastname)
            .HasColumnName("lastname")
            .IsRequired()
            .HasMaxLength(15);
        builder
            .Property(c => c.City)
            .HasColumnName("city")
            .HasMaxLength(20);
        builder
            .Property(c => c.Country)
            .HasColumnName("country")
            .HasMaxLength(15);
        builder
            .Property(c => c.PersonalData)
            .HasColumnName("personal_data");
        builder
            .Property(c => c.Skills)
            .HasColumnName("skills");
        builder
            .Property(c => c.CreatedBy)
            .HasColumnName("created_by");
        builder
            .Property(c => c.CreatedDate)
            .HasColumnName("created_date");
        builder
            .Property(c => c.LastModifiedBy)
            .HasColumnName("last_modified_by");
        builder
            .Property(c => c.LastModifiedDate)
            .HasColumnName("last_modified_date");
        builder
            .Property(c => c.Deleted)
            .HasColumnName("deleted");

        builder
            .HasMany(c => c.Educations)
            .WithOne(c => c.Candidate);
        builder
            .HasMany(c => c.Experiences)
            .WithOne(c => c.Candidate);
    }
}