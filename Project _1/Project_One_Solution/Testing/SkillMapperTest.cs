using Business_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class SkillMapperTest
    {
        public void Setup()
        {
        }

        [Test]

        public void TrainerTest()
        {
            //Arrange
            Fluent_API.Entities.Skill s = new Fluent_API.Entities.Skill();

            var modeldata = Mapper.Map(s);
            //Assert
            Assert.AreEqual(modeldata.GetType(), typeof(Models.Skills));
        }
    }
}
