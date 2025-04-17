using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class MemberSignUpForm
{
    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "First Name", Prompt = "Enter first name")]
    public string FirstName { get; set; } = null!;

    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Last Name", Prompt = "Enter last name")]
    public string LastName { get; set; } = null!;

    [Required]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Enter email address")]
    public string Email { get; set; } = null!;

    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Phone", Prompt = "Enter phone number")]
    public string? Phone { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[A-Z]).{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least one uppercase letter.")]
    [Display(Name = "Password", Prompt = "Enter password")]
    public string Password { get; set; } = null!;

    [Compare(nameof(Password), ErrorMessage = "Passwords don`t match!")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password", Prompt = "Confirm password")]
    public string ConfirmPassword { get; set; } = null!;

    //[Display(Name = "Terms And Conditions", Prompt = "I accept the terms and conditons.")]
    //[Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms and conditions to use this site.")]
    //public bool TermsAndConditions { get; set; }
}
