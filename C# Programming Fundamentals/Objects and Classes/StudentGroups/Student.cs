using System;

namespace StudentGroups
{
    public class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }

        public Student(string name, string email, DateTime register)
        {
            Name = name;
            Email = email;
            RegistrationDate = register;
        }
    }
}