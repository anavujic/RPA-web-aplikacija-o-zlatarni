using Microsoft.EntityFrameworkCore;
using WebAppZlatarna.Models;

namespace WebAppZlatarna.Models
{
    public class RepozitorijUpita : IRepozitorijUpita
    {
        private readonly AppDbContext _appDbContext;
        public RepozitorijUpita(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(Nakit nakit)
        {
            _appDbContext.Add(nakit);
            _appDbContext.SaveChanges();
        }

        public void Create(Kategorija kategorija)
        {
            _appDbContext.Add(kategorija);
            _appDbContext.SaveChanges();
        }

        public void Delete(Nakit nakit)
        {
            _appDbContext.Nakit.Remove(nakit);
            _appDbContext.SaveChanges();
        }

        public void Delete(Kategorija kategorija)
        {
            _appDbContext.Kategorija.Remove(kategorija);
            _appDbContext.SaveChanges();
        }

        public Nakit DohvatiNakitSIdom(int id)
        {
            return _appDbContext.Nakit
                .Include(k => k.Kategorija)
                .FirstOrDefault(f => f.Id == id);
        }

        public Kategorija DohvatiKategorijuSIdom(int id)
        {
            return _appDbContext.Kategorija.Find(id);
        }

        public int KategorijaSljedeciId()
        {
            int zadnjiId = _appDbContext.Kategorija
               .Count();

            int sljedeciId = zadnjiId + 1;
            return sljedeciId;
        }

        public IEnumerable<Nakit> PopisNakit()
        {

            return _appDbContext.Nakit.Include(k => k.Kategorija);
        }

        public IEnumerable<Kategorija> PopisKategorija()
        {
            return _appDbContext.Kategorija;
        }

        public int SljedeciId()
        {
            int zadnjiId = _appDbContext.Nakit
                .Include(k => k.Kategorija)
                .Max(x => x.Id);

            int sljedeciId = zadnjiId + 1;
            return sljedeciId;
        }

        public void Update(Nakit nakit)
        {
            _appDbContext.Nakit.Update(nakit);
            _appDbContext.SaveChanges();
        }

        public void Update(Kategorija kategorija)
        {
            _appDbContext.Kategorija.Update(kategorija);
            _appDbContext.SaveChanges();
        }
    }
}

