using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;

namespace AddImages.Models;

public class Gallery
{
    public int Id { get; set; }

    [Display(Name = "Nombre")]
    public string Name { get; set; }

    public byte[] Datos { get; set; }

    public string Extension { get; set; }

}