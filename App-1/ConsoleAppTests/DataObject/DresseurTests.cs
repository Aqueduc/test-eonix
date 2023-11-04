using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DataObject.Tests
{
    [TestClass()]
    public class DresseurTests
    {

        public Dresseur Dresseur = new Dresseur();



        [TestMethod()]
        public void ExecToursTest()
        {
            Dresseur.ExecTours(null);
            Assert.AreEqual(4, Dresseur.Singe.LsTours.Count);
        }
    }
}