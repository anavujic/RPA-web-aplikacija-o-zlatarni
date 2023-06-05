using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppZlatarna.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Nakit> Nakit { get; set; }
        public DbSet<Kategorija> Kategorija { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Nakit>().Property(f => f.Cijena).HasPrecision(10, 2);

            builder.Entity<Kategorija>().HasData(
                new Kategorija() { Id = 1, Naziv = "Ogrlica" },
                new Kategorija() { Id = 2, Naziv = "Naušnice" },
                new Kategorija() { Id = 3, Naziv = "Narukvica" },
                new Kategorija() { Id = 4, Naziv = "Prsten" },
                new Kategorija() { Id = 5, Naziv = "Sat" });

            builder.Entity<Nakit>().HasData(
                new Nakit() { Id = 1, Naziv = "Rita", Cijena = 899.90m, DatumNabave = DateTime.Parse("2023-03-10"), SlikaUrl = "https://www.zlatarna-dodic.hr/_SHOP/files/products/5040010002442.jpg?preset=product-fullsize-l&id=8169053", KategorijaId = 1 },
                new Nakit() { Id = 2, Naziv = "GoldPassion", Cijena = 699.90m, DatumNabave = DateTime.Parse("2022-12-12"), SlikaUrl = "https://image.dnevnik.hr/media/images/1024xX/Jan2019/61631528.jpg", KategorijaId = 3 },
                new Nakit() { Id = 3, Naziv = "Ruby", Cijena = 799.99m, DatumNabave = DateTime.Parse("2022-12-18"), SlikaUrl = "https://zlatarna-ar.hr/wp-content/uploads/2020/06/133563-2.jpg", KategorijaId = 2 },
                new Nakit() { Id = 4, Naziv = "Aya", Cijena = 1150.20m, DatumNabave = DateTime.Parse("2023-02-04"), SlikaUrl = "https://www.zlatarna-jozef-gjoni.hr/wp-content/uploads/2015/05/MG_0031_900X900-px.jpg", KategorijaId = 4 },
                new Nakit() { Id = 5, Naziv = "Blink", Cijena = 800.50m, DatumNabave = DateTime.Parse("2023-04-10"), SlikaUrl = "https://watch-a-porter.com/upload/catalog/product/1606/thumb/la680wega-9er-1-casio_614c7103a650d_400x400r.webp", KategorijaId = 5 }
                );

        }
    }
}
