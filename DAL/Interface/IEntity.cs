using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public enum EntityState
    {
        Unchanged,
        Added,
        Modified,
        Deleted
    }

    public interface IEntity
    {
        EntityState entity_state { get; set; }
    }
}
