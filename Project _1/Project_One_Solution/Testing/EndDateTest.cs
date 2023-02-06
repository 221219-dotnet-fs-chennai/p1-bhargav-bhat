using Business_Logic;

namespace Testing
{
    public class EndDateTest
    {
        public void Setup()
        {
        }

        [Test]
        [TestCase("12/2022", true)]
        [TestCase("13/2022", false)]

        public void StartDaterChecker(string enddate, bool s)
        {
            //Arrange
            var result = Validation.enddate(enddate);
            //Assert
            Assert.AreEqual(result, s);
        }
    }
}
