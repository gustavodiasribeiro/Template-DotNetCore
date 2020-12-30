using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using Template.Domain.Models;

namespace Template.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder ApplyGlobalConfigurations(this ModelBuilder builder)
        {
            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
            {
                foreach (IMutableProperty property in entityType.GetProperties())
                {
                    switch (property.Name)
                    {
                        case nameof(Entity.Id):
                            property.IsKey();
                            break;
                        case nameof(Entity.DataUpdated):
                            property.IsNullable = true;
                            break;
                        case nameof(Entity.DataCreated):
                            property.IsNullable = false;
                            property.SetDefaultValue(DateTime.Now);
                            break;
                        case nameof(Entity.IsDeleted):
                            property.IsNullable = false;
                            property.SetDefaultValue(false);
                            break;
                        default:
                            break;
                    }
                }
            }
            return builder;
        }

        public static ModelBuilder SeedData(this ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData
                (
                    new User() { Id = Guid.Parse("b0c8fa0e-114a-4fd1-b8cd-f5d4eb3b7186"), Name = "User Default", Email = "userdefault@template.com", DataCreated = new DateTime(2020,12,27),IsDeleted = false,DataUpdated = null }
                );
            return builder;
        }
    }
}
