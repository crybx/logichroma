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
            var cardRepo = new Mock<ICardRepository>();
            var controller = new CardTypesController(cardRepo.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
