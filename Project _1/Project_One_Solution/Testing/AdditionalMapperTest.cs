using Business_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class AdditionalMapperTest
    {
        public void Setup()
        {
        }

        [Test]

        public void AdditonalTest()
        {
            //Arrange
            Fluent_API.Entities.AdditionalDetail a = new Fluent_API.Entities.AdditionalDetail();


            var modeldata = Mapper.Map(a);
            //Assert
            Assert.AreEqual(modeldata.GetType(), typeof(Models.Additional));
        }
    }
}
