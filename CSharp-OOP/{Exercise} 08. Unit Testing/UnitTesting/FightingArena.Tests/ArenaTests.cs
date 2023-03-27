namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [TearDown]
        public void TearDown()
        {
            arena = null;
        }

        [Test]
        public void TestArenaShouldBeVoidOnCreate()
        {
            arena = new Arena();

            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void TestEnrollShouldAddWarrior()
        {
            arena.Enroll(new Warrior("Pesho", 5, 12));

            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void TestEnrollShouldThrowIfWarriorNameIsNotUnique()
        {
            arena.Enroll(new Warrior("Pesho", 5, 12));

            InvalidOperationException exception = Assert
                .Throws<InvalidOperationException>(() => arena.Enroll(new Warrior("Pesho", 5, 12)));
            Assert.That(exception.Message, Is.EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void TestFightShouldThrowIfDefenderIsMissing()
        {
            arena.Enroll(new Warrior("Pesho", 5, 12));

            InvalidOperationException exception = Assert
                .Throws<InvalidOperationException>(() => arena.Fight("Pesho", "Gosho"));
            Assert.That(exception.Message, Is.EqualTo("There is no fighter with name Gosho enrolled for the fights!"));
        }

        [Test]
        public void TestFightShouldThrowIfAttackerIsMissing()
        {
            arena.Enroll(new Warrior("Pesho", 5, 12));

            InvalidOperationException exception = Assert
                .Throws<InvalidOperationException>(() => arena.Fight("Misho", "Pesho"));
            Assert.That(exception.Message, Is.EqualTo("There is no fighter with name Misho enrolled for the fights!"));
        }

        [Test]
        public void TestFight()
        {
            var attacker = new Warrior("Pesho", 15, 35);
            var defender = new Warrior("Gosho", 15, 45);
            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(20, attacker.HP);
            Assert.AreEqual(30, defender.HP);
        }
    }
}
