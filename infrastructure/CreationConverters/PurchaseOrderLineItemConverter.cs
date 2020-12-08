using System;
using domain;
using infrastructure.Models;
using Newtonsoft.Json.Converters;

namespace infrastructure.CreationConverters
{
    public class PurchaseOrderLineItemConverter : CustomCreationConverter<IPurchaseOrderLineItem>
    {
        public override IPurchaseOrderLineItem Create(Type objectType)
        {
            return new PurchaseOrderLineItem();
        }
    }
}
