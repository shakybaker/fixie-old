using System;

namespace Fixie.Domain
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime Created { get; set; }
        int CreatedBy { get; set; }
        DateTime Modified { get; set; }
        int ModifiedBy { get; set; }
    }
}
