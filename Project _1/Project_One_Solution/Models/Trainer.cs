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
        public string gender;
        public string Gender 
        {
            get
            {
                return gender;
            }
            set
            {
                string pattern = @"^((M|m)ale)|((F|f)emale)$";
                var IsEmailCheck = Regex.IsMatch(value, pattern);
                if (IsEmailCheck)
                {
                    gender = value;
                }
                else
                {
                    throw new InvalidDataException("Invalid Data, Please try again");
                }
            }
        }
        public string email;
        public string Email 
        {
            get
            {
                return email;
            }
            set
            {
                string pattern = @"^(([a-zA-Z]+)(\d+)?)@([a-zA-Z]+).([a-zA-Z]{2,4})$";
                var IsEmailCheck = Regex.IsMatch(value, pattern);
                if (IsEmailCheck)
                {
                    email = value;
                }
                else
                {
                    throw new InvalidDataException("Invalid Data, Please try again");
                }
            }
        }

        public string Password { set; get; }=null!;
        
        public string phone;
        public string Phone 
        { 
            get
            {
                return phone;
            }
            set
            {
                string pattern = @"^[6-9]\d{9}$";
                var IsEmailCheck = Regex.IsMatch(value, pattern);
                if (IsEmailCheck)
                {
                    phone = value;
                }
                else
                {
                    throw new InvalidDataException("Invalid Data, Please try again");
                }
            }
        }
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