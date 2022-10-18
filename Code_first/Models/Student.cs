using Code_first.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Code_first.Models

{
    public class Student
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        [RegularExpression(@"^([A-Za-z]+)$")]
        public string Name { get; set; }

        [Range(21, 58, ErrorMessage = "Enter age between 21 to 58")]
        public int TraineeAge { get; set; }

        public DateTime DOJ { get; set; }
        public DateTime DOB { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter the Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter the Confirm Password")]
        [Compare("TraineePassword", ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; }

    }

   
}
