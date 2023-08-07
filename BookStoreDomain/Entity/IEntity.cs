using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entity
{
    public interface IEntity
    {
        long Id { get; set; }
        bool IsActive { get; set; }
    }
}
