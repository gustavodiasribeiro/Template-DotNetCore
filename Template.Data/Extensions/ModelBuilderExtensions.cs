using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Entities;

namespace Template.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder SeedData( this ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData
                (
                    new User() { Id = Guid.Parse("b0c8fa0e-114a-4fd1-b8cd-f5d4eb3b7186"), Name = "User Default", Email = "userdefault@template.com" }
                );
            return builder;
        }
    }
}
