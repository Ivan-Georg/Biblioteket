using System;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

using System;
using System.Collections.Generic;

// En klass som representerar en bok med egenskaper för titel, författare, ISBN och utlåningsstatus.
class Bok
{
    public string Titel { get; set; }
    public string Författare { get; set; }
    public string ISBN { get; set; }
    public bool Utlånad { get; set; }
}

// En klass som representerar ett bibliotek och hanterar böcker.
class Bibliotek
{
    // En privat lista som innehåller böcker i biblioteket.
    private List<Bok> böcker = new List<Bok>();

    // En metod för att centrera text i konsolfönstret.
    static void CenterText(string text)
    {
        int width = Console.WindowWidth;
        int leftPadding = (width - 30) / 2; // Centrerar text baserat på fönstrets bredd
        Console.SetCursorPosition(leftPadding, Console.CursorTop);
        Console.WriteLine(text);
    }

    // En metod för att centrera input i konsolfönstret.
    static void CenterInput()
    {
        int width = Console.WindowWidth;
        int leftPadding = (width - 30) / 2; // Centrerar input-rutan baserat på antalet tecken
        Console.SetCursorPosition(leftPadding, Console.CursorTop);
    }

    // En metod för att lägga till en bok.
    public void LäggTillBok(Bok bok)
    {
        böcker.Add(bok);
        Console.Clear();
        CenterText("Boken har lagts till i biblioteket.\n");
        CenterText("Tryck Enter för att återgå till huvudmenyn.");
        CenterInput();
        Console.ReadLine();
    }

    // En metod för att ta bort en bok från biblioteket baserat på titeln.
    public void TaBortBok(string titel)
    {
        Console.Clear();

        // Letar efter boken med den angivna titeln.
        Bok bokAttTaBort = böcker.Find(b => b.Titel == titel);

        if (bokAttTaBort != null)
        {
            böcker.Remove(bokAttTaBort);
            CenterText(titel + " har tagits bort från biblioteket.\n");
            CenterText("Tryck Enter för att återgå till huvudmenyn.");
        }
        else
        {
            CenterText("Boken med den angivna titeln kunde inte hittas. Tryck Enter för att återgå till huvudmenyn.");
        }

        Console.ReadLine();
    }

    // En metod för att visa alla böcker i biblioteket.
    public void VisaAllaBöcker()
    {
        Console.Clear();
        if (böcker.Count > 0)
        {
            CenterText("Bibliotekets böcker:\n");

            // Loopar varje bok och visar dess information med centrering.
            foreach (Bok bok in böcker)
            {
                CenterText($"Titel: {bok.Titel}");
                CenterText($"Författare: {bok.Författare}");
                CenterText($"ISBN: {bok.ISBN}");
                CenterText($"Utlånad: {(bok.Utlånad ? "Ja" : "Nej")}\n");
            }
        }
        else
        {
            CenterText("Det finns inga böcker i biblioteket. Tryck Enter för att återgå till huvudmenyn.");
        }

        Console.ReadLine();
    }
}

// Huvudprogrammet där programmet körs.
class Program
{
    static void Main()
    {
        // Skapar en instans av Bibliotek-klassen.
        Bibliotek bibliotek = new Bibliotek();

        // En loop för att hålla programmet igång.
        while (true)
        {
            Console.Clear();

            // Visar huvudmenyn med centrering.
            CenterText("Välj en åtgärd:");
            CenterText("1. Lägg till en bok");
            CenterText("2. Ta bort en bok");
            CenterText("3. Visa alla böcker");
            CenterText("4. Avsluta");
            CenterInput();

            // Läser användarens val från konsolen.
            string val = Console.ReadLine();

            // En switch-sats för att hantera användarens menyval.
            switch (val)
            {
                case "1":
                    Console.Clear();
                    LäggTillBok(bibliotek);
                    break;
                case "2":
                    TaBortBok(bibliotek);
                    break;
                case "3":
                    bibliotek.VisaAllaBöcker();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    CenterText("Ogiltigt val. Försök igen. Tryck Enter för att återgå till huvudmenyn.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void CenterText(string text)
    {
        int width = Console.WindowWidth;
        int leftPadding = (width - 30) / 2;
        Console.SetCursorPosition(leftPadding, Console.CursorTop);
        Console.WriteLine(text);
    }

    static void CenterInput()
    {
        int width = Console.WindowWidth;
        int leftPadding = (width - 30) / 2;
        Console.SetCursorPosition(leftPadding, Console.CursorTop);
    }

    // Metod för att lägga till en bok i biblioteket.
    static void LäggTillBok(Bibliotek bibliotek)
    {
        Bok nyBok = new Bok();

        CenterText("Ange titel:");
        CenterInput();
        nyBok.Titel = Console.ReadLine();

        CenterText("Ange författare:");
        CenterInput();
        nyBok.Författare = Console.ReadLine();

        CenterText("Ange ISBN-nummer:");
        CenterInput();
        nyBok.ISBN = Console.ReadLine();

        CenterText("Är boken utlånad? (ja/nej):");
        CenterInput();
        string input = Console.ReadLine().ToLower();

        // En loop som hanterar if-stasen för utlåningsstatus.
        while (true)
        {
            if (input == "ja" || input == "j")
            {
                nyBok.Utlånad = true;
                break;
            }
            else if (input == "nej" || input == "ne" || input == "n")
            {
                nyBok.Utlånad = false;
                break;
            }
            else
            {
                Console.Clear();
                CenterText("Ogiltig inmatning. Vänligen ange 'ja' eller 'nej'.");
                CenterText("Är boken utlånad? (ja/nej):");
                CenterInput();
                input = Console.ReadLine().ToLower();
            }
        }
        // Lägger till den nya boken i biblioteket.
        bibliotek.LäggTillBok(nyBok);
    }

    // metod för att ta bort bok från biblioteket.
    static void TaBortBok(Bibliotek bibliotek)
    {
        Console.Clear();
        CenterText("Ange bokens titel för att ta bort boken:");
        CenterInput();
        string titel = Console.ReadLine();

        // Anropar metoden i Bibliotek-klassen för att ta bort boken.
        bibliotek.TaBortBok(titel);
    }
}

