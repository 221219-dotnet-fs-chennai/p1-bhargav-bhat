using Business_Logic;

namespace Testing
{
    public class GenderTest
    {
        public void Setup()
        {

        }
        [Test]
        [TestCase("Male", "Male")]
        [TestCase("Female","Female")]
        [TestCase("female", "female")]
        [TestCase("male", "male")]
        [TestCase("F", null)]
        [TestCase("M", null)]

        public void GenderCheck(string g, string expected)
        {
            //Arrange
            var result = Validation.Gender(g);
            //Assert
            Assert.AreEqual(result, expected);
        }
    }
}
