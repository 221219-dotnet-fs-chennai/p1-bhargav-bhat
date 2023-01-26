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
        public string Gender { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string Phone { set; get; }
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