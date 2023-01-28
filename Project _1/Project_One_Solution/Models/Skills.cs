using System;


namespace Models
{
    public class Skills
    {
        public Skills()
        {
            this.skillName = skillName;
        }
        public int Id { get; set; }
        public int trainerID {get; set; }
        public string skillName { get; set; }

        public override string ToString()
        {
            return $"{skillName}";
        }
    }
}
