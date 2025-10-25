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
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        void IEntityTypeConfiguration<Course>.Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Description)
                .IsRequired();

            builder.Property(c => c.DurationHours)
                .IsRequired();

            builder.Property(c => c.Price)
                .IsRequired();

            builder.Property(c => c.Teachers)
                .IsRequired();

            builder.Property(c => c.Reviews)
                .IsRequired();

        }

    }
}
