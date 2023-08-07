using System;
using System.Collections.Generic;

namespace BookStore.Domain.Entity
{
    public class CustomerEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDate { get; set; }

        public ICollection<OrderEntity> Orders { get; set; }
    }
}
