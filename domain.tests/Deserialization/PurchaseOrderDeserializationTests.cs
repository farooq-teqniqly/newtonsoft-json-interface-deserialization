using System;
using System.Collections.Generic;
using FluentAssertions;
using infrastructure.CreationConverters;
using infrastructure.Models;
using Newtonsoft.Json;
using Xunit;

namespace domain.tests.Deserialization
{
    public class PurchaseOrderDeserializationTests
    {
        [Fact]
        public void Deserialize_PurchaseOrder()
        {
            var id = Guid.NewGuid();

            var expectedPurchaseOrder = new PurchaseOrder
            {
                Id = id,
                Name = "foo",
                Supplier = new Supplier
                {
                    Id = id,
                    Name = "foo-sup"
                },
                PurchaseOrderLineItems = new List<IPurchaseOrderLineItem>
                {
                    new PurchaseOrderLineItem
                    {
                        Id = id,
                        Name = "item1",
                        Attachment = new Attachment {Content = "item1-att"}
                    },
                    new PurchaseOrderLineItem
                    {
                        Id = id,
                        Name = "item2",
                        Attachment = new Attachment {Content = "item2-att"}
                    }
                }
            };

            var json = JsonConvert.SerializeObject(expectedPurchaseOrder);

            var actualPurchaseOrder = JsonConvert.DeserializeObject<IPurchaseOrder>(
                json,
                new ModelConverter<IPurchaseOrder, PurchaseOrder>(),
                new ModelConverter<ISupplier, Supplier>(),
                new ModelConverter<IPurchaseOrderLineItem, PurchaseOrderLineItem>(),
                new ModelConverter<IAttachment, Attachment>());

            actualPurchaseOrder.Should().BeEquivalentTo(expectedPurchaseOrder);
        }

        [Fact]
        public void Deserialize_PurchaseOrder_Collection()
        {
            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();

            var expectedPurchaseOrders = new[]
            {
                new PurchaseOrder
                {
                    Id = id1,
                    Name = "foo",
                    Supplier = new Supplier
                    {
                        Id = id1,
                        Name = "foo-sup"
                    },
                    PurchaseOrderLineItems = new List<IPurchaseOrderLineItem>
                    {
                        new PurchaseOrderLineItem
                        {
                            Id = id1,
                            Name = "item1",
                            Attachment = new Attachment {Content = "item1-att"}
                        },
                        new PurchaseOrderLineItem
                        {
                            Id = id1,
                            Name = "item2",
                            Attachment = new Attachment {Content = "item2-att"}
                        }
                    }
                },
                new PurchaseOrder
                {
                    Id = id2,
                    Name = "bar",
                    Supplier = new Supplier
                    {
                        Id = id2,
                        Name = "bar-sup"
                    },
                    PurchaseOrderLineItems = new List<IPurchaseOrderLineItem>
                    {
                        new PurchaseOrderLineItem
                        {
                            Id = id2,
                            Name = "item1",
                            Attachment = new Attachment {Content = "item1-att"}
                        },
                        new PurchaseOrderLineItem
                        {
                            Id = id2,
                            Name = "item2",
                            Attachment = new Attachment {Content = "item2-att"}
                        }
                    }
                },
            };

            var json = JsonConvert.SerializeObject(expectedPurchaseOrders);

            var actualPurchaseOrders = JsonConvert.DeserializeObject<IPurchaseOrder[]>(
                json,
                new ModelConverter<IPurchaseOrder, PurchaseOrder>(),
                new ModelConverter<ISupplier, Supplier>(),
                new ModelConverter<IPurchaseOrderLineItem, PurchaseOrderLineItem>(),
                new ModelConverter<IAttachment, Attachment>());

            actualPurchaseOrders.Should().BeEquivalentTo(expectedPurchaseOrders);
        }
    }
}
