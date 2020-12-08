using System;
using domain;

namespace infrastructure.Models
{
    public class Supplier : ISupplier
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}