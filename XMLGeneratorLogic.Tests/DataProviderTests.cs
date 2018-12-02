using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using XMLGeneratorLogic.DataProvider;

namespace XMLGeneratorLogic.Tests
{
    [TestFixture]
    public class DataProviderTests
    {
        [Test]
        public void Provide_VoidArguments_Return_Stub()
        {
            // Arrange
            ICollection<string> data = new List<string> { "test", "test", "test" };

            var provider = Mock.Of<IDataProvider<ICollection<string>>>(p => p.Provide() == data);

            // Act
            var dataFromProvider = provider.Provide();

            // Assert
            CollectionAssert.AreEqual(data, dataFromProvider);
        }
    }
}
