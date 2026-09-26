using System.Collections.Generic;

namespace SchoolManagementSystem.Models
{
    public class Student
    {
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Dob { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Qualification> Qualifications { get; set; } = new List<Qualification>();
    }

    public class Qualification
    {
        public string Course { get; set; }
        public string University { get; set; }
        public int Year { get; set; }
        public decimal Percentage { get; set; }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
