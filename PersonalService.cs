using LAB3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3
{
    internal class PersonalService
    {
        private readonly LAB2Context context;

        public PersonalService()
        {
            context = new LAB2Context();
        }
        public void Personelmenu()
        {
            Console.Clear();
            Console.WriteLine("══════════════════════════════════════════════════════════════");
            Console.WriteLine("Vänligen gör ett val i menyn nedan");
            Console.WriteLine("(1) Skriv ut en lista på all personal.");
            Console.WriteLine("(2) Hämta Lärare");
            Console.WriteLine("(3) Hämta Rektor");
            Console.WriteLine("(4) Hämta Vaktmästare");
            Console.WriteLine("(5) Hämta Väktare");
            Console.WriteLine("(6) Hämta all personal och hur länge det har varit anställda");
            Console.WriteLine("(7) Gå tillbaka till tidigare meny");
            Console.WriteLine("══════════════════════════════════════════════════════════════");
            int.TryParse(Console.ReadLine(), out int input1);
            switch (input1)
            {
                case 1:
                    PersonelList();
                    break;
                case 2:
                    GetTeachers();
                    break;
                case 3:
                    GetPrincipal();
                    break;
                case 4:
                    GetJanitor();
                    break;
                case 5:
                    GetGuards();
                    break;
                case 6:
                    GetTimeWorking();
                    break;
                default:
                    break;

            }
        }
        public void PersonelList()
        {
            Console.Clear();
            var Personals = context.Personals.ToList();
            foreach (var personals in Personals)
            {
                Console.WriteLine($"Namn: {personals.Fnamn} {personals.Lnamn}\nTitle: {personals.Position}");
                Console.WriteLine("══════════════════════════════════════════════════════════════");
            }
        }

        public void GetTeachers()
        {
            Console.Clear();
            var teachers = context.Personals.Where(p => p.Position == "Lärare").ToList();
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"Namn: {teacher.Fnamn} {teacher.Lnamn}\nTitle: {teacher.Position}");
                Console.WriteLine("══════════════════════════════════════════════════════════════");
            }
        }

        public void GetPrincipal()
        {
            Console.Clear();
            var rektors = context.Personals.Where(p => p.Position == "Rektor").ToList();
            foreach (var rektor in rektors)
            {
                Console.WriteLine($"Namn: {rektor.Fnamn} {rektor.Lnamn}\nTitle: {rektor.Position}");
                Console.WriteLine("══════════════════════════════════════════════════════════════");
            }
        }

        public void GetJanitor()
        {
            Console.Clear();
            var vaktmästaren = context.Personals.Where(p => p.Position == "Vaktmästare").ToList();
            foreach (var vaktmästare in vaktmästaren)
            {
                Console.WriteLine($"Namn: {vaktmästare.Fnamn} {vaktmästare.Lnamn}\nTitle: {vaktmästare.Position}");
                Console.WriteLine("══════════════════════════════════════════════════════════════");
            }
        }

        public void GetGuards()
        {
            Console.Clear();
            var väktare = context.Personals.Where(p => p.Position == "Väktare").ToList();
            foreach (var vakt in väktare)
            {
                Console.WriteLine($"Namn: {vakt.Fnamn} {vakt.Lnamn}\nTitle: {vakt.Position}");
                Console.WriteLine("══════════════════════════════════════════════════════════════");
            }
        }

        public void GetTimeWorking()
        {
            Console.Clear();
            var Personal = context.PersonalLista.ToList();
            foreach (var personal in Personal)
            {
                Console.WriteLine($"{personal.Fnamn} {personal.Lnamn}\nPosition: {personal.Position}, Jobbat i: {personal.AntalÅr} År");
                Console.WriteLine("══════════════════════════════════════════════════════════════");
            }
        }

        public void AddPersonell()
        {
            bool Godkänt = false;
            do
            {
                Menu menu = new Menu();
                using var transaction = context.Database.BeginTransaction();

                try
                {
                    Console.WriteLine("Vänligen skriv in förnamn på den nya anställda");
                    string Fnamn = Console.ReadLine();
                    Console.WriteLine("Vänligen skriv in den anställdas efternamn");
                    string Lnamn = Console.ReadLine();

                    Console.WriteLine("Vänligen skriv in den anställdas personnummer (10 siffror) ");
                    string personnummer = Console.ReadLine();

                    string[] jobb = { "Lärare", "Administration", "Vaktmästare", "Väktare" };
                    Console.WriteLine($"Vänligen välj vilken position den nya anställda ha.");
                    Console.WriteLine(string.Join("\n", jobb));
                    string position = Console.ReadLine();
                    string Avdelning = "okänd";
                    int Lön = 0;
                    DateTime idag = DateTime.Today;
                    DateOnly Anställningsdatum = DateOnly.FromDateTime(idag);

                    ValidateInput(Fnamn, Lnamn, personnummer, position, Avdelning, Lön, Anställningsdatum);
                    if (position == "Lärare" || position == "Rektor")
                    {
                        Avdelning = "Skolverket";
                        if (position == "Rektor")
                        {
                            Lön = 34000;
                        }
                        else if (position == "Lärare")
                        {
                            Lön = 24000;
                        }
                    }
                    else if (position == "Väktare")
                    {
                        Avdelning = "Säkerhet";
                    }
                    else if (position == "Administration")
                    {
                        Avdelning = "Sekretess";
                    }
                    var nypersonal = new Personal
                    {
                        Fnamn = Fnamn,
                        Lnamn = Lnamn,
                        Personnummer = personnummer,
                        Position = position,
                        Avdelning = Avdelning,
                        Lön = Lön,
                        Anställningsdatum = Anställningsdatum



                    };
                    context.Personals.Add(nypersonal);
                    context.SaveChanges();
                    transaction.Commit();
                    Console.WriteLine("Ny personal har lackts till");
                    Godkänt = true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine($"Transaction rolled back. Error: {ex.Message}");

                    Console.WriteLine("Vill du försöka igen? (y/n)");
                    var igen = Console.ReadLine();
                    if (igen?.ToLower() != "y")
                    {
                        menu.meny();
                    }
                }
            }
            while (!Godkänt);
        }
        public void ValidateInput(string Fnamn, string Lnamn, string personnummer,string position, string Avdelning, int Lön, DateOnly Anställningsdatum)
        {
            bool okPnamn = false, okPersonnr = false, okposition = false;

            okPnamn = !Fnamn.Any(Char.IsDigit) && !Lnamn.Any(Char.IsDigit);
            if (string.IsNullOrWhiteSpace(Fnamn) || string.IsNullOrWhiteSpace(Lnamn))
            {
                throw new Exception("Namnet kan inte vara tomt eller inehålla mellanrum");
            }
            if (!okPnamn)
            {
                throw new Exception("Namn och efternamn får inte inehålla siffror");
            }
            okPersonnr = personnummer.Length == 10 && personnummer.All(Char.IsDigit);
            if (!okPersonnr)
            {
                throw new Exception("Personnummer måste vara 10 siffror");
            }
            string[] jobb = { "Lärare", "Administration", "Vaktmästare", "Väktare" };
            okposition = jobb.Contains(position, StringComparer.OrdinalIgnoreCase);
            if (!okposition)
            {
                throw new Exception("Ogiltig position vänligen försök igen.");
            }
            if (context.Personals.Any(p => p.Personnummer == personnummer))
            {
                throw new Exception("Personall med detta personnummer finns redan.");
            }
        }
    }
}
