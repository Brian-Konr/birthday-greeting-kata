namespace BirthdayGreetingKataService.Models
{
    /// <summary>
    /// 每一個 Member 物件對應到資料庫的一筆 data row
    /// </summary>
    public class Member
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Gender { get; set; }

        public DateTime DateofBirth { get; set; }

        public string Email { get; set; }

        public Member(string lastName, string firstName, string gender, DateTime dateofBirth, string email)
        {
            LastName = lastName;
            FirstName = firstName;
            Gender = gender;
            DateofBirth = dateofBirth;
            Email = email;
        }
    }
}
