using System;
using System.Linq;
using FluentAssertions;
using infrastructure.CreationConverters;
using infrastructure.Models;
using Newtonsoft.Json;
using Xunit;

namespace domain.tests.CreationConverters
{
    public class PurchaseOrderLineItemConverterTests
    {
        [Fact]
        public void Deserialize_PurchaseOrderLineItem()
        {
            var expectedPurchaseOrderLineItem = new PurchaseOrderLineItem
            {
                Id = Guid.NewGuid(), 
                Name = "foo",
                Attachment = new Attachment { Content = "foo"}
            };

            var json = JsonConvert.SerializeObject(expectedPurchaseOrderLineItem);

            var actualPurchaseOrderLineItem = JsonConvert.DeserializeObject<IPurchaseOrderLineItem>(
                json,
                new PurchaseOrderLineItemConverter(), new AttachmentConverter());

            actualPurchaseOrderLineItem.Should().BeEquivalentTo(expectedPurchaseOrderLineItem);

        }

        [Fact]
        public void Deserialize_PurchaseOrderLineItem_Collection()
        {
            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();

            var expectedPurchaseOrderLineItems = new[]
            {
                new PurchaseOrderLineItem
                {
                    Id = id1, 
                    Name = "foo",
                    Attachment = new Attachment {Content = "foo"}
                },
                new PurchaseOrderLineItem
                {
                    Id = id2, 
                    Name = "bar",
                    Attachment = new Attachment { Content = "bar"}
                },
            };

            var json = JsonConvert.SerializeObject(expectedPurchaseOrderLineItems);

            var actualPurchaseOrderLineItems = JsonConvert.DeserializeObject<IPurchaseOrderLineItem[]>(
                json,
                new PurchaseOrderLineItemConverter(), 
                new AttachmentConverter());

            actualPurchaseOrderLineItems.Should().BeEquivalentTo(expectedPurchaseOrderLineItems);

            var lineItemFoo = actualPurchaseOrderLineItems.Single(line => line.Id == id1);
            lineItemFoo.Attachment.Content.Should().Be("foo");

            var lineItemBar = actualPurchaseOrderLineItems.Single(line => line.Id == id2);
            lineItemBar.Attachment.Content.Should().Be("bar");


        }
    }
}
