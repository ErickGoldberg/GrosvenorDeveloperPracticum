using System.Linq;
using GrosvenorDeveloperPracticum.Application;
using GrosvenorDeveloperPracticum.Domain.Entities;
using NUnit.Framework;

namespace GrosvenorDeveloperPracticum.Tests
{
    [TestFixture]
    public class DishManagerTests
    {
        private DishManager _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new DishManager();
        }

        [Test]
        public void GetDishes_EmptyOrder_ShouldReturnEmptyList()
        {
            var order = new Order();
            var actual = _sut.GetDishes(order);
            Assert.AreEqual(0, actual.Count);
        }

        [Test]
        public void GetDishes_OrderWithOneDish_ShouldReturnOneSteak()
        {
            var order = new Order();
            order.SetPeriod("evening");
            order.AddDish(1);

            var actual = _sut.GetDishes(order);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("steak", actual.First().DishName);
            Assert.AreEqual(1, actual.First().Count);
        }
    }
}
