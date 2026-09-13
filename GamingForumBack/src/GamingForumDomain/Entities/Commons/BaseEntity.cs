using System;
using System.Collections.Generic;
using System.Text;

namespace GamingForumDomain.Entities.Commons
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
