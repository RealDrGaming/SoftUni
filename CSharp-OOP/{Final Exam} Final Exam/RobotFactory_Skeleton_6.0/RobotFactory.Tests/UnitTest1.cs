using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Reflection;

namespace RobotFactory.Tests
{
    public class Tests
    {
        [Test]
        public void Test_FactoryConstructor() 
        {
            string expectedName = "Kremikovci";
            int expectedCapacity = 20;

            Factory factory = new Factory(expectedName, expectedCapacity);

            Assert.That(factory.Name, Is.EqualTo(expectedName));
            Assert.That(factory.Capacity, Is.EqualTo(expectedCapacity));

            Assert.That(factory.Robots.Count, Is.EqualTo(0));
            Assert.That(factory.Supplements.Count, Is.EqualTo(0));
        }

        [Test]
        public void Test_RobotConstructor()
        {
            string model = "Apple I2";
            int price = 1300;
            int interfaceStandard = 600;

            Robot robot = new Robot(model, price, interfaceStandard);

            Assert.That(robot.Model, Is.EqualTo(model)); 
            Assert.That(robot.Price, Is.EqualTo(price));
            Assert.That(robot.InterfaceStandard, Is.EqualTo(interfaceStandard));
        }

        [Test]
        public void Test_FactoryProduceRobotMethodWorksCorrectly()
        {
            string name = "Kremikovci";
            int capacity = 2;
            Factory factory = new Factory(name, capacity);

            Assert.That(factory.ProduceRobot("Apple I", 1000, 500), Is.EqualTo($"Produced --> Robot model: Apple I IS: 500, Price: {1000:f2}"));
            Assert.That(factory.ProduceRobot("Apple II", 1100, 600), Is.EqualTo($"Produced --> Robot model: Apple II IS: 600, Price: {1100:f2}"));
           
            Assert.That(factory.Robots.Count, Is.EqualTo(2));
            Assert.That(factory.Supplements.Count, Is.EqualTo(0));
        }

        [Test]
        public void Test_FactoryProduceRobotMethodThrowsErrorMoreRobotsThanCapacity()
        {
            string name = "Kremikovci";
            int capacity = 2;

            Factory factory = new Factory(name, capacity);

            factory.ProduceRobot("Apple I", 1000, 500);
            factory.ProduceRobot("Apple II", 1100, 600);

            Assert.That(factory.ProduceRobot("Apple X", 1400, 900), Is.EqualTo($"The factory is unable to produce more robots for this production day!"));
        }

        [Test]
        public void Test_SupplementConstructor()
        {
            string name = "Giga Arm Laser";
            int interfaceStandard = 400;

            Supplement supplement = new Supplement(name, interfaceStandard);

            Assert.That(supplement.Name, Is.EqualTo(name));
            Assert.That(supplement.InterfaceStandard, Is.EqualTo(interfaceStandard));
        }

        [Test]
        public void Test_FactoryProduceSupplementMethodWorksCorrectly2()
        {
            string name = "Kremikovci";
            int capacity = 2;
            Factory factory = new Factory(name, capacity);

            Assert.That(factory.ProduceSupplement("Giga Arm Laser", 400), Is.EqualTo($"Supplement: Giga Arm Laser IS: 400"));
            Assert.That(factory.ProduceSupplement("Water Cooling", 300), Is.EqualTo($"Supplement: Water Cooling IS: 300"));

            Assert.That(factory.Robots.Count, Is.EqualTo(0));
            Assert.That(factory.Supplements.Count, Is.EqualTo(2));
        }

        [Test]
        public void Test_FactoryUpgradeRobotMethodWorksCorrectly()
        {
            string name = "Kremikovci";
            int capacity = 2;
            Factory factory = new Factory(name, capacity);

            Robot robot = new Robot("Apple XI", 1500, 950);
            Supplement supplement = new Supplement("Giga Arm Laser Mark II", 950);

            Assert.That(factory.UpgradeRobot(robot, supplement), Is.EqualTo(true));
        }

        [Test]
        public void Test_FactoryUpgradeRobotMethodReturnsFalseWhenNeeded()
        {
            string name = "Kremikovci";
            int capacity = 2;
            Factory factory = new Factory(name, capacity);

            Robot robot = new Robot("Apple X", 1400, 900);
            Supplement supplement = new Supplement("Giga Arm Laser", 400);

            Robot robot2 = new Robot("Apple XI", 1500, 950);
            Supplement supplement2 = new Supplement("Giga Arm Laser Mark II", 950);

            Assert.That(factory.UpgradeRobot(robot2, supplement2), Is.EqualTo(true));

            Assert.That(factory.UpgradeRobot(robot, supplement), Is.EqualTo(false));
            Assert.That(factory.UpgradeRobot(robot2, supplement2), Is.EqualTo(false));
        }

        [Test]
        public void Test_FactorySellRobotMethodWorksCorrectly()
        {
            string name = "Kremikovci";
            int capacity = 4;
            Factory factory = new Factory(name, capacity);

            factory.ProduceRobot("Apple I", 1000, 500);
            factory.ProduceRobot("Apple II", 1100, 600);
            factory.ProduceRobot("Apple X", 1400, 900);

            Assert.That(factory.SellRobot(1050).Model, Is.EqualTo("Apple I"));
            Assert.That(factory.SellRobot(1050).Price, Is.EqualTo(1000));
            Assert.That(factory.SellRobot(1050).InterfaceStandard, Is.EqualTo(500));

            Assert.That(factory.Robots.Count, Is.EqualTo(3));
        }

        [Test]
        public void Test_RobotToString()
        {
            string model = "Apple I2";
            int price = 1300;
            int interfaceStandard = 600;

            Robot robot = new Robot(model, price, interfaceStandard);

            Assert.That(robot.ToString(), Is.EqualTo($"Robot model: {model} IS: {interfaceStandard}, Price: {price:f2}"));
        }

        [Test]
        public void Test_SupplementToString()
        {
            string name = "Giga Arm Laser";
            int interfaceStandard = 400;

            Supplement supplement = new Supplement(name, interfaceStandard);

            Assert.That(supplement.ToString(), Is.EqualTo($"Supplement: {name} IS: {interfaceStandard}"));
        }

        [Test]
        public void Test_FactoryNameSetter()
        {
            string name = "Kremikovci";
            int capacity = 4;
            Factory factory = new Factory(name, capacity);

            factory.Name = "ATZ";

            Assert.That(factory.Name, Is.EqualTo("ATZ"));
        }

        [Test]
        public void Test_FactoryCapacitySetter()
        {
            string name = "Kremikovci";
            int capacity = 4;
            Factory factory = new Factory(name, capacity);

            factory.Capacity = 6;

            Assert.That(factory.Capacity, Is.EqualTo(6));
        }
    }
}