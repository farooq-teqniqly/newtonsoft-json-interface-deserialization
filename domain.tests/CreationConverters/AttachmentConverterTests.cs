using FluentAssertions;
using infrastructure.CreationConverters;
using infrastructure.Models;
using Newtonsoft.Json;
using Xunit;

namespace domain.tests.CreationConverters
{
    public class AttachmentConverterTests
    {
        [Fact]
        public void Deserialize_Attachment()
        {
            var expectedAttachment = new Attachment { Content = "foo"};
            var json = JsonConvert.SerializeObject(expectedAttachment);

            var actualAttachment = JsonConvert.DeserializeObject<IAttachment>(
                json,
                new AttachmentConverter());

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
                new AttachmentConverter());

            actualAttachments.Should().BeEquivalentTo(expectedAttachments);

        }
    }
}
