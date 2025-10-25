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
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        void IEntityTypeConfiguration<Review>.Configure(EntityTypeBuilder<Review> builder) 
        {
            builder.HasKey(r => r.ID);

            builder.Property(r => r.CourseID)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(r => r.StudentID)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(r => r.Course)
                .IsRequired();

            builder.Property(r => r.Student)
                .IsRequired();

            builder.Property(r => r.Rating)
                .IsRequired();

        }
    }
}
