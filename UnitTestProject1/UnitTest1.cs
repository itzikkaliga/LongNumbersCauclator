using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPIdemo.Controllers;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void sumShouldReturnZero_withOutParams()
        {
            var controller = new SumController();
            String output = controller.Get();
            Assert.AreEqual("0", output);
        }

        [TestMethod]
        public void sumShouldReturnNumA_withOutParam()
        {
            var controller = new SumController();
            String output = controller.Get("152512151");
            Assert.AreEqual("152512151", output);
        }

        [TestMethod]
        public void sumShouldReturnerr()
        {
            var controller = new SumController();
            String output = controller.Get("abc","12");
            Assert.AreEqual("Not a Valid number", output);
        }

        [TestMethod]
        public void sumShouldReturnNumWithoutZero()
        {
            var controller = new SumController();
            String output = controller.Get("00000015", "0");
            Assert.AreEqual("15", output);
        }

        [TestMethod]
        public void sumShouldReturnNum()
        {
            var controller = new SumController();
            String output = controller.Get("11521351548872424842454842487544245121", "3");
            Assert.AreEqual("11521351548872424842454842487544245124", output);
        }

        [TestMethod]
        public void sumShouldReturnBigNum()
        {
            var controller = new SumController();
            String output = controller.Get("11521351548872424842454842487544245121", 
                "546542151512444335415121513");
            Assert.AreEqual("11521351549418966993967286822959366634", output);
        }

        [TestMethod]
        public void mulShouldReturnZero_withOutParams()
        {
            var controller = new MultiplyController();
            String output = controller.Get();
            Assert.AreEqual("0", output);
        }

        [TestMethod]
        public void mulShouldReturnZero_withOutOneParam()
        {
            var controller = new MultiplyController();
            String output = controller.Get("152512151");
            Assert.AreEqual("0", output);
        }

        [TestMethod]
        public void mulShouldReturnerr()
        {
            var controller = new MultiplyController();
            String output = controller.Get("abc", "12");
            Assert.AreEqual("Not a Valid number", output);
        }

        [TestMethod]
        public void mulShouldReturnNumWithoutZero()
        {
            var controller = new MultiplyController();
            String output = controller.Get("00000015", "1");
            Assert.AreEqual("15", output);
        }

        [TestMethod]
        public void mulShouldReturnNum()
        {
            var controller = new MultiplyController();
            String output = controller.Get("11521351548872424842454842487544245121", "3");
            Assert.AreEqual("34564054646617274527364527462632735363", output);
        }

        [TestMethod]
        public void mulShouldReturnBigNum()
        {
            var controller = new MultiplyController();
            String output = controller.Get("11521351548872424842454842487544245121",
                "546542151512444335415121513");
            Assert.AreEqual
                ("6296904263851968035527016368510688406740592592713890224072388073", output);
        }
    }
}
