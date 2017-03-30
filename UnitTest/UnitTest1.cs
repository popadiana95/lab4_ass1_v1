using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ass2_1.BL;
using Ass2_1;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void addProductToOrder1()
        {
            Orders otest = new Orders();
            Order order = new Order();
            Product p = new Product();
            p.stock = 10;
            int q = 12;
            string s = otest.addProduct(order, p, q,1);
            Assert.AreEqual(s, "Stoc insuficient");
        }
        
    }
}
