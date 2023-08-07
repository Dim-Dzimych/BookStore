using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entity
{
    public class BookEntity : BaseEntity
    {
        public string Name { get; set; }
        public int PageCount { get; set; }
        public string Author { get; set; }
        public DateTime PublishedAt { get; set; }
        public decimal Price { get; set; }
    }
}
