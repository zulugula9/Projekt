using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static List<Film> filmy = new List<Film>();
        static List<Klient> klienci = new List<Klient>();
        static List<Rezerwacja> rezerwacje = new List<Rezerwacja>();

        static string filmFilePath = "filmy.txt";
        static string klientFilePath = "klienci.txt";
        static string rezerwacjaFilePath = "rezerwacje.txt";

        static void Main(string[] args)
        {
            WczytajDane();

            while (true)
            {
                Console.WriteLine("\nSystem zarządzania wypożyczalnią filmów");
                Console.WriteLine("1. Dodaj film");
                Console.WriteLine("2. Wyświetl filmy");
                Console.WriteLine("3. Dodaj klienta");
                Console.WriteLine("4. Wyświetl klientów");
                Console.WriteLine("5. Dodaj rezerwację");
                Console.WriteLine("6. Wyświetl rezerwacje");
                Console.WriteLine("7. Zapisz dane");
                Console.WriteLine("8. Wyjdź");
                Console.Write("Wybierz opcję: ");

                string opcja = Console.ReadLine();

                switch (opcja)
                {
                    case "1":
                        DodajFilm();
                        break;
                    case "2":
                        WyswietlFilmy();
                        break;
                    case "3":
                        DodajKlienta();
                        break;
                    case "4":
                        WyswietlKlientow();
                        break;
                    case "5":
                        DodajRezerwacje();
                        break;
                    case "6":
                        WyswietlRezerwacje();
                        break;
                    case "7":
                        ZapiszDane();
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                        break;
                }
            }
        }

        static void WczytajDane()
        {
            if (File.Exists(filmFilePath))
            {
                foreach (var line in File.ReadAllLines(filmFilePath))
                {
                    var data = line.Split(';');
                    filmy.Add(new Film
                    {
                        Id = int.Parse(data[0]),
                        Tytul = data[1],
                        Gatunek = data[2],
                        RokProdukcji = int.Parse(data[3]),
                        Dostepnosc = bool.Parse(data[4])
                    });
                }
            }

            if (File.Exists(klientFilePath))
            {
                foreach (var line in File.ReadAllLines(klientFilePath))
                {
                    var data = line.Split(';');
                    klienci.Add(new Klient
                    {
                        Id = int.Parse(data[0]),
                        Imie = data[1],
                        Nazwisko = data[2],
                        Email = data[3]
                    });
                }
            }

            if (File.Exists(rezerwacjaFilePath))
            {
                foreach (var line in File.ReadAllLines(rezerwacjaFilePath))
                {
                    var data = line.Split(';');
                    rezerwacje.Add(new Rezerwacja
                    {
                        Id = int.Parse(data[0]),
                        FilmId = int.Parse(data[1]),
                        KlientId = int.Parse(data[2]),
                        DataWypozyczenia = DateTime.Parse(data[3])
                    });
                }
            }

            Console.WriteLine("Dane wczytano pomyślnie.");
        }

        static void ZapiszDane()
        {
            using (var writer = new StreamWriter(filmFilePath))
            {
                foreach (var film in filmy)
                {
                    writer.WriteLine($"{film.Id};{film.Tytul};{film.Gatunek};{film.RokProdukcji};{film.Dostepnosc}");
                }
            }

            using (var writer = new StreamWriter(klientFilePath))
            {
                foreach (var klient in klienci)
                {
                    writer.WriteLine($"{klient.Id};{klient.Imie};{klient.Nazwisko};{klient.Email}");
                }
            }

            using (var writer = new StreamWriter(rezerwacjaFilePath))
            {
                foreach (var rezerwacja in rezerwacje)
                {
                    writer.WriteLine($"{rezerwacja.Id};{rezerwacja.FilmId};{rezerwacja.KlientId};{rezerwacja.DataWypozyczenia:yyyy-MM-dd}");
                }
            }

            Console.WriteLine("Dane zapisano pomyślnie.");
        }

        static void DodajFilm()
        {
            Console.Write("Podaj ID filmu: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Podaj tytuł filmu: ");
            string tytul = Console.ReadLine();
            Console.Write("Podaj gatunek filmu: ");
            string gatunek = Console.ReadLine();
            Console.Write("Podaj rok produkcji filmu: ");
            int rokProdukcji = int.Parse(Console.ReadLine());
            Console.Write("Czy film jest dostępny? (true/false): ");
            bool dostepnosc = bool.Parse(Console.ReadLine());

            filmy.Add(new Film { Id = id, Tytul = tytul, Gatunek = gatunek, RokProdukcji = rokProdukcji, Dostepnosc = dostepnosc });
            Console.WriteLine("Film został dodany.");
        }

        static void WyswietlFilmy()
        {
            Console.WriteLine("\nLista filmów:");
            foreach (var film in filmy)
            {
                Console.WriteLine($"ID: {film.Id}, Tytuł: {film.Tytul}, Gatunek: {film.Gatunek}, Rok: {film.RokProdukcji}, Dostępność: {film.Dostepnosc}");
            }
        }

        static void DodajKlienta()
        {
            Console.Write("Podaj ID klienta: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Podaj imię klienta: ");
            string imie = Console.ReadLine();
            Console.Write("Podaj nazwisko klienta: ");
            string nazwisko = Console.ReadLine();
            Console.Write("Podaj email klienta: ");
            string email = Console.ReadLine();

            klienci.Add(new Klient { Id = id, Imie = imie, Nazwisko = nazwisko, Email = email });
            Console.WriteLine("Klient został dodany.");
        }

        static void WyswietlKlientow()
        {
            Console.WriteLine("\nLista klientów:");
            foreach (var klient in klienci)
            {
                Console.WriteLine($"ID: {klient.Id}, Imię: {klient.Imie}, Nazwisko: {klient.Nazwisko}, Email: {klient.Email}");
            }
        }

        static void DodajRezerwacje()
        {
            Console.Write("Podaj ID rezerwacji: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Podaj ID filmu: ");
            int filmId = int.Parse(Console.ReadLine());
            Console.Write("Podaj ID klienta: ");
            int klientId = int.Parse(Console.ReadLine());
            Console.Write("Podaj datę wypożyczenia (yyyy-MM-dd): ");
            DateTime dataWypozyczenia = DateTime.Parse(Console.ReadLine());

            rezerwacje.Add(new Rezerwacja { Id = id, FilmId = filmId, KlientId = klientId, DataWypozyczenia = dataWypozyczenia });
            Console.WriteLine("Rezerwacja została dodana.");
        }

        static void WyswietlRezerwacje()
        {
            Console.WriteLine("\nLista rezerwacji:");
            foreach (var rezerwacja in rezerwacje)
            {
                Console.WriteLine($"ID: {rezerwacja.Id}, Film ID: {rezerwacja.FilmId}, Klient ID: {rezerwacja.KlientId}, Data wypożyczenia: {rezerwacja.DataWypozyczenia}");
            }
        }
    }


}
