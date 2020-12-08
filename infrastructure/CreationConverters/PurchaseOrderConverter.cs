using System;
using domain;
using infrastructure.Models;
using Newtonsoft.Json.Converters;

namespace infrastructure.CreationConverters
{
    public class PurchaseOrderConverter : CustomCreationConverter<IPurchaseOrder>
    {
        public override IPurchaseOrder Create(Type objectType)
        {
            return new PurchaseOrder();
        }
    }
}
