using homeWork.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        void IEntityTypeConfiguration<Teacher>.Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Patronymic)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Phone)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(c => c.CourseID)
                .IsRequired();

            builder.Property(c => c.Course)
                .IsRequired();
        }
    }
}
