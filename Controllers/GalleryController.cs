
using System.Reflection;
using AddImages.Data;
using AddImages.Models;
using AddImages.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;


namespace AddImages.Controllers;


public class GalleryController : Controller
{

    private readonly GalleryContext _context;
    public GalleryController(GalleryContext context)
    {
        this._context = context;
    }

    public IActionResult Index()
    {
        var listado = _context.Gallery.ToList();

        var imagenes = new List<GalleryIndexViewModel>();

        foreach (var item in listado)
        {


            imagenes.Add(
                new GalleryIndexViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Url = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(item.Datos))
                }
            );
        }

        return View(imagenes);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create([FromForm] IFormFile image)
    {
        var nombre = Path.GetFileNameWithoutExtension(image.FileName);

        var extension = Path.GetExtension(image.FileName);

        MemoryStream ms = new MemoryStream();

        image.CopyToAsync(ms);

        byte[] datos = ms.ToArray();


        var imagen1 = new Gallery
        {
            Name = nombre,
            Datos = datos,
            Extension = extension

        };

        _context.Gallery.Add(imagen1);
        _context.SaveChanges();

        return RedirectToAction("Index");

    }


}