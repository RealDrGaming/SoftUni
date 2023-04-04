using NUnit.Framework;
using System;
using System.Numerics;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Shop shop;

        [TearDown]
        public void Test_TearDown()
        {
            shop = null;
        }

        [Test]
        public void Test_ShopConstructor()
        {
            shop = new Shop(3);

            Assert.IsNotNull(shop);
            Assert.That(shop.Capacity, Is.EqualTo(3));
            Assert.That(shop.Count, Is.EqualTo(0));
        }

        [TestCase(-10)]
        [TestCase(-3)]
        public void Test_InvalidCapacity(int capacity) 
        {
            Assert.Throws<ArgumentException>(
                () => new Shop(capacity),
                $"Invalid capacity.");
        }

        [Test]
        public void Test_ShopAddMethodWorksCorrectly() 
        {
            shop = new Shop(2);
            Smartphone smartphone1 = new Smartphone("Iphone13ProMax", 13);

            shop.Add(smartphone1);

            Assert.That(shop.Count, Is.EqualTo(1));
        }

        [Test]
        public void Test_ShopAddMethodThrowsErrorTwoIdenticalPhones()
        {
            shop = new Shop(2);
            Smartphone smartphone1 = new Smartphone("Iphone13ProMax", 13);

            shop.Add(smartphone1);

            Assert.Throws<InvalidOperationException>(
                () => shop.Add(smartphone1),
                $"The phone model {smartphone1.ModelName} already exist.");
        }

        [Test]
        public void Test_ShopAddMethodThrowsErrorFullCapacity()
        {
            shop = new Shop(2);
            Smartphone smartphone1 = new Smartphone("Iphone13ProMax", 13);
            Smartphone smartphone2 = new Smartphone("SamsungGalaxy12", 14);
            Smartphone smartphone3 = new Smartphone("HuaweiHero13", 16);

            shop.Add(smartphone1);
            shop.Add(smartphone2);

            Assert.Throws<InvalidOperationException>(
                () => shop.Add(smartphone3),
                $"The shop is full.");
        }

        [Test]
        public void Test_ShopRemoveMethodWorksCorrectly()
        {
            shop = new Shop(2);
            Smartphone smartphone1 = new Smartphone("Iphone13ProMax", 13);
            Smartphone smartphone2 = new Smartphone("SamsungGalaxy12", 14);

            shop.Add(smartphone1);
            shop.Add(smartphone2);

            shop.Remove("Iphone13ProMax");

            Assert.That(shop.Count, Is.EqualTo(1));
        }

        [Test]
        public void Test_ShopRemoveMethodThrowsErrorModelDoesntExist()
        {
            shop = new Shop(2);
            Smartphone smartphone1 = new Smartphone("Iphone13ProMax", 13);

            shop.Add(smartphone1);

            string invalidModelName = "HuaweiP20";

            Assert.Throws<InvalidOperationException>(
                () => shop.Remove(invalidModelName),
                $"The phone model {invalidModelName} doesn't exist.");
        }

        [Test]
        public void Test_ShopTestPhoneMethodWorksCorrectly()
        {
            shop = new Shop(2);
            Smartphone smartphone1 = new Smartphone("Iphone13ProMax", 13);

            shop.Add(smartphone1);

            shop.TestPhone(smartphone1.ModelName, 9);

            Assert.That(4, Is.EqualTo(smartphone1.CurrentBateryCharge));
        }

        [Test]
        public void Test_ShopTestPhoneMethodThrowsErrorModelDoesntExist()
        {
            shop = new Shop(2);
            Smartphone smartphone1 = new Smartphone("Iphone13ProMax", 13);

            shop.Add(smartphone1);

            string invalidModelName = "HuaweiP20";

            Assert.Throws<InvalidOperationException>(
                () => shop.TestPhone(invalidModelName, 7),
                $"The phone model {invalidModelName} doesn't exist.");
        }

        [Test]
        public void Test_ShopTestPhoneMethodThrowsErrorNotEnoughBattery()
        {
            shop = new Shop(2);
            Smartphone smartphone1 = new Smartphone("Iphone13ProMax", 13);

            shop.Add(smartphone1);

            Assert.Throws<InvalidOperationException>(
                () => shop.TestPhone(smartphone1.ModelName, 19),
                $"The phone model {smartphone1.ModelName} is low on batery.");
        }

        [Test]
        public void Test_ShopChargePhoneWorksCorrectly()
        {
            shop = new Shop(2);
            Smartphone smartphone1 = new Smartphone("Iphone13ProMax", 13);

            shop.Add(smartphone1);

            shop.TestPhone(smartphone1.ModelName, 9);

            shop.ChargePhone(smartphone1.ModelName);

            Assert.That(13, Is.EqualTo(smartphone1.CurrentBateryCharge));
        }

        [Test]
        public void Test_ShopChargePhoneThrowsErrorPhoneDoesntExist()
        {
            shop = new Shop(2);
            Smartphone smartphone1 = new Smartphone("Iphone13ProMax", 13);

            shop.Add(smartphone1);

            string invalidModelName = "HuaweiP20";

            Assert.Throws<InvalidOperationException>(
                () => shop.ChargePhone(invalidModelName),
                $"The phone model {invalidModelName} doesn't exist.");
        }
    }
}