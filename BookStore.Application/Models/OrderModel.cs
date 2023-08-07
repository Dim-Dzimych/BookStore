using BookStore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Models
{
    public class OrderModel
    {
        long Id { get; set; }
        bool IsActive { get; set; }
        public decimal TotalPrice { get; set; }
        public int Amount { get; set; }
        public long CustomerId { get; set; }
        public ICollection<BookEntity> Books { get; set; }
    }
}
