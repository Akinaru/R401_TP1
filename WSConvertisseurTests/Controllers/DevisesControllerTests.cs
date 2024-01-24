﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSConvertisseur.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSConvertisseur.Models;
using Microsoft.AspNetCore.Mvc;

namespace WSConvertisseur.Controllers.Tests
{
    [TestClass()]
    public class DevisesControllerTests
    {

        [TestMethod]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            DevisesController controller = new DevisesController();
            // Act
            var result = controller.GetById(1);
            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>), "Pas un ActionResult"); // Test du type de retour
            Assert.IsNull(result.Result, "Erreur est pas null"); //Test de l'erreur
            Assert.IsInstanceOfType(result.Value, typeof(Devise), "Pas une Devise"); // Test du type du contenu (valeur) du retour
            Assert.AreEqual(new Devise(1, "Dollar", 1.08), (Devise?)result.Value, "Devises pas identiques"); //Test de la devise récupérée
        }

        [TestMethod]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Arrange
            DevisesController controller = new DevisesController();
            // Act
            var result = controller.GetById(4);
            // Asset
            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>), "Pas un ActionResult");
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult), "Pas un NotFoundResult");
            Assert.IsNull(result.Value, "Erreur est pas null");


        }
    }
}