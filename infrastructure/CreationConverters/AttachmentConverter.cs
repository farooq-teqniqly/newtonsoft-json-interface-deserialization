using System;
using domain;
using infrastructure.Models;
using Newtonsoft.Json.Converters;

namespace infrastructure.CreationConverters
{
    public class AttachmentConverter : CustomCreationConverter<IAttachment>
    {
        public override IAttachment Create(Type objectType)
        {
            return new Attachment();
        }
    }
}