using Business_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class WorkMapperTest
    {
        public void Setup()
        {
        }

        [Test]

        public void WorkTest()
        {
            //Arrange
            Fluent_API.Entities.WorkExperience w = new Fluent_API.Entities.WorkExperience();

            var modeldata = Mapper.Map(w);
            //Assert
            Assert.AreEqual(modeldata.GetType(), typeof(Models.WorkE));
        }
    }
}
