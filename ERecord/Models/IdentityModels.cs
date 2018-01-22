using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using ERecords.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ERecord.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(30, ErrorMessage = "Please enter between {2} to {1} Characters.", MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Please enter between {2} to {1} Characters.", MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        [Display(Name = "Name")]
        public string FullName
        {
            get { return string.Format($"{FirstName} {LastName}"); }
        }

        public bool IsActive { get; set; } = false;

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public EnumManager.State? State { get; set; }

        [Required]
        public EnumManager.Country? Nationality { get; set; }

        [Required]
        public EnumManager.Gender? Gender { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-d}", ApplyFormatInEditMode = true)]
        public DateTime? Dob { get; set; }

        [Required]
        [Display(Name = "Marital Status")]
        public EnumManager.MaritalStatus? MaritalStatus { get; set; }

        [Required]
        [Display(Name = "Number of Children (if any)")]
        public int NumberOfChildren { get; set; }

        [Display(Name = "Employment Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-d}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? EmploymentDay { get; set; }

        [Display(Name = "School Attended")]
        public string SchoolAttended { get; set; }

        [Display(Name = "Maximum Qualification")]
        public string MaximumQulaification { get; set; }

        [Display(Name = "Service Year")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-d}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? ServiceYear { get; set; }

        [Display(Name = "Last Promoted")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-d}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? LastPromoted { get; set; }

        [Display(Name = "Yearly Salary")]
        [DisplayFormat(DataFormatString = "${0}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal YearlySalary { get; set; }

        [Display(Name = "Date Registered")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-d}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateCreated { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}