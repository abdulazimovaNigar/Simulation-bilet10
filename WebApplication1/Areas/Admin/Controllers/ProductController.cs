using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contexts;

namespace WebApplication1.Areas.Admin.Controllers;

[Area ("Admin")]
public class ProductController(AppDbContext _context) : Controller
{

    public IActionResult Index()
    {
        var products = _context.Products.ToList();
        return View(products);
    }


    [HttpGet]
    public IActionResult Create() 
    { 
        return View();
    }
    [HttpPost]
    public IActionResult Create(Product product) 
    {
        if (!ModelState.IsValid) return View(product);
        _context.Products.Add(product);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Update(int id) 
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();
        return View(product);
    }

    [HttpPost]
    public IActionResult Update(Product product) 
    {
        if (!ModelState.IsValid) return View(product);
        var existProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
        if (existProduct == null) return NotFound();
        existProduct.Title = product.Title;
        existProduct.Description = product.Description;
        existProduct.Image = product.Image;
        existProduct.Price = product.Price;
        existProduct.ReviewAmount = product.ReviewAmount;

        _context.Products.Update(existProduct);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();

        _context.Products.Remove(product);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

}
