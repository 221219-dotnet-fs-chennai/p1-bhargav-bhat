using Business_Logic;

namespace Testing
{
    public class GenderTest
    {
        public void Setup()
        {

        }
        [Test]
        [TestCase("Male", true)]
        [TestCase("Female",true)]
        [TestCase("female", true)]
        [TestCase("male", true)]
        [TestCase("F", false)]
        [TestCase("M", false)]

        public void GenderCheck(string g, bool s)
        {
            //Arrange
            var result = Validation.Gender(g);
            //Assert
            Assert.AreEqual(result, s);
        }
    }
}
