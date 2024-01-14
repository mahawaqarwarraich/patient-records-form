using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlsTutorial
{

    public enum GENDERTYPE
    {
        MALE, 
        FEMALE
    }
    internal class Patient
    {

        // Properties
        // Implicity property
        public string Name { get; set; }

        public int Id { get; set; }

        public DateTime DoB {  get; set; }
        public GENDERTYPE Gender {  get; set; }
        public string Email {  get; set; }

        // Constructor
        // Simple
        public Patient()
        {
            Name = "No Name";
            Id = 0;
            DoB = DateTime.Now;
            Gender = GENDERTYPE.MALE;
            Email = "abc@gmail.com";

        }

        // Parameterized constructor
        public Patient(string name, int id, DateTime dob, GENDERTYPE gender, string email)
        {
            Name = name;
            Id = id;
            DoB = dob;
            Gender = gender;
            Email = email;
        }
    }
}
