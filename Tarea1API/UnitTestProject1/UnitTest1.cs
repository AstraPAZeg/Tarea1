using System;
using System.Net;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tarea1API.Controllers;
using Tarea1API.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGet()
        {
            //Arrange
            aguilars1Controller controlador = new aguilars1Controller();
            //Act
            var listaAguilar = controlador.Getaguilars();

            //Assert
            Assert.IsNotNull(listaAguilar);
        }
        [TestMethod]
        public void TestPost()
        {
            //Arrange
            aguilars1Controller controlador = new aguilars1Controller();
            aguilar prueba = new aguilar()
            {
                aguilar_ID = 5,
                FriendofAguilar = "Billy Tartaja",
                Place_lista = 0,
                Birthday= DateTime.Now,
                email ="cosa@gmail.com"
            };
            //Act
            var listaAguilar = controlador.Postaguilar(prueba);
            var resultadoCreado = listaAguilar as CreatedAtRouteNegotiatedContentResult<aguilar>;

            //Assert
            Assert.IsNotNull(resultadoCreado);
            Assert.AreEqual("DefaultApi", resultadoCreado.RouteName);
            Assert.AreEqual(prueba.aguilar_ID, resultadoCreado.Content.aguilar_ID);
        }

        [TestMethod]
        public void TestDelete()
        {
            //Arrange
            aguilars1Controller controlador = new aguilars1Controller();
            aguilar prueba = new aguilar()
            {
                aguilar_ID = 5,
                FriendofAguilar = "Billy Tartaja",
                Place_lista = 0,
                Birthday = DateTime.Now,
                email = "cosa@gmail.com"
            };
            //Act
            var listaAguilar = controlador.Postaguilar(prueba);
            var resultadoEliminado = controlador.Deleteaguilar(prueba.aguilar_ID);

            //Assert
            Assert.IsInstanceOfType(resultadoEliminado, typeof(OkNegotiatedContentResult<aguilar>));
        }

        [TestMethod]
        public void TestPut()
        {
            //Arrange
            aguilars1Controller controlador = new aguilars1Controller();
            aguilar prueba = new aguilar()
            {
                aguilar_ID = 5,
                FriendofAguilar = "Billy Tartaja",
                Place_lista = 0,
                Birthday = DateTime.Now,
                email = "cosa@gmail.com"
            };
            //Act
            var listaAguilar = controlador.Postaguilar(prueba);
            prueba.FriendofAguilar = "Cujo de la calle 13";
            var resultadoCreado = controlador.Putaguilar(prueba.aguilar_ID, prueba) as StatusCodeResult;

            //Assert
            Assert.IsNotNull(resultadoCreado);
            Assert.AreEqual(HttpStatusCode.NoContent, resultadoCreado.StatusCode);
            Assert.IsInstanceOfType(resultadoCreado, typeof(StatusCodeResult));
        }
    }
}
