using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Lesson_02_Variables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region DoubleDeğişkenler
            //double number = 4.85;
            //Console.WriteLine(number);

            //Console.WriteLine("***** Fiyat Listesi *****");
            //Console.WriteLine();

            //double applePrice, orangePrice, strawberryPrice, potatoPrice, tomatoPrice;
            //applePrice = 14.85;
            //orangePrice = 20.95;
            //strawberryPrice = 45;
            //potatoPrice = 9.74;
            //tomatoPrice = 6.88;
            //Console.WriteLine("----Elma Kg Fiyatı : " + applePrice + " TL");
            //Console.WriteLine("----Portakal Kg Fiyatı : " + orangePrice + " TL");
            //Console.WriteLine("----Çilek Kg Fiyatı : " + strawberryPrice + " TL");
            //Console.WriteLine("----Patates Kg Fiyatı : " + potatoPrice + " TL");
            //Console.WriteLine("----Domates Kg Fiyatı : " + tomatoPrice + " TL");
            //Console.WriteLine();
            //double appleGram, orangeGram, strawberryGram, potatoGram, tomatoGram;
            //appleGram = 1.245;
            //orangeGram = 2.650;
            //strawberryGram = 0.750;
            //potatoGram = 4.859;
            //tomatoGram = 3.745;

            //double appleTotalPrice, orangeTotalPrice, strawberryTotalPrice, potatoTotalPrice, tomatoTotalPrice;
            //appleTotalPrice = applePrice * appleGram;
            //orangeTotalPrice = orangePrice * orangeGram;
            //strawberryTotalPrice = strawberryPrice * strawberryGram;
            //potatoTotalPrice = potatoPrice * potatoGram;
            //tomatoTotalPrice = tomatoPrice * tomatoGram;

            //Console.WriteLine("Alınan Ürün : Elma - " + "Kg Fiyatı : " + applePrice + " - Gramaj : " + appleGram + " - Toplam : " + appleTotalPrice);
            //Console.WriteLine("Alınan Ürün : Portakal - " + "Kg Fiyatı : " + orangePrice + " - Gramaj : " + orangeGram + " - Toplam : " + orangeTotalPrice);
            //Console.WriteLine("Alınan Ürün : Çilek - " + "Kg Fiyatı : " + strawberryPrice + " - Gramaj : " + strawberryGram + " - Toplam : " + strawberryTotalPrice);
            //Console.WriteLine("Alınan Ürün : Patates - " + "Kg Fiyatı : " + potatoPrice + " - Gramaj : " + potatoGram + " - Toplam : " + potatoTotalPrice);
            //Console.WriteLine("Alınan Ürün : Domates - " + "Kg Fiyatı : " + tomatoPrice + " - Gramaj : " + tomatoGram + " - Toplam : " + tomatoTotalPrice);
            //Console.WriteLine();

            //double shoppingTotalPrice = appleTotalPrice + orangeTotalPrice + strawberryTotalPrice + potatoTotalPrice + tomatoTotalPrice;

            //Console.WriteLine("-> ÖDenecek Tutar :  " + shoppingTotalPrice + " TL");
            #endregion
            #region CharDeğişkenler
            //ABCDEFGH
            //DEF...
            //Toplantı saat 20:00'de

            //char symbol = 'a';
            //Console.WriteLine(symbol);
            #endregion
            #region VeriGirişleri

            //Console.WriteLine("**** C# Havayolları Yolcu Bilgisi ****");
            //Console.WriteLine();

            //string name, surname, district, city, age, identityNumber;
            //Console.Write("Yolcu Adı : ");
            //name = Console.ReadLine();
            //Console.Write("Yolcu Soyadı : ");
            //surname = Console.ReadLine();
            //Console.Write("İl : ");
            //city = Console.ReadLine();
            //Console.Write("İlçe : ");
            //district = Console.ReadLine();
            //Console.Write("Yaş : ");
            //age = Console.ReadLine();
            //Console.Write("Tc No : ");
            //identityNumber = Console.ReadLine();

            //Console.WriteLine("----------------------------");

            //Console.WriteLine("Tc : " + identityNumber + " - " + "Yolcu : " + name + " " + surname + " " + district + "/" + city + " " + age);
            #endregion
            #region Dönüşümler

            //int shoesPrice, computerPrice, chairPrice, tvPrice;
            //shoesPrice = 1000;
            //computerPrice = 20000;
            //chairPrice = 5000;
            //tvPrice = 12000;
            //int shoesCount, computerCount, chairCount, tvCount;
            //Console.Write("Aldığınız ayakkabı sayısını giriniz: ");
            //shoesCount = int.Parse(Console.ReadLine());
            //Console.Write("Aldığınız bilgisayar sayısını giriniz: ");
            //computerCount = int.Parse(Console.ReadLine());
            //Console.Write("Aldığınız sandalye sayısını giriniz: ");
            //chairCount = int.Parse(Console.ReadLine());
            //Console.Write("Aldığınız televizyon sayısını giriniz: ");
            //tvCount = int.Parse(Console.ReadLine());

            //int totalPrice = shoesCount * shoesPrice + computerCount * computerPrice + chairCount * chairPrice + tvCount * tvPrice;
            //Console.WriteLine();
            //Console.WriteLine("Toplam Ödenecek Tutar : " + totalPrice);
            #endregion
            #region OndalıklıSayıİşlemleri
            //double exam1, exam2, exam3, result;

            //Console.Write("1. Sınav Notu : ");
            //exam1 = double.Parse(Console.ReadLine());
            //Console.Write("2. Sınav Notu : ");
            //exam2 = double.Parse(Console.ReadLine());
            //Console.Write("3. Sınav Notu : ");
            //exam3 = double.Parse(Console.ReadLine());

            //result = (exam1 + exam2 + exam3) / 3;
            //Console.WriteLine();
            //Console.WriteLine("Ortalamanız : " + result);
            #endregion
            #region KarakterGirişi
            Console.Write("Cinsiyet Seçiniz : ");
            char gender = char.Parse(Console.ReadLine());
            Console.WriteLine("Cinsiyet : " + gender);
            #endregion

            Console.Read();
        }
    }
}
