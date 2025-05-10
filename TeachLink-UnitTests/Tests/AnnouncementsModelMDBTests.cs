using TeachLink_BackEnd.Core.ModelsMDB;
using TeachLink_BackEnd.Infrastructure.GlobalHendelrs;

namespace TeachLink_UnitTests.Tests
{
    [TestClass]
    public class AnnouncementsModelMDBTests
    {
        [TestMethod]
        [DataRow("605c72ef531123456789abcd", true)]
        [DataRow("", false)]
        [DataRow(null, false)]
        public void SetIdStudent_Validation(string idStudent, bool isValid)
        {
            var model = new AnnouncementsModelMDB();

            if (isValid)
            {
                model.id_student = idStudent;
                Assert.AreEqual(idStudent, model.id_student);
            }
            else
            {
                Assert.ThrowsException<BadRequestException>(() => model.id_student = idStudent);
            }
        }

        [TestMethod]
        [DataRow("This is a valid mini description with more than 20 chars", true)]
        [DataRow("Short desc", false)]
        [DataRow("", false)]
        public void SetMiniDescription_Validation(string desc, bool isValid)
        {
            var model = new AnnouncementsModelMDB();

            if (isValid)
            {
                model.mini_description = desc;
                Assert.AreEqual(desc, model.mini_description);
            }
            else
            {
                Assert.ThrowsException<BadRequestException>(() => model.mini_description = desc);
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetDescriptionTestData), DynamicDataSourceType.Method)]
        public void SetDescription_Validation(string desc, bool isValid)
        {
            var model = new AnnouncementsModelMDB();

            if (isValid)
            {
                model.description = desc;
                Assert.AreEqual(desc, model.description);
            }
            else
            {
                Assert.ThrowsException<BadRequestException>(() => model.description = desc);
            }
        }

        public static IEnumerable<object[]> GetDescriptionTestData()
        {
            yield return new object[] { new string('a', 100), true };
            yield return new object[] { new string('a', 99), false };
            yield return new object[] { new string('a', 500), true };
            yield return new object[] { new string('a', 501), false };
            yield return new object[] { "", false };
        }


    }
}


