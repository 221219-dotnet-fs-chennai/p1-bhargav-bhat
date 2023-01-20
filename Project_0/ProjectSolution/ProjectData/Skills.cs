using System.Security.Cryptography.X509Certificates;

namespace ProjectData
{
    public class Skills
    {
        public Skills() 
        {
        }
        public int Id { get; set; }
        public string skillName { get; set; }

        public override string ToString()
        {
            return $"{skillName}";
        }

    }
}