namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
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
            database.Add(new Person(3, "Ivan"));
            Person result = database.FindById(3);

            Assert.That(1, Is.EqualTo(database.Count));
            Assert.That(3, Is.EqualTo(result.Id));
            Assert.That("Ivan", Is.EqualTo(result.UserName));
        }

        [Test]
        public void TestAddElementThrowExceptionMoreThanMaxLength()
        {
            Person[] people = CreateFullArray();
            database = new Database(people);

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => database.Add(new Person(6, "Georgi")));

            Assert.That(exception.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void TestAddShouldThrowIfThereIsAPersonWithSameUsername() 
        {
            database.Add(new Person(1, "Galka"));

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => database.Add(new Person(6, "Galka")));

            Assert.That(exception.Message, Is.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void TestAddShouldThrowIfThereIsAPersonWithSameId()
        {
            database.Add(new Person(1, "Gatio"));

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1, "Trandi")));

            Assert.That(exception.Message, Is.EqualTo("There is already user with this Id!"));
        }

        private Person[] CreateFullArray()
        {
            Person[] people = new Person[16];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, i.ToString());
            }

            return people;
        }

        [Test]
        public void TestDatabaseCreating()
        {
            database = new Database(new Person(11, "Petur"), new Person(12, "Katerina"));
            Person firstPerson = database.FindById(11);
            Person secondPerson = database.FindById(12);

            Assert.That(2, Is.EqualTo(database.Count));
            Assert.That("Petur", Is.EqualTo(firstPerson.UserName));
            Assert.That("Katerina", Is.EqualTo(secondPerson.UserName));
        }

        [Test]
        public void TestRemoveElementThrowExceptionRemoveFromEmptyCollection()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void TestRemoveElementMethod()
        {
            database = new Database(new Person(11, "Petur"), new Person(12, "Katerina"));

            database.Remove();

            Person firstPerson = database.FindById(11); 

            Assert.That(1, Is.EqualTo(database.Count));
            Assert.That("Petur", Is.EqualTo(firstPerson.UserName));

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Katerina"));

            Assert.That(exception.Message, Is.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void TestFindByUsernameShouldThrowIfUsernameIsNullOrEmpty()
        {
            ArgumentNullException exception =
                Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));

            Assert.That(exception.ParamName, Is.EqualTo("Username parameter is null!"));

            ArgumentNullException exceptionEmpty =
                Assert.Throws<ArgumentNullException>(() => database.FindByUsername(string.Empty));

            Assert.That(exceptionEmpty.ParamName, Is.EqualTo("Username parameter is null!"));
        }

        [Test]
        public void TestFindByUsernameShouldThrowIfUsernameDoesNotExist()
        {
            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Ivanka"));

            Assert.That(exception.Message, Is.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void TestFindByUsernameReturnsCorrectUser() 
        {
            database = new Database(new Person(11, "Petur"), new Person(12, "Katerina"));

            Person person = database.FindByUsername("Katerina");

            Assert.That("Katerina", Is.EqualTo(person.UserName));
            Assert.That(12, Is.EqualTo(person.Id));
        }

        [Test]
        public void TestFindByIdShouldThrowIfIdIsLessThanZero()
        {
            ArgumentOutOfRangeException exception =
                Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-7));

            Assert.That(exception.ParamName, Is.EqualTo("Id should be a positive number!"));
        }

        [Test]
        public void TestFindByIdShouldThrowIfIdDoesNotExist()
        {
            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => database.FindById(8));

            Assert.That(exception.Message, Is.EqualTo("No user is present by this ID!"));
        }

        [Test]
        public void TestFindByIdReturnsCorrectUser()
        {
            database = new Database(new Person(11, "Petur"), new Person(12, "Katerina"));

            Person person = database.FindById(12);

            Assert.That("Katerina", Is.EqualTo(person.UserName));
            Assert.That(12, Is.EqualTo(person.Id));
        }
    }
}