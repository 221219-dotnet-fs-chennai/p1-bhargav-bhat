using Business_Logic;

namespace Testing
{
    public class StartDateTest
    {
        public void Setup()
        {
        }

        [Test]
        [TestCase("12/2022", true)]
        [TestCase("13/2022", false)]

        public void StartDaterChecker(string start_date, bool s)
        {
            //Arrange
            var result = Validation.startdate(start_date);
            //Assert
            Assert.AreEqual(result, s);
        }
    }
}
