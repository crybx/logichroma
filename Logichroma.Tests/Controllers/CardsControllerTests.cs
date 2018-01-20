using Logichroma.Areas.Admin.Controllers;
using Logichroma.Areas.Admin.Models.DataRepositoryInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;

namespace Logichroma.Tests.Controllers
{
    [TestClass]
    public class CardsControllerTests
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var cardValueRepo = new Mock<ICardValuesRepository>();
            var controller = new CardValuesController(cardValueRepo.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
