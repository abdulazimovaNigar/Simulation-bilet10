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

    [HttpGet]
    public IActionResult Create() 
    { 
        return View();
    }
    [HttpPost]
    public IActionResult Create(Slider slider)
    {
        if (!ModelState.IsValid) return View(slider);

        _context.Sliders.Add(slider);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Update(int id) 
    {
        var slider = _context.Sliders.FirstOrDefault(s => s.Id == id);
        if (slider == null) return NotFound();
        return View(slider);
    }

    [HttpPost]
    public IActionResult Update(Slider slider) 
    { 
        if (!ModelState.IsValid) return View(slider);
        var existSlider = _context.Sliders.FirstOrDefault(s => s.Id == slider.Id);

        if (existSlider == null) return NotFound();
        existSlider.Title = slider.Title;
        existSlider.Description = slider.Description;
        existSlider.ImageURL = slider.ImageURL;


        _context.Sliders.Update(existSlider);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Delete(int id) 
    { 
        var slider = _context.Sliders.FirstOrDefault(s => s.Id == id);
        if (slider == null) return NotFound();

        _context.Sliders.Remove(slider);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
