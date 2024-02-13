using AddImages.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AddImages.Data;

public class GalleryContext : DbContext
{
    public GalleryContext(DbContextOptions<GalleryContext> options) : base(options)
    {

    }

    public DbSet<Gallery> Gallery { get; set; }
}