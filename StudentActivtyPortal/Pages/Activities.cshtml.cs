using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentActivityPortal.Pages;

namespace StudentActivityPortal.Pages;

public class ActivitiesModel : PageModel
{


    private readonly ILogger<ActivitiesModel> _logger;

    public ActivitiesModel(ILogger<ActivitiesModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        _logger.LogInformation("Activities page loaded.");
    }
}
