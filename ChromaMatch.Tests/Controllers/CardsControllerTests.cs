using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ChromaMatch.Controllers;
using ChromaMatch.Models.DataRepositoryInterfaces;

namespace ChromaMatch.Tests.Controllers
{
    [TestClass]
    public class CardsControllerTests
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var cardTypeRepo = new Mock<ICardTypeRepository>();
            var controller = new CardTypesController(cardTypeRepo.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
