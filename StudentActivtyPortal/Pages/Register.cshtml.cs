using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace StudentActivityPortal.Pages;

public class RegisterModel : PageModel
{
    [BindProperty]
    public RegistrationInput Input { get; set; } = new();

    public string? SuccessMessage { get; set; }

    private readonly ILogger<RegisterModel> _logger;

    public RegisterModel(ILogger<RegisterModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        _logger.LogInformation("Registration page loaded.");
    }

    public void OnPost()
    {
        if (!ModelState.IsValid)
        {
            return;
        }

        SuccessMessage = $"Thank you {Input.FullName}! You are registered for {Input.ActivityName}.";
        ModelState.Clear();
    }
}

public class RegistrationInput
{
    [Required(ErrorMessage = "Full name is required.")]
    public string? FullName { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string? Email { get; set; }

    [Required]
    public string? ActivityName { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime? ActivityDate { get; set; }
}