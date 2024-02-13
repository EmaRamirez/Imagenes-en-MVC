using System.ComponentModel.DataAnnotations;

namespace AddImages.ViewModels;

public class GalleryIndexViewModel
{
    [Display(Name = "Nro")]
    public int Id { get; set; }
    [Display(Name = "Nombre")]
    public string Name { get; set; }
    [Display(Name = "Foto")]
    public string Url { get; set; }
}