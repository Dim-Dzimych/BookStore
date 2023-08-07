using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entity
{
    public class BaseEntity : IEntity
    {
        public long Id { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? CreateAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateAt { get; set; }

    }
}
