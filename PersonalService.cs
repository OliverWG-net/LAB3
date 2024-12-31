using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3
{
    internal class PersonalService
    {
        private readonly LAB2Context context;

        public PersonalService(LAB2Context _context)
        {
            _context = context;
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
            bool okPnamn = false, okPersonnr = false, okposition = false;
            do
            {
                Console.WriteLine("Vänligen skriv in förnamn på den nya anställda");
                string Fnamn = Console.ReadLine();
                Console.WriteLine("Vänligen skriv in den anställdas efternamn");
                string Lnamn = Console.ReadLine();

                okPnamn = !Fnamn.Any(Char.IsDigit) && !Lnamn.Any(Char.IsDigit);
                if (!okPnamn)
                {
                    Console.WriteLine("Ogiltig inmatning. Förnamn och efternamn får inte inehålla siffror.");
                    continue;
                }
                Console.WriteLine("Vänligen skriv in den anställdas personnummer (10 siffror) ");
                string personnummer = Console.ReadLine();
                okPersonnr = personnummer.Length == 10 && personnummer.All(Char.IsDigit);
                if (!okPersonnr)
                {
                    Console.WriteLine("Ogilltig inamtning personnummer måste vara 10 siffror.");
                    continue;
                }

                string[] jobb = { "Lärare", "Administration", "Vaktmästare", "Väktare" };
                Console.WriteLine($"Vänligen välj vilken position den nya anställda ha.");
                Console.WriteLine(string.Join("\n", jobb));
                string postition = Console.ReadLine();
                okposition = jobb.Contains(postition, StringComparer.OrdinalIgnoreCase);
                if (!okposition)
                {
                    Console.WriteLine("Ogilltig position. vänligen försök igen.");
                    continue;
                }

                var nypersonal = new Personal
                {
                    Fnamn = Fnamn,
                    Lnamn = Lnamn,
                    Personnummer = personnummer,
                    Position = postition
                };
                try
                {
                    context.Personals.Add(nypersonal);
                    context.SaveChanges();
                    Console.WriteLine("Ny personal har laggt tills i systemet");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ett fel inträffade {ex.Message}");
                }
                break;
            }
            while (!okPnamn || !okPersonnr || !okposition);
        }
    }
}
