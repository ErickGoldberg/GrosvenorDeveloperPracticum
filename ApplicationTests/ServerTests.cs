using Application;
using NUnit.Framework;

namespace ApplicationTests
{
    [TestFixture]
    public class ServerTests
    {
        private Server _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Server(new DishManager());
        }

        [TearDown]
        public void Teardown()
        {

        }

        [TestCase("one", "error", TestName = "TakeOrder_BadInput_ShouldReturnError")]
        public void TakeOrder_BadInput(string order, string expected)
        {
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("evening,1", "steak", TestName = "TakeOrder_ValidSteakOrder_ShouldReturnSteak")]
        public void TakeOrder_ValidSteakOrder(string order, string expected)
        {
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("evening,2,2", "potato(x2)", TestName = "TakeOrder_ValidPotatoOrder_ShouldReturnPotatoX2")]
        public void TakeOrder_ValidPotatoOrder(string order, string expected)
        {
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("evening,1,2,3,4", "steak,potato,wine,cake", TestName = "TakeOrder_ValidMixedOrder_ShouldReturnSteakPotatoWineCake")]
        public void TakeOrder_ValidMixedOrder(string order, string expected)
        {
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("evening,1,2,2,4", "steak,potato(x2),cake", TestName = "TakeOrder_ValidSteakPotatoX2Order_ShouldReturnSteakPotatoX2Cake")]
        public void TakeOrder_ValidSteakPotatoX2Order(string order, string expected)
        {
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2,3,5", "error", TestName = "TakeOrder_InvalidDish_ShouldReturnError")]
        public void TakeOrder_InvalidDish(string order, string expected)
        {
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,1,2,3", "error", TestName = "TakeOrder_MultipleSteaks_ShouldReturnError")]
        public void TakeOrder_MultipleSteaks(string order, string expected)
        {
            var actual = _sut.TakeOrder(order);
            Assert.AreEqual(expected, actual);
        }
    }
}