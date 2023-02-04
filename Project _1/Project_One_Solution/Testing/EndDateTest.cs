using Business_Logic;

namespace Testing
{
    public class EndDateTest
    {
        public void Setup()
        {
        }

        [Test]
        [TestCase("12/2022", "12/2022")]
        [TestCase("13/2022", null)]

        public void StartDaterChecker(string enddate, string expected)
        {
            //Arrange
            var result = Validation.enddate(enddate);
            //Assert
            Assert.AreEqual(result, expected);
        }
    }
}
