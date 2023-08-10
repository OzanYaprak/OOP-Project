using Microsoft.AspNetCore.Mvc;
using OOP.Ornekler;

namespace OOP.Controllers
{
    public class DefaultController : Controller
    {
        //void İslemler()
        //{
        //    Class1 class1 = new Class1();

        //    class1.Topla();
        //}

        private void messages()
        {
            ViewBag.mes1 = "OzanErhanYAPRAK";
            ViewBag.mes2 = "oop projesi";
            ViewBag.mes3 = "Merhabalar";
        }

        public int Topla()
        {
            int sayi1 = 10;
            int sayi2 = 20;
            int sonuc = sayi1 + sayi2;

            return sonuc;
        }

        public int cevreHesaplama()
        {
            int kısa = 10;
            int uzun = 20;
            int sonuc2 = 2 * (kısa + uzun);
            return sonuc2;
        }

        public int faktoriyelHesaplama()
        {
            int s1 = 1;
            int s2 = 2;
            int s3 = 3;
            int s4 = 4;
            int n = s1 * s2 * s3 * s4;
            return n;
        }

        private string cumle()
        {
            string c = "Küçük Hanımlar Küçük Beyler Sizler Hepiniz Geleceğin vsvsv.";

            return c;
        }

        private void MesajListesi(string p)
        {
            ViewBag.v = p;
        }

        private void Username(string username)
        {
            ViewBag.user = username;
        }

        public int Toplama(int sayi1, int sayi2)
        {
            int sonuc = sayi1 + sayi2;
            return sonuc;
        }

        public int Faktoriyel(int p)
        {
            int sayı = 1;

            for (int i = 1; i <= p; i++)
            {
                sayı = sayı * i;
            }

            return sayı;
        }

        public IActionResult Index()
        {
            MesajListesi("Parametre ismi");
            Username("OzanYaprak");
            messages();
            ViewBag.sonuc = Topla();
            ViewBag.sonuc2 = cevreHesaplama();
            ViewBag.sonuc3 = faktoriyelHesaplama();

            ViewBag.toplamsonuc = Toplama(20, 30);

            return View();
        }

        public IActionResult Urunler()
        {
            Username("ErhanYaprak");

            ViewBag.faktor = Faktoriyel(6);

            messages();

            return View();
        }

        public IActionResult Musteriler()
        {
            ViewBag.sonuc4 = cumle();
            return View();
        }

        public IActionResult Deneme()
        {
            Sehirler sehirler = new Sehirler();

            sehirler.Ad = "Istanbul";
            sehirler.ID = 1;
            sehirler.Nufus = 1000;
            sehirler.Ulke = "Türkiye";

            ViewBag.Input1 = sehirler.Ad;
            ViewBag.Input2 = sehirler.ID;
            ViewBag.Input3 = sehirler.Nufus;
            ViewBag.Input4 = sehirler.Ulke;

            return View();
        }
    }
}