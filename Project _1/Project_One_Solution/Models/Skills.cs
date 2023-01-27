using System;


namespace Models
{
    public class Skills
    {
        public Skills()
        {
        }
        public string skillName { get; set; }

        public override string ToString()
        {
            return $"{skillName}";
        }
    }
}
