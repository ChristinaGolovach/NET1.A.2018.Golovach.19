using System;
using NUnit.Framework;
using Moq;
using XMLGeneratorLogic.Logger;
using XMLGeneratorLogic.Validator;
using XMLGeneratorLogic.Parser;
using XMLGeneratorLogic.Mapper;

namespace XMLGeneratorLogic.Tests
{
    [TestFixture]
    public class MapperTests
    {
        private static Mock<IParser<string, Uri>> mockIParser;
        private static Mock<IValidator<Uri>> mockIValidator;
        private static Mock<ILogger> mockILogger;

        [SetUp]
        public void MapperTestsSetUp()
        {
             mockIParser = new Mock<IParser<string, Uri>>();
             mockIValidator = new Mock<IValidator<Uri>>();
             mockILogger = new Mock<ILogger>();
        }

        [TestCase("https://habrahabr.ru/company/it-grad/blog/341486/")]
        [TestCase("http://habr.com")]
        public void Map_AnyStringInArguments_Return_Stub_Uri(string uriString)
        {
            // Arrange
            Uri uri = new Uri(uriString);

            var mapper = Mock.Of<IMapper<string, Uri>>(m => m.Map(It.IsAny<string>()) == uri);

            // Act
            Uri actUri = mapper.Map("test");

            // Assert
            Assert.AreEqual(uri, actUri);
        }

        [TestCase("https://habrahabr.ru/company/it-grad/blog/341486/")]
        public void Map_Calls_Parse_And_IsValid_And_LogNever(string uriString)
        {
            // Arrange
            Uri uri = new Uri(uriString);

            mockIParser.Setup(m => m.Parse(uriString)).Returns(uri);

            var mapper = new UriMapper(mockIParser.Object, mockIValidator.Object, mockILogger.Object);

            // Act
            mapper.Map(uriString);

            // Assert
            mockIParser.Verify(p => p.Parse(uriString), Times.Once);
            mockIValidator.Verify(v => v.IsValid(uri), Times.Once);
            mockILogger.Verify(l => l.Log("never colled"), Times.Never);
        }


        [TestCase("rdar://----????")]
        public void Map_Calls_Parse_And_Log_IsValidNever(string uriString)
        {
            // Arrange        
            mockIParser.Setup(m => m.Parse(uriString)).Returns((Uri)null);

            var mapper = new UriMapper(mockIParser.Object, mockIValidator.Object, mockILogger.Object);

            // Act
            mapper.Map(uriString);

            // Assert
            mockIParser.Verify(p => p.Parse(uriString), Times.Once);
            mockIValidator.Verify(v => v.IsValid(null), Times.Never);
            mockILogger.Verify(l => l.Log($"The line {uriString} is not processed."), Times.Once);
        }

        [TestCase("foo://username:password@www.example.com:8080/")]
        public void Map_Calls_Parse_And_Log_Is(string uriString)
        {
            // Arrange 
            Uri uri = new Uri(uriString);

            mockIParser.Setup(m => m.Parse(uriString)).Returns(uri);
            mockIValidator.Setup(v => v.Message).Returns($"The uri {uriString} must contain host of dns type.");

            var mapper = new UriMapper(mockIParser.Object, mockIValidator.Object, mockILogger.Object);

            // Act
            mapper.Map(uriString);

            // Assert
            mockIParser.Verify(p => p.Parse(uriString), Times.Once);
            mockIValidator.Verify(v => v.IsValid(uri), Times.Once);
            mockILogger.Verify(l => l.Log($"The line {uriString} is not processed - {mockIValidator.Object.Message}"), Times.Once);
        }
    }
}
