using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ERecord.Models;

namespace ERecord.ViewModel
{
    public class AdminCreateViewModel
    {
        [Required]
        [StringLength(30, ErrorMessage = "Please enter between {2} to {1} Characters.", MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Please enter between {2} to {1} Characters.", MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return string.Format($"{FirstName} {LastName}"); }
        }

        [Required]
        public EnumManager.Position? Position { get; set; } = 0;

        [Required]
        public EnumManager.Gender? Gender { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public EnumManager.State? State { get; set; }

        [Required]
        public EnumManager.Country? Nationality { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Dob { get; set; }

        [Required]
        [Display(Name = "Marital Status")]
        public EnumManager.MaritalStatus? MaritalStatus { get; set; }

        [Required]
        [Display(Name = "Number of Children (if any)")]
        public int NumberOfChildren { get; set; }

        [Required]
        [Display(Name = "Date Registered")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Access")]
        public bool IsActive { get; set; }

        [Display(Name = "Employment Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? EmploymentDay { get; set; }

        [Display(Name = "School Attended")]
        public string SchoolAttended { get; set; }

        [Display(Name = "Maximum Qualification")]
        public string MaximumQulaification { get; set; }

        [Display(Name = "Service Year")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? ServiceYear { get; set; }

        [Display(Name = "Last Promoted")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? LastPromoted { get; set; }

        [Display(Name = "Yearly Salary")]
        [DisplayFormat(DataFormatString = "${0}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal YearlySalary { get; set; }
    }
}