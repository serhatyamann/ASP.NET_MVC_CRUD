using MVC_CRUD.Models.Entities.Concrete;
using MVC_CRUD.Models.EntityTypeConfiguration.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CRUD.Models.EntityTypeConfiguration.Concrete
{
    public class CategoryEntityTypeConfiguration : BaseEntityTypeConfiguration<Category>
    {
        public CategoryEntityTypeConfiguration()
        {
            ToTable("dbo.Categories");
            Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(60).IsRequired();
            Property(x => x.Description).HasColumnType("nvarchar").HasMaxLength(300).IsRequired();

            //ilişki
            HasMany(x => x.Products).WithRequired(x => x.Category).HasForeignKey(x => x.CategoryId).WillCascadeOnDelete(false);
        }
    }
}