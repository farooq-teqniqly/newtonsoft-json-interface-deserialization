using System;
using domain;

namespace infrastructure.Models
{
    public class PurchaseOrderLineItem : IPurchaseOrderLineItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IAttachment Attachment { get; set; }
    }
}