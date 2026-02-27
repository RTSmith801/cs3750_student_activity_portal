using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentActivityPortal.Pages;

namespace StudentActivtyPortal.Pages;

public class PrivacyModel : PageModel
{

    private readonly ILogger<PrivacyModel> _logger;

    public PrivacyModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        _logger.LogInformation("Privacy page loaded.");
    }
}
