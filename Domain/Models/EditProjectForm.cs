using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class EditProjectForm
{
    public int Id { get; set; }

    [Display(Name = "Project Image", Prompt = "Select a image")]
    [DataType(DataType.Upload)]
    public IFormFile? ProjectImage { get; set; }

    [Display(Name = "Project Name", Prompt = "Enter project name")]
    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Required")]
    public string ProjectName { get; set; } = null!;

    [Display(Name = "Client", Prompt = "Enter client name")]
    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Required")]
    public string ClientName { get; set; } = null!;

    [Display(Name = "Description", Prompt = "Enter description")]
    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Required")]
    public string Description { get; set; } = null!;

    [Display(Name = "Start Date", Prompt = "Enter start date")]
    [DataType(DataType.DateTime)]
    [Required(ErrorMessage = "Required")]
    public string StartDate { get; set; } = null!;

    [Display(Name = "End Date", Prompt = "Enter end date")]
    [DataType(DataType.DateTime)]
    [Required(ErrorMessage = "Required")]
    public string EndDate { get; set; } = null!;

    [Display(Name = "Budget", Prompt = "Enter budget")]
    [DataType(DataType.Currency)]
    [Required(ErrorMessage = "Required")]
    public string Budget { get; set; } = null!;
}
