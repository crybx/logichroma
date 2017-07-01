using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pyrotechnics.Controllers;
using Pyrotechnics.Models.DataRepositoryInterfaces;

namespace Pyrotechnics.Tests.Controllers
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
