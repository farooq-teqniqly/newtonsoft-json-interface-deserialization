using System;
using domain;
using infrastructure.Models;
using Newtonsoft.Json.Converters;

namespace infrastructure.CreationConverters
{
    public class SupplierConverter : CustomCreationConverter<ISupplier>
    {
        public override ISupplier Create(Type objectType)
        {
            return new Supplier();
        }
    }
}
