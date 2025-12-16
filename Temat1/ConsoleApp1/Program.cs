using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear(); // Czyści ekran przed pokazaniem menu
            Console.WriteLine("=== MENU GŁÓWNE ===");
            Console.WriteLine("1. Zadanie 1: Prosty Kalkulator");
            Console.WriteLine("2. Zadanie 2: Konwerter Temperatur");
            Console.WriteLine("3. Zadanie 3: Średnia Ocen");
            Console.WriteLine("0. Wyjście");
            Console.WriteLine("===================");
            Console.Write("Wybierz opcję: ");

            string wybor = Console.ReadLine();

            switch (wybor)
            {
                case "1":
                    UruchomKalkulator();
                    break;
                case "2":
                    UruchomKonwerter();
                    break;
                case "3":
                    UruchomSrednia();
                    break;
                case "0":
                    Console.WriteLine("Do widzenia!");
                    return; 
                default:
                    Console.WriteLine("Nieznana opcja. Naciśnij dowolny klawisz...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    // ZADANIE 1: KALKULATOR
    static void UruchomKalkulator()
    {
        Console.Clear();
        Console.WriteLine("--- Zadanie 1: Prosty Kalkulator ---");

        try
        {
            Console.Write("Podaj pierwszą liczbę: ");
            double liczba1 = double.Parse(Console.ReadLine());

            Console.Write("Podaj drugą liczbę: ");
            double liczba2 = double.Parse(Console.ReadLine());

            Console.Write("Wybierz operację (+, -, *, /): ");
            string operacja = Console.ReadLine();

            double wynik = 0;
            bool powodzenie = true;

            if (operacja == "+") wynik = liczba1 + liczba2;
            else if (operacja == "-") wynik = liczba1 - liczba2;
            else if (operacja == "*") wynik = liczba1 * liczba2;
            else if (operacja == "/")
            {
                if (liczba2 == 0)
                {
                    Console.WriteLine("Błąd: Nie można dzielić przez zero!");
                    powodzenie = false;
                }
                else wynik = liczba1 / liczba2;
            }
            else
            {
                Console.WriteLine("Błąd: Nieznana operacja.");
                powodzenie = false;
            }

            if (powodzenie)
            {
                Console.WriteLine($"Wynik: {wynik}");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Błąd: Wprowadzono niepoprawną liczbę!");
        }

        CzekajNaKlawisz();
    }

    // ZADANIE 2: TEMPERATURY
    static void UruchomKonwerter()
    {
        Console.Clear();
        Console.WriteLine("--- Zadanie 2: Konwerter Temperatur ---");

        Console.Write("Wybierz kierunek (C - na Fahrenheity, F - na Celsjusze): ");
        string kierunek = Console.ReadLine().ToUpper();

        try
        {
            if (kierunek == "C")
            {
                Console.Write("Podaj stopnie Celsjusza: ");
                double c = double.Parse(Console.ReadLine());
                double f = c * 1.8 + 32;
                Console.WriteLine($"{c}°C = {f:F2}°F");
            }
            else if (kierunek == "F")
            {
                Console.Write("Podaj stopnie Fahrenheita: ");
                double f = double.Parse(Console.ReadLine());
                double c = (f - 32) / 1.8;
                Console.WriteLine($"{f}°F = {c:F2}°C");
            }
            else
            {
                Console.WriteLine("Niepoprawny wybór (wpisz C lub F).");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Błąd: Wprowadzono niepoprawną wartość temperatury!");
        }

        CzekajNaKlawisz();
    }

    // ZADANIE 3: ŚREDNIA OCEN
    static void UruchomSrednia()
    {
        Console.Clear();
        Console.WriteLine("--- Zadanie 3: Średnia Ocen ---");

        try
        {
            Console.Write("Ile ocen chcesz wprowadzić? ");
            int ile = int.Parse(Console.ReadLine());

            if (ile <= 0)
            {
                Console.WriteLine("Musisz wprowadzić co najmniej jedną ocenę.");
            }
            else
            {
                double suma = 0;
                for (int i = 0; i < ile; i++)
                {
                    Console.Write($"Podaj ocenę nr {i + 1}: ");
                    suma += double.Parse(Console.ReadLine());
                }

                double srednia = suma / ile;
                Console.WriteLine($"Średnia: {srednia:F2}");

                if (srednia >= 3.0) Console.WriteLine("Uczeń zdał.");
                else Console.WriteLine("Uczeń nie zdał.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Błąd: Wprowadzono niepoprawne dane (ocena musi być liczbą)!");
        }

        CzekajNaKlawisz();
    }

    static void CzekajNaKlawisz()
    {
        Console.WriteLine("\nNaciśnij dowolny klawisz, aby wrócić do menu...");
        Console.ReadKey();
    }
}