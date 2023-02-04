using System.Text.RegularExpressions;

namespace Models
{
    public class Trainer
    {
        public Trainer()
        {
        }
        public int Id { get; set; }
        public string firstName { set; get; }
        public string lastName { set; get; }
        public string Gender { get; set; } = null!;
        public string Email { set; get; } = null!;
        public string Password { set; get; }=null!;
        public string Phone { set; get; } = null!;
        public string City { set; get; }
        public string State { set; get; }
        public string Country { set; get; }
        public string Aboutme { set; get; }

        public override string ToString()
        {
            return $"Name : {firstName} {lastName}\nGender : {Gender}\nEmail : {Email}\nPhone : {Phone}\nCity : {City}\nState : {State}\nCountry : {Country}\nAbout Me : {Aboutme}";
        }
    }
}