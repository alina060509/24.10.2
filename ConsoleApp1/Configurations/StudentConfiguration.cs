using homeWork.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        void IEntityTypeConfiguration<Student>.Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.ID);

            builder.Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Patronymic)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.EnrollmentDate)
                .IsRequired();

            builder.Property(s => s.Reviews)
                .IsRequired();

        }
    }
}
