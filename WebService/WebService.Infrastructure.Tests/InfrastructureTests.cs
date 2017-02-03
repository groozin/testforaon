using NUnit.Framework;
using WebService.Infrastructure.Repositories;

namespace WebService.Infrastructure.Tests
{
    [TestFixture]
    public class InfrastructureTests
    {
        [Test]
        public void ItCanRunFirstTestFromInfrastructure()
        {
            Assert.AreEqual(2, 2);
        }

        [Test]
        public void ItGetsCustomersFromRepository()
        {
            var repository = new CustomerRepository();
            var list = repository.GetCustomersWithOrdersUnder(2);

            Assert.IsNotNull(list);
            Assert.IsNotEmpty(list);
            Assert.AreEqual(3, list.Count);
        }
    }
}
