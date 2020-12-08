using FluentAssertions;
using infrastructure.CreationConverters;
using infrastructure.Models;
using Newtonsoft.Json;
using Xunit;

namespace domain.tests.Deserialization
{
    public class AttachmentDeserializationTests
    {
        [Fact]
        public void Deserialize_Attachment()
        {
            var expectedAttachment = new Attachment { Content = "foo"};
            var json = JsonConvert.SerializeObject(expectedAttachment);

            var actualAttachment = JsonConvert.DeserializeObject<IAttachment>(
                json,
                new ModelConverter<IAttachment, Attachment>());

            actualAttachment.Should().BeEquivalentTo(expectedAttachment);

        }

        [Fact]
        public void Deserialize_Attachment_Collection()
        {
            var expectedAttachments = new[]
            {
                new Attachment { Content = "foo"},
                new Attachment { Content = "bar"},

            };

            var json = JsonConvert.SerializeObject(expectedAttachments);

            var actualAttachments = JsonConvert.DeserializeObject<IAttachment[]>(
                json,
                new ModelConverter<IAttachment, Attachment>());

            actualAttachments.Should().BeEquivalentTo(expectedAttachments);

        }
    }
}
