using System;
using FluentAssertions;
using infrastructure.CreationConverters;
using infrastructure.Models;
using Newtonsoft.Json;
using Xunit;

namespace domain.tests.Deserialization
{
    public class SupplierDeserializationTests
    {
        [Fact]
        public void Deserialize_Supplier()
        {
            var expectedSupplier = new Supplier {Id = Guid.NewGuid(), Name = "foo"};
            var json = JsonConvert.SerializeObject(expectedSupplier);

            var actualSupplier = JsonConvert.DeserializeObject<ISupplier>(
                json, 
                new ModelConverter<ISupplier, Supplier>());

            actualSupplier.Should().BeEquivalentTo(expectedSupplier);

        }

        [Fact]
        public void Deserialize_Supplier_Collection()
        {
            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();

            var expectedSuppliers = new[]
            {
               new Supplier { Id = id1, Name = "foo" },
               new Supplier { Id = id2, Name = "bar" },

            };

            var json = JsonConvert.SerializeObject(expectedSuppliers);

            var actualSuppliers = JsonConvert.DeserializeObject<ISupplier[]>(
                json,
                new ModelConverter<ISupplier, Supplier>());

            actualSuppliers.Should().BeEquivalentTo(expectedSuppliers);

        }
    }
}
