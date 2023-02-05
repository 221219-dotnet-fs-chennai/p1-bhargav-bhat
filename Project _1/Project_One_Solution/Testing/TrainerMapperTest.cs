using Business_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class TrainerMapperTest
    {
        public void Setup()
        {
        }

        [Test]

        public void TrainerTest()
        {
            //Arrange
            Fluent_API.Entities.Trainer t=new Fluent_API.Entities.Trainer();

            var modeldata = Mapper.Map(t);
            //Assert
            Assert.AreEqual(modeldata.GetType(), typeof(Models.Trainer));
        }
    }
}
