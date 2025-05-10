using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Infrastructure.GlobalHendelrs;

namespace TeachLink_UnitTests.Tests
{
    [TestClass]
    public sealed class TeachersModelMDBTests
    {


        [TestMethod]
        [DataRow("Иван Иванов", true)]
        [DataRow("John Doe", true)]
        [DataRow("", false)]
        [DataRow("1234", false)]
        public void Test_FullName_Validation(string name, bool isValid)
        {
            var teacher = new TeachersModelMDB();

            if (isValid)
            {
                teacher.full_name = name;
                Assert.AreEqual(name, teacher.full_name);
            }
            else
            {
                Assert.ThrowsException<BadRequestException>(() => teacher.full_name = name);
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetMiniDescriptionData), DynamicDataSourceType.Method)]
        public void Test_MiniDescription_Validation(string value, bool isValid)
        {
            var teacher = new TeachersModelMDB();

            if (isValid)
            {
                teacher.mini_description = value;
                Assert.AreEqual(value, teacher.mini_description);
            }
            else
            {
                Assert.ThrowsException<BadRequestException>(() => teacher.mini_description = value);
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetDescriptionData), DynamicDataSourceType.Method)]
        public void Test_Description_Validation(string value, bool isValid)
        {
            var teacher = new TeachersModelMDB();

            if (isValid)
            {
                teacher.description = value;
                Assert.AreEqual(value, teacher.description);
            }
            else
            {
                Assert.ThrowsException<BadRequestException>(() => teacher.description = value);
            }
        }

        [TestMethod]
        [DataRow(2020, true)]
        [DataRow(1899, false)]
        [DataRow(2100, false)]
        public void Test_YearOfEnd_Validation(int year, bool isValid)
        {
            var teacher = new TeachersModelMDB();

            if (isValid)
            {
                teacher.year_of_end = year;
                Assert.AreEqual(year, teacher.year_of_end);
            }
            else
            {
                Assert.ThrowsException<BadRequestException>(() => teacher.year_of_end = year);
            }
        }

        [TestMethod]
        [DataRow(25, true)]
        [DataRow(18, false)]
        [DataRow(10, false)]
        public void Test_Age_Validation(int age, bool isValid)
        {
            var teacher = new TeachersModelMDB();

            if (isValid)
            {
                teacher.age = age;
                Assert.AreEqual(age, teacher.age);
            }
            else
            {
                Assert.ThrowsException<BadRequestException>(() => teacher.age = age);
            }
        }

        [TestMethod]
        [DataRow(150, true)]
        [DataRow(100, true)]
        [DataRow(99, false)]
        public void Test_Price_Validation(int price, bool isValid)
        {
            var teacher = new TeachersModelMDB();

            if (isValid)
            {
                teacher.price = price;
                Assert.AreEqual(price, teacher.price);
            }
            else
            {
                Assert.ThrowsException<BadRequestException>(() => teacher.price = price);
            }
        }
        public static IEnumerable<object[]> GetMiniDescriptionData() => new List<object[]>
        {
            new object[] { "Краткое описание", true },
            new object[] { "", true },
            new object[] { new string('a', 101), false },
        };

        public static IEnumerable<object[]> GetDescriptionData() => new List<object[]>
        {
            new object[] { "Полное описание", true },
            new object[] { "", true },
            new object[] { new string('a', 501), false },
        };
    }

}
