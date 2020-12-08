using System;
using Newtonsoft.Json.Converters;

namespace infrastructure.CreationConverters
{
    public class ModelConverter<TInterface, TImpl> : CustomCreationConverter<TInterface>
        where TImpl : class, TInterface, new()
    {
        public override TInterface Create(Type objectType)
        {
            return new TImpl();
        }
    }
}
