using System;
using System.Collections.Generic;

namespace domain
{
    public interface IPurchaseOrder
    {
        Guid Id { get; set; }
        string Name { get; set; }

        ICollection<IPurchaseOrderLineItem> PurchaseOrderLineItems { get; set; }

        ISupplier Supplier { get; set; }

    }
}
