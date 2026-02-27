using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudentActivityPortal.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public string? Name { get; set; }

    public string? Message { get; set; }

    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        _logger.LogInformation("Home page loaded.");
    }

    public void OnPost()
    {
        Message = $"Hello {Name}! Thank you for exploring student activities.";
        _logger.LogInformation("Form submitted by {Name}", Name);
    }
}