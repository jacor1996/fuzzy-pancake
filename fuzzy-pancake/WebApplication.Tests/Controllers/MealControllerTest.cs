using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication.Controllers;
using DAL;
using DAL.Concrete;
using DAL.DataModel;

namespace WebApplication.Tests.Controllers
{
    [TestClass]
    public class MealControllerTest
    {
        [TestMethod]
        public void Index()
        {

            Assert.AreEqual(true ,true);
        }
    }
}
