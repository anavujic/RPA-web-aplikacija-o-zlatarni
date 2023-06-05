using WebAppZlatarna.Models;

namespace WebAppZlatarna.Models
{
    public interface IRepozitorijUpita
    {
        // za listu se može koristiti i List<>,IList<>, ali u praksi se 
        //IEnumerable<> pokazao najbržim 
        IEnumerable<Nakit> PopisNakit(); // R - read
        void Create(Nakit nakit); // C - insert tj create
        void Delete(Nakit nakit); // D - delete
        void Update(Nakit nakit); //U - update
        int SljedeciId();
        int KategorijaSljedeciId();
        Nakit DohvatiNakitSIdom(int id);

        IEnumerable<Kategorija> PopisKategorija();
        void Create(Kategorija kategorija);
        void Delete(Kategorija kategorija);
        void Update(Kategorija kategorija);

        Kategorija DohvatiKategorijuSIdom(int id);


    }
}

