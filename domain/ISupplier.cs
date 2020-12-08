using System;

namespace domain
{
    public interface ISupplier
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}