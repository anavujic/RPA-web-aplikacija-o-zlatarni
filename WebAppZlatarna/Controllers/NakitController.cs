using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppZlatarna.Models;

namespace WebAppZlatarna.Controllers
{
    public class NakitController : Controller
    {
        private readonly IRepozitorijUpita _repozitorijUpita;
        public NakitController(IRepozitorijUpita repozitorijUpita)
        {
            _repozitorijUpita = repozitorijUpita;
        }

        public IActionResult Index()
        {
            return View(_repozitorijUpita.PopisNakit());
        }

        public IActionResult Create()
        {
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv");
            int sljedeciId = _repozitorijUpita.SljedeciId();
            Nakit nakit = new Nakit() { Id = sljedeciId };
            return View(nakit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Naziv,DatumNabave,Cijena,SlikaUrl,KategorijaId")] Nakit nakit)
        {
            ModelState.Remove("Kategorija");//uklanjanje veze

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Create(nakit);
                return RedirectToAction("Index"); // ako je sve ok, tu završava metoda 
            }
            //ako je doslo do greške sljedeci dio se izvrsava
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv", nakit.KategorijaId);
            return View(nakit);

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            Nakit nakit = _repozitorijUpita.DohvatiNakitSIdom(id);

            if (nakit == null) { return NotFound(); }

            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv", nakit.KategorijaId);
            return View(nakit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind("Id,Naziv,DatumIzlaska,Cijena,SlikaUrl,KategorijaId")] Nakit nakit)
        {
            if (id != nakit.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Kategorija");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Update(nakit);
                return RedirectToAction("Index");
            }
            //ako je doslo do greške sljedeci dio se izvrsava
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv", nakit.KategorijaId);
            return View(nakit);

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            var nakit = _repozitorijUpita.DohvatiNakitSIdom(Convert.ToInt16(id));

            if (nakit == null)
            {
                return NotFound();
            }

            return View(nakit);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var nakit = _repozitorijUpita.DohvatiNakitSIdom(id);
            _repozitorijUpita.Delete(nakit);
            return RedirectToAction("Index");

        }

        //Trazilica
        public ActionResult SearchIndex(string nakitKategorija, string searchString)
        {
            var zanr = new List<string>();

            var kategorijaUpit = _repozitorijUpita.PopisKategorija();

            ViewData["nakitKategorija"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Naziv", "Naziv", kategorijaUpit);

            var nakiti = _repozitorijUpita.PopisNakit();

            if (!String.IsNullOrWhiteSpace(searchString))
            {
                nakiti = nakiti.Where(s => s.Naziv.Contains(searchString, StringComparison.OrdinalIgnoreCase)); // StringComparison.OrdinalIgnoreCase ignorira velika-mala slova 
            }

            if (string.IsNullOrWhiteSpace(nakitKategorija))
                return View(nakiti);
            else
            {
                return View(nakiti.Where(x => x.Kategorija.Naziv == nakitKategorija));
            }

        }


    }
}
