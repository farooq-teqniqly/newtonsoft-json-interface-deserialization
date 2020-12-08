using System;
using System.Collections.Generic;
using domain;

namespace infrastructure.Models
{
    public class PurchaseOrder : IPurchaseOrder
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<IPurchaseOrderLineItem> PurchaseOrderLineItems { get; set; }
        public ISupplier Supplier { get; set; }
    }
}
