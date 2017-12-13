using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using PickMeUp.Entity;
using System;

namespace PickMeUp.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }

    public class ChangeAdminDetailsViewModel
    {
        public ChangeAdminDetailsViewModel()
        {

        }

        public ChangeAdminDetailsViewModel(User user)
        {
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            Fullname = user.Fullname;
        }

        public string Id { get; set; }


        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string Fullname { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class ChangeDriverDetailsViewModel
    {
        public ChangeDriverDetailsViewModel()
        {

        }

        public ChangeDriverDetailsViewModel(User user , PickMeUp.Entity.Driver driver, Vehicle vehicle)
        {
            Id = user.Id;
            DriverId = driver.Id;
            VehicleId = vehicle.Id;


            UserName = user.UserName;
            Email = user.Email;
            Fullname = user.Fullname;

            DrivingLicence = driver.DrivingLicence;



            ModelName = vehicle.ModelName;
            CompanyName = vehicle.CompanyName;
            Color = vehicle.Color;
            RegDate = vehicle.RegDate;
            RegNumber = vehicle.RegNumber;
        }

        public string Id { get; set; }
        public int DriverId { get; set; }



        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string Fullname { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        [Display(Name = "Driving Licence")]
        [Required]
        public string DrivingLicence { get; set; }


        
        public int VehicleId { get; set; }
        
        [Display(Name = "Vechicle Type")]
        public string VehicleType { get; set; }

        [Required]
        [Display(Name = "Vehicle Model Name")]
        public string ModelName { get; set; }


        [Required]
        [Display(Name ="Vehicle Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Vehicle Color")]
        public string Color { get; set; }

        [Required]
        [Display(Name = "Vehicle Registration Number")]
        public string RegNumber { get; set; }


        [Required]
        [Display(Name = "Vehicle Registration Date")]
        [DataType(DataType.Date)]
        public DateTime RegDate { get; set; }

    }

    public class ChangePassengerDetailsViewModel
    {
        public ChangePassengerDetailsViewModel()
        {

        }
        public ChangePassengerDetailsViewModel(User user)
        {
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            Fullname = user.Fullname;
            PhoneNumber = user.PhoneNumber;
        }

        public string Id { get; set; }
        
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string Fullname { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        
    }
}