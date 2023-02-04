using Business_Logic;

namespace Testing
{
    public class StartDateTest
    {
        public void Setup()
        {
        }

        [Test]
        [TestCase("12/2022", "12/2022")]
        [TestCase("13/2022", null)]

        public void StartDaterChecker(string start_date, string expected)
        {
            //Arrange
            var result = Validation.startdate(start_date);
            //Assert
            Assert.AreEqual(result, expected);
        }
    }
}
