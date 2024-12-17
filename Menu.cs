using LAB3.Data;
using LAB3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LAB3
{

    internal class Menu
    {

        public Menu()
        {

        }
        public void meny()
        {
            string connection = "Server=(localdb)\\MSSQLLocalDB;Database=LAB2;Trusted_Connection=True;";
            using (var context = new LAB2Context(new DbContextOptionsBuilder<LAB2Context>()
                .UseSqlServer(connection)
                .Options))
            {
                Console.WriteLine("══════════════════════════════════════════════════════════════");
                Console.WriteLine("Vänligen gör ett val från menyn nedan");
                Console.WriteLine("(1) Hämta Personal");
                Console.WriteLine("(2) Hämta elever och betyg");
                Console.WriteLine("(3) Lägg till en ny elev");
                Console.WriteLine("(4) Lägg till ny personal");
                Console.WriteLine("══════════════════════════════════════════════════════════════");
                int.TryParse(Console.ReadLine(), out int input);

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("══════════════════════════════════════════════════════════════");
                        Console.WriteLine("Vänligen gör ett val i menyn nedan");
                        Console.WriteLine("(1) Skriv ut en lista på all personal.");
                        Console.WriteLine("(2) Hämta Lärare");
                        Console.WriteLine("(3) Hämta Rektor");
                        Console.WriteLine("(4) Hämta Vaktmästare");
                        Console.WriteLine("(5) Hämta Väktare");
                        Console.WriteLine("(6) Gå tillbaka till tidigare meny");
                        Console.WriteLine("══════════════════════════════════════════════════════════════");
                        int.TryParse(Console.ReadLine(), out int input1);
                        switch (input1)
                        {
                            case 1:
                                Console.Clear();
                                var Personals = context.Personals.ToList();
                                foreach (var personals in Personals)
                                {
                                    Console.WriteLine($"Namn: {personals.Fnamn} {personals.Lnamn}\nTitle: {personals.Position}");
                                    Console.WriteLine("══════════════════════════════════════════════════════════════");
                                }
                                break;
                            case 2:
                                Console.Clear();
                                var teachers = context.Personals.Where(p => p.Position == "Lärare").ToList();
                                foreach (var teacher in teachers)
                                {
                                    Console.WriteLine($"Namn: {teacher.Fnamn} {teacher.Lnamn}\nTitle: {teacher.Position}");
                                    Console.WriteLine("══════════════════════════════════════════════════════════════");
                                }
                                break;
                            case 3:
                                Console.Clear();
                                var rektors = context.Personals.Where(p => p.Position == "Rektor").ToList();
                                foreach (var rektor in rektors)
                                {
                                    Console.WriteLine($"Namn: {rektor.Fnamn} {rektor.Lnamn}\nTitle: {rektor.Position}");
                                    Console.WriteLine("══════════════════════════════════════════════════════════════");
                                }
                                break;
                            case 4:
                                Console.Clear();
                                var vaktmästaren = context.Personals.Where(p => p.Position == "Vaktmästare").ToList();
                                foreach (var vaktmästare in vaktmästaren)
                                {
                                    Console.WriteLine($"Namn: {vaktmästare.Fnamn} {vaktmästare.Lnamn}\nTitle: {vaktmästare.Position}");
                                    Console.WriteLine("══════════════════════════════════════════════════════════════");
                                }
                                break;
                            case 5:
                                Console.Clear();
                                var väktare = context.Personals.Where(p => p.Position == "Väktare").ToList();
                                foreach (var vakt in väktare)
                                {
                                    Console.WriteLine($"Namn: {vakt.Fnamn} {vakt.Lnamn}\nTitle: {vakt.Position}");
                                    Console.WriteLine("══════════════════════════════════════════════════════════════");
                                }
                                break;
                            default:
                                break;

                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("══════════════════════════════════════════════════════════════");
                        Console.WriteLine("Vänligen gör ett val i menyn nedan");
                        Console.WriteLine("(1) Hämta en lista på alla elever sorterade på förnamn.");
                        Console.WriteLine("(2) Hämta en lista på alla elever sorterade på efternamn.");
                        Console.WriteLine("(3) Hämta elever från en specefik klass");
                        Console.WriteLine("(4) Hämta elev betyg");
                        Console.WriteLine("(5) Hämta elev snittbetyg");
                        Console.WriteLine("(6) Gå tillbaka till tidigare meny");
                        Console.WriteLine("══════════════════════════════════════════════════════════════");
                        int.TryParse(Console.ReadLine(), out int input2);
                        switch (input2)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("══════════════════════════════════════════════════════════════");
                                Console.WriteLine("(1) Sortera i fallande ordning");
                                Console.WriteLine("(2) Sortera i stigande ordning");
                                Console.WriteLine("(3) Gå till baka till tidigare meny");
                                Console.WriteLine("══════════════════════════════════════════════════════════════");
                                int.TryParse(Console.ReadLine(), out int input3);
                                switch (input3)
                                {
                                    case 1:
                                        Console.Clear();
                                        var Students = context.Students.
                                            OrderByDescending(f => f.FirstName).
                                            Join(context.Klasses, s => s.FkKlassId, k => k.KlassId, (s, k) => new { s.FirstName, s.LastName, k.KlassNamn }).ToList();
                                        foreach (var student in Students)
                                        {
                                            Console.WriteLine($"Namn: {student.FirstName} {student.LastName}\nKlass: {student.KlassNamn}\n");
                                            Console.WriteLine("══════════════════════════════════════════════════════════════");
                                        }
                                        break;
                                    case 2:
                                        Console.Clear();
                                        var Studentsasc = context.Students.
                                            OrderBy(f => f.FirstName).
                                            Join(context.Klasses, s => s.FkKlassId, k => k.KlassId, (s, k) => new { s.FirstName, s.LastName, k.KlassNamn }).ToList();
                                        foreach (var student in Studentsasc)
                                        {
                                            Console.WriteLine($"Namn: {student.FirstName} {student.LastName}\nKlass: {student.KlassNamn}\n");
                                            Console.WriteLine("══════════════════════════════════════════════════════════════");
                                        }

                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("══════════════════════════════════════════════════════════════");
                                Console.WriteLine("(1) Sortera i fallande ordning");
                                Console.WriteLine("(2) Sortera i stigande ordning");
                                Console.WriteLine("(3) Gå till baka till tidigare meny");
                                Console.WriteLine("══════════════════════════════════════════════════════════════");
                                int.TryParse(Console.ReadLine(), out int input4);
                                switch (input4)
                                {
                                    case 1:
                                        Console.Clear();
                                        var Students = context.Students.
                                            OrderByDescending(l => l.LastName).
                                            Join(context.Klasses, s => s.FkKlassId, k => k.KlassId, (s, k) => new { s.FirstName, s.LastName, k.KlassNamn }).ToList();
                                        foreach (var student in Students)
                                        {
                                            Console.WriteLine($"Namn: {student.FirstName} {student.LastName}\nKlass: {student.KlassNamn}\n");
                                            Console.WriteLine("══════════════════════════════════════════════════════════════");
                                        }
                                        break;
                                    case 2:
                                        Console.Clear();
                                        var Studentsasc = context.Students.
                                            OrderBy(l => l.LastName).
                                            Join(context.Klasses, s => s.FkKlassId, k => k.KlassId, (s, k) => new { s.FirstName, s.LastName, k.KlassNamn }).ToList();
                                        foreach (var student in Studentsasc)
                                        {
                                            Console.WriteLine($"Namn: {student.FirstName} {student.LastName}\nKlass: {student.KlassNamn}\n");
                                            Console.WriteLine("══════════════════════════════════════════════════════════════");
                                        }

                                        break;
                                    default:
                                        break;

                                }
                                break;
                            case 3:
                                Console.Clear();
                                var klasses = context.Klasses.ToList();
                                Console.WriteLine("══════════════════════════════════════════════════════════════");
                                Console.WriteLine("Lista på alla klasser");
                                foreach (var klass in klasses)
                                {
                                    Console.WriteLine($"{klass.KlassNamn}");
                                }
                                Console.WriteLine("══════════════════════════════════════════════════════════════");
                                Console.WriteLine("Skriv in namnet på klassen du vill se eleverna i");
                                string klassnamn = Console.ReadLine().ToUpper();
                                if (klassnamn == null)
                                    return;
                                var studentsinklass = context.Students.
                                    Where(s => s.FkKlass.KlassNamn == klassnamn).
                                    Select(s => new
                                    { s.FirstName, s.LastName, klassnamn = s.FkKlass.KlassNamn }).ToList();
                                if (studentsinklass.Any())
                                {
                                    Console.WriteLine("══════════════════════════════════════════════════════════════");
                                    Console.WriteLine($"Elever i klass {klassnamn}: ");
                                    foreach (var student in studentsinklass)
                                    {
                                        Console.WriteLine($"Namn: {student.FirstName} {student.LastName}");
                                        Console.WriteLine("══════════════════════════════════════════════════════════════");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Inga elever hittades");
                                }
                                break;
                            case 4:
                                Console.Clear();
                                var betygsdatum30 = DateOnly.FromDateTime(DateTime.Now.AddDays(-30));

                                var betyg = context.Betygs.
                                    Where(b => b.BetygsDatum >= betygsdatum30).
                                    Select(s => new { s.Betyg1, FNamn = s.Student.FirstName, LNamn = s.Student.LastName, kurs = s.FkKurs.KursNamn }).ToList();
                                Console.WriteLine("Betyg från de senste 30 dagarna.");
                                foreach (var item in betyg)
                                {
                                    Console.WriteLine("══════════════════════════════════════════════════════════════");
                                    Console.WriteLine($"Namn: {item.FNamn} {item.LNamn}. Betyg: {item.Betyg1} i kursen {item.kurs}");
                                }

                                break;
                            case 5:
                                Console.Clear();
                                var betygsnitt = context.Betygs.
                                    GroupBy(b => b.FkKurs.KursNamn).
                                    Select(group => new
                                    { FkKursnamn = group.Key, KursSnitt = group.Average(b => b.Betyg1), KursLåg = group.Min(b => b.Betyg1), KursHög = group.Max(b => b.Betyg1) }).
                                    ToList();
                                foreach (var snitt in betygsnitt)
                                {
                                    Console.WriteLine($"Kurs: {snitt.FkKursnamn} Snittbetyg: {snitt.KursSnitt:F}\nHögsta och Lägsta betyget i kursen {snitt.KursHög} : {snitt.KursLåg} ");
                                    Console.WriteLine("══════════════════════════════════════════════════════════════");
                                }
                                Console.ReadLine();
                                break;
                        }
                        break;
                    case 3:
                        bool oknamn = false, okpersonnr = false, okklassid = false;
                        do
                        {
                            Console.WriteLine("Vänligen skriv in Studentens förnamn");
                            string Fnamn = Console.ReadLine();
                            Console.WriteLine("Vänligen skriv in studentens efternamn");
                            string Lnamn = Console.ReadLine();

                            oknamn = !Fnamn.Any(Char.IsDigit) && !Lnamn.Any(Char.IsDigit);
                            if (!oknamn)
                            {
                                Console.WriteLine("Ogiltig inmatning. Förnamn och efternamn får inte inehålla siffror.");
                                continue;
                            }
                            Console.WriteLine("Vänligen skriv in studentens personnummer (10 siffror) ");
                            string personnummer = Console.ReadLine();
                            okpersonnr = personnummer.Length == 10 && personnummer.All(Char.IsDigit);
                            if (!okpersonnr)
                            {
                                Console.WriteLine("Ogilltig inamtning personnummer måste vara 10 siffror.");
                                continue;
                            }

                            Console.WriteLine($"Vänligen skriv in Klass ID till studenten\nKlass ID 1: NET24\nKlass ID 2: NET23\nKlass ID 3: NET22 ");
                            string klassidinput = Console.ReadLine();
                            okklassid = int.TryParse(klassidinput, out int klassid) && klassid >= 1 && klassid <= 3;
                            if (!okklassid)
                            {
                                Console.WriteLine("Ogilltigt klass ID. Ange ett nr mellan 1 och 3.");
                                continue;
                            }

                            var nystudent = new Student
                            {
                                FirstName = Fnamn,
                                LastName = Lnamn,
                                Personnummer = personnummer,
                                FkKlassId = klassid
                            };
                            try
                            {
                                context.Students.Add(nystudent);
                                context.SaveChanges();
                                Console.WriteLine("Student har laggt tills i systemet");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Ett fel inträffade {ex.Message}");
                            }
                            break;
                        }
                        while (!oknamn || !okpersonnr || !okklassid);
                        break;
                    case 4:
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
                        break;
                    }
                }
            }
        }
    }

