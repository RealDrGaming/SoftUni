namespace Database.Tests
{
    using Newtonsoft.Json.Converters;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database();
        }

        [TearDown]
        public void TearDown()
        {
            database = null;
        }

        [Test]
        public void TestAddElementMethod()
        {
            database.Add(3);
            int[] result = database.Fetch();

            Assert.That(1, Is.EqualTo(database.Count));
            Assert.That(3, Is.EqualTo(result[0]));
            Assert.That(1, Is.EqualTo(result.Length));
        }

        [Test]
        public void TestAddElementThrowExceptionMoreThanMaxLength()
        {
            database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => database.Add(17));

            Assert.That(exception.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void TestDatabaseCreatingWithCorrectNumberOfElements()
        {
            database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            Assert.That(10, Is.EqualTo(database.Count));
        }

        [Test]
        public void TestRemoveElementThrowExceptionRemoveFromEmptyCollection()
        {
            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => database.Remove());

            Assert.That(exception.Message, Is.EqualTo("The collection is empty!"));
        }

        [Test]
        public void TestRemoveElementMethod()
        {
            database = new Database(7, 12);

            database.Remove();
            var result = database.Fetch();

            Assert.That(1, Is.EqualTo(database.Count));
            Assert.That(1, Is.EqualTo(result.Length));
            Assert.That(7, Is.EqualTo(result[0]));
        }

        [Test]
        public void TestFetchDatabaseMethod()
        {
            database = new Database(1, 2, 3);

            var result = database.Fetch();

            Assert.That(new int[] {1, 2, 3}, Is.EquivalentTo(result));
        }
    }
}
