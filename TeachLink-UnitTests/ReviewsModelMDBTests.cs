using TeachLink_BackEnd.Core.ModelsMDB;

namespace TeachLink_UnitTests
{
    [TestClass]
    public class ReviewsModelMDBTests
    {
        [TestMethod]
        [DataRow("507f1f77bcf86cd799439011", true)]
        [DataRow("", false)]
        [DataRow(null, false)]
        public void IdTeacher_SetValue_Validation(string value, bool isValid)
        {
            var model = new ReviewsModelMDB();
            if (isValid)
            {
                model.id_teacher = value;
                Assert.AreEqual(value, model.id_teacher);
            }
            else
            {
                Assert.ThrowsException<ArgumentException>(() => model.id_teacher = value);
            }
        }

        [TestMethod]
        [DataRow("507f1f77bcf86cd799439011", true)]
        [DataRow("", false)]
        [DataRow(null, false)]
        public void IdStudent_SetValue_Validation(string value, bool isValid)
        {
            var model = new ReviewsModelMDB();
            if (isValid)
            {
                model.id_student = value;
                Assert.AreEqual(value, model.id_student);
            }
            else
            {
                Assert.ThrowsException<ArgumentException>(() => model.id_student = value);
            }
        }

        [TestMethod]
        [DataRow(1, true)]
        [DataRow(5, true)]
        [DataRow(0, false)]
        [DataRow(6, false)]
        public void Rating_SetValue_Validation(int rating, bool isValid)
        {
            var model = new ReviewsModelMDB();
            if (isValid)
            {
                model.rating = rating;
                Assert.AreEqual(rating, model.rating);
            }
            else
            {
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => model.rating = rating);
            }
        }

        public static IEnumerable<object[]> GetReviewTexts()
        {
            yield return new object[] { "Good teacher!", true };
            yield return new object[] { "", false };
            yield return new object[] { null, false };
            yield return new object[] { new string('a', 100), true };
            yield return new object[] { new string('a', 101), false };
        }

        [TestMethod]
        [DynamicData(nameof(GetReviewTexts), DynamicDataSourceType.Method)]
        public void ReviewsText_SetValue_Validation(string text, bool isValid)
        {
            var model = new ReviewsModelMDB();
            if (isValid)
            {
                model.reviews_text = text;
                Assert.AreEqual(text, model.reviews_text);
            }
            else
            {
                Assert.ThrowsException<ArgumentException>(() => model.reviews_text = text);
            }
        }
    }
}


