using Business_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class EducationMapperTest
    {
        public void Setup()
        {
        }

        [Test]

        public void EducationTest()
        {
            //Arrange
            Fluent_API.Entities.Education e = new Fluent_API.Entities.Education();

            var modeldata = Mapper.Map(e);
            //Assert
            Assert.AreEqual(modeldata.GetType(), typeof(Models.Educate));
        }
    }
}
