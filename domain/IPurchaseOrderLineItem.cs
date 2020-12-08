using System;

namespace domain
{
    public interface IPurchaseOrderLineItem
    {
        Guid Id { get; set; }
        string Name { get; set; }

        IAttachment Attachment { get; set; }
    }
}