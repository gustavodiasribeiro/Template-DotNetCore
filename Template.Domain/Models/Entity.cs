using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Domain.Models
{
    public class Entity
    {
        public Guid Id { get; set; }

        public DateTime DataCreated { get; set; }

        public DateTime? DataUpdated { get; set; }

        public bool IsDeleted { get; set; }
    }
}
