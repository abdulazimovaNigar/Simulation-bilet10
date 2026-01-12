using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contexts;

namespace WebApplication1.Areas.Admin.Controllers;

[Area ("Admin")]
public class SliderController(AppDbContext _context) : Controller
{


    
    public IActionResult Index()
    {
        var sliders = _context.Sliders.ToList();
        return View(sliders);
    }

    /*public IActionResult Read() 
    { 
        
    }*/
}
