﻿using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Logichroma.Controllers;
using Logichroma.Models.DataRepositoryInterfaces;

namespace Logichroma.Tests.Controllers
{
    [TestClass]
    public class CardsControllerTests
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var cardTypeRepo = new Mock<ICardValuesRepository>();
            var controller = new CardTypesController(cardTypeRepo.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
