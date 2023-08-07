using System;

namespace BookStore.Application.Models
{
    public class FilterModel
    {
        public string Name { get; set; }
        public DateTime? PublishedAtFrom { get; set; }
        public DateTime? PublishedAtTo{ get; set; }
    }
}