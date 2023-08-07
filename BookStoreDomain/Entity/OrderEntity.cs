using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entity
{
    public class OrderEntity : BaseEntity
    {
        public decimal TotalPrice { get; set; }
        public int Amount { get; set; }
        public long CustomerId { get; set; }
        public ICollection<BookEntity> Books { get; set; }

    }
}
