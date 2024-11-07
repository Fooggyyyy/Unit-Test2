using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace Programm
{
    [TestClass]
    public class RegUserTest
    {
        private RegisterClass manager = new RegisterClass();

        [TestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void RegUser(string name, string phone, string gmail)
        {
            bool result = manager.AddUser(name, phone, gmail);
            Assert.IsTrue(result);
        }

        public static IEnumerable<object[]> GetTestData()
        {
            string filePath = "C:\\Users\\user\\source\\repos\\UnitTestCalsTeach\\User.xml";

            XDocument doc = XDocument.Load(filePath);
            foreach (var user in doc.Descendants("User"))
            {
                string name = user.Attribute("name")?.Value;
                string phone = user.Attribute("tel")?.Value;
                string gmail = user.Attribute("gmail")?.Value;
                yield return new object[] { name, phone, gmail };
            }
        }
    }

    [TestClass]
    public class CalcTests
    {
        public TestContext TestContext { get; set; } 

        [TestMethod]
        public void Sum_10plus20_return30()
        {
            //Arrange
            int x = 10;
            int y = 20;
            int excpected = 30;

            //Act
            int actual = Calc.Sum(x, y);

            //Assert
            Assert.AreEqual(excpected, actual);

            TestContext.WriteLine($"TestContext test-name: {TestContext.TestName}");
            TestContext.WriteLine($"TestContext test-directory: {TestContext.TestRunDirectory}");
            TestContext.WriteLine($"TestContext test-class-name: {TestContext.FullyQualifiedTestClassName}");
        }

        [TestMethod]
        public void Minus_40minus5_return35()
        {
            //Arrange
            int x = 40;
            int y = 5;
            int excpected = 35;

            //Act
            int actual = Calc.Minus(x, y);

            //Assert
            Assert.AreEqual(excpected, actual);
        }
    }

    [TestClass]
    public class ItemTest
    {
        Items<string> actual = new Items<string>();

        //����������� ��� ������ ������ ������-�����
        [TestInitialize]
        public void Init()
        {
            actual.Add("Bread");
            actual.Add("Milk");
            actual.Add("Beer");
        }

        //����������� ��� ������ ��������� ������-�����
        [TestCleanup]
        public void Cleanup()
        {
            actual.Clear();
        }

        [TestMethod]
        public void Add_AddItem_Equals()
        {
            //Arrange
            Items<string> expected = new Items<string>(new List<string>() { "Bread", "Milk", "Beer" });

            //Act
            bool flag = true;
            if (expected.Count() != actual.Count())
                flag = false;
            for (int i = 0; i < expected.Count(); i++)
            {
                if (expected[i] != actual[i])
                    flag = false;
            }

            //Assert
            Assert.IsTrue(flag);
        }
    }

    [TestClass]
    public class PeopleTest
    {
        static People people1 = new People();
        //����������� ������������ ��� ��� ������ ������� ������-�����, � ���������� ��������� TestContext
        [ClassInitialize]
        public static void InitClass(TestContext context)
        {
            people1.ReName("John");
            people1.ReAge(19);
        }

        [ClassCleanup]
        //����������� ������������ ��� ��� ���������� ���������� ������-�����
        public static void ClearClass()
        {
            people1.ClearPeople();
        }

        [TestMethod]
        public void SameName_JohnEqualJohn_true()
        {
            //Arrange
            var John = new People("John", 25);
            //Act
            bool flag = John.SameName(people1);

            //Assert
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void SameAge_19Equal19_true()
        {
            //Arrange
            var Marry = new People("Marry", 19);
            //Act
            bool flag = Marry.SameAge(people1);

            //Assert
            Assert.IsTrue(flag);
        }

        //�� ����� ��������� ������� �� �������� ���� �������

        //����������� ��� ������ ������� ������ ������-����� ������ ������ ������������ ���, � ���������� ��������� TestContext
        [AssemblyInitialize]
        public static void AssInit(TestContext context) { }

        //����������� ��� ��������� ������� ������ ������-����� ������ ������ ������������ ���
        [AssemblyCleanup]
        public static void AssCleanup() { }
    }

    [TestClass]
    public class EasyClassTests
    {
        [TestMethod]
        public void GetSQRT_16sqrt_return4()
        {
            //Arrange
            int x = 16;
            double excpected = 4;
            //Act
            double actual = EasyClass.Get_SQRT(x);

            //Assert

            //���������, ���� ��������� ������
            Assert.AreEqual(excpected, actual, "������ {0} ���� {1}, � �� ������� {2}", x, actual, excpected);
        }

        [TestMethod]
        public void GetSQRT_10sqrt_return3with1()
        {
            //Arrange
            double excpected = 3.1;
            double delta = 0.07;
            //Act
            double actual = EasyClass.Get_SQRT(10);

            //Assert

            //delta - ����������� �����������, ��� �� ��������� ��� ������
            Assert.AreEqual(excpected, actual, delta, "�� ���������");
        }

        [TestMethod]
        public void SayHello_JohnANDJHON_true()
        {
            //Arrange
            string x = "JOHN";
            string excpected = "Hello, John";

            //Act
            string actual = EasyClass.SayHello(x);

            //Assert

            //������������� ��������� ���� true
            Assert.AreEqual(excpected, actual, true);
        }

        [TestMethod]
        public void JohnANDJhon_true()
        {
            //Arrange
            string x = "Hello";
            string y = "Hello";

            //Assert
            //�������� ��������� ������
            Assert.AreSame(x, y);

            //��� �� ��������� ����� �� ��������
        }

        //���� ���������, ���� ����� Exception

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void Null()
        {
            string x = null;
            EasyClass.SayHello(x);
        }
    }

    [TestClass]
    public class ListCollectionTest
    {
        static List<string> items;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            items = new List<string>();
            items.Add("Bread");
            items.Add("Milk");
            items.Add("Chips");
        }

        [TestMethod]
        public void AllItemsAreNotNull()
        {
            //��������, ��� �� ��������� � null
            CollectionAssert.AllItemsAreNotNull(items, "���� �������� � null");
        }

        [TestMethod]
        public void AllItemsAreUnique()
        {
            //��������, ��� �� �������� �������������
            CollectionAssert.AllItemsAreUnique(items, "���� ���������� ��������");
        }

        [TestMethod]
        public void AreEqual()
        {
            var items1 = new List<string>();
            items1.Add("Bread");
            items1.Add("Milk");
            items1.Add("Chips");
            //items1.Add("Beer");

            //��������, ��� �� �������� ��������� �����
            //����, ��� �� ������� ��������� ���� ���������
            CollectionAssert.AreEqual(items1, items);
        }

        [TestMethod]
        public void AreEquavalent()
        {
            var items1 = new List<string>();
            items1.Add("Milk");
            items1.Add("Bread");
            items1.Add("Chips");

            //��������, ��� �� �������� ��������� �����
            //������� �� �����
            CollectionAssert.AreEquivalent(items1, items);
        }
    }

    [TestClass]
    public class StringAssertTest
    {
        [TestMethod]
        public void StringContains()
        {
            StringAssert.Contains("Hello", "ello");
        }

        [TestMethod]
        public void StartWith()
        {
            StringAssert.StartsWith("Hello John", "Hello");
        }
    }
}