using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LAB3
{
    internal class StudentService
    {
        private readonly LAB2Context context;
        public StudentService()
        {
            context = new LAB2Context();
        }
        public void Studentmeny()
        {
            Menu menu = new Menu();
            {

                Console.Clear();
                Console.WriteLine("══════════════════════════════════════════════════════════════");
                Console.WriteLine("Vänligen gör ett val i menyn nedan");
                Console.WriteLine("(1) Hämta en lista på alla elever sorterade på förnamn.");
                Console.WriteLine("(2) Hämta en lista på alla elever sorterade på efternamn.");
                Console.WriteLine("(3) Hämta elever från en specefik klass");
                Console.WriteLine("(4) Hämta elev betyg (senaste 30 dagar)");
                Console.WriteLine("(5) Hämta elev snittbetyg");
                Console.WriteLine("(6) Hämta alla elev betyg");
                Console.WriteLine("(7) Gå tillbaka till tidigare meny");
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
                                FNameSortingDesc();
                                break;
                            case 2:
                                FnameSortingAsc();
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
                                LnamesortingDesc();
                                break;
                            case 2:
                                LnamesortingAsc();
                                break;
                            default:
                                break;

                        }
                        break;
                    case 3:
                        SelectStudentClass();
                        break;
                    case 4:
                        GetRecentGrade();
                        break;
                    case 5:
                        GetAvgGrade();
                        break;
                    case 6:
                        GetAllGrades();
                        break;
                    case 7:
                        menu.meny();
                        break;
                    }
                }    
            }
        public void FNameSortingDesc()
        {
            Console.Clear();
            var Students = context.Students.
                                   OrderByDescending(f => f.FirstName).
                                   Join(context.Klasses, s => s.FkKlassId, k => k.KlassId, (s, k) => new { s.FirstName, s.LastName, k.KlassNamn }).ToList();
            foreach (var student in Students)
            {
                Console.WriteLine($"Namn: {student.FirstName} {student.LastName}\nKlass: {student.KlassNamn}\n");
                Console.WriteLine("══════════════════════════════════════════════════════════════");
            }
        }

        public void FnameSortingAsc()
        {
            Console.Clear();
            var Studentsasc = context.Students.
                                   OrderBy(f => f.FirstName).
                                   Join(context.Klasses, s => s.FkKlassId, k => k.KlassId, (s, k) => new { s.FirstName, s.LastName, k.KlassNamn }).ToList();
            foreach (var student in Studentsasc)
            {
                Console.WriteLine($"Namn: {student.FirstName} {student.LastName}\nKlass: {student.KlassNamn}\n");
                Console.WriteLine("══════════════════════════════════════════════════════════════");
            }

        }

        public void LnamesortingDesc()
        {
            Console.Clear();
            var Students = context.Students.
                OrderByDescending(l => l.LastName).
                Join(context.Klasses, s => s.FkKlassId, k => k.KlassId, (s, k) => new { s.FirstName, s.LastName, k.KlassNamn }).ToList();
            foreach (var student in Students)
            {
                Console.WriteLine($"Namn: {student.FirstName} {student.LastName}\nKlass: {student.KlassNamn}\n");
                Console.WriteLine("══════════════════════════════════════════════════════════════");
            }
        }

        public void LnamesortingAsc()
        {
            Console.Clear();
            var Studentsasc = context.Students.
                OrderBy(l => l.LastName).
                Join(context.Klasses, s => s.FkKlassId, k => k.KlassId, (s, k) => new { s.FirstName, s.LastName, k.KlassNamn }).ToList();
            foreach (var student in Studentsasc)
            {
                Console.WriteLine($"Namn: {student.FirstName} {student.LastName}\nKlass: {student.KlassNamn}\n");
                Console.WriteLine("══════════════════════════════════════════════════════════════");
            }

        }

        public void SelectStudentClass()
        {
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
        }

        public void GetRecentGrade()
        {
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

        }

        public void GetAvgGrade()
        {
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
        }

        public void GetAllGrades()
        {
             var betyg = context.Betygs.
                Select(s => new { s.Betyg1, FNamn = s.Student.FirstName, LNamn = s.Student.LastName, kurs = s.FkKurs.KursNamn }).ToList();
            Console.WriteLine("Alla elev betyg.");
            foreach (var item in betyg)
            {
                Console.WriteLine("══════════════════════════════════════════════════════════════");
                Console.WriteLine($"Namn: {item.FNamn} {item.LNamn}. Betyg: {item.Betyg1} i kursen {item.kurs}");
            }

        }

        public void AddStudent()
        {
            bool godkänt = false;
            do
            {
                Menu menu = new Menu();
                using var transaction = context.Database.BeginTransaction();

                try
                {

                    Console.WriteLine("Vänligen skriv in Studentens förnamn");
                    string Fnamn = Console.ReadLine();
                    Console.WriteLine("Vänligen skriv in studentens efternamn");
                    string Lnamn = Console.ReadLine();


                    Console.WriteLine("Vänligen skriv in studentens personnummer (10 siffror) ");
                    string personnummer = Console.ReadLine();


                    Console.WriteLine($"Vänligen skriv in Klass ID till studenten\nKlass ID 1: NET24\nKlass ID 2: NET23\nKlass ID 3: NET22 ");
                    string FkKlassId = Console.ReadLine();
                    int.TryParse(FkKlassId, out int FkklassIds);

                    ValidateStudent(Fnamn, Lnamn, personnummer, FkklassIds);
                    var nystudent = new Student
                    {
                        FirstName = Fnamn,
                        LastName = Lnamn,
                        Personnummer = personnummer,
                        FkKlassId = FkklassIds
                    };

                    context.Students.Add(nystudent);
                    context.SaveChanges();
                    transaction.Commit();
                    Console.WriteLine("Student har laggt tills i systemet");
                    godkänt = true;
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
            while (!godkänt);
        }
        public void ValidateStudent(string FirstName, string LastName, string Personnummer, int FkKlassIds)
        {
            bool oknamn = false, okpersonnr = false, okklassid = false;
            oknamn = !FirstName.Any(Char.IsDigit) && !LastName.Any(Char.IsDigit);
            if (!oknamn)
            {
                throw new Exception("Ogiltig inmatning. Förnamn och efternamn får inte inehålla siffror.");
            }
            okpersonnr = Personnummer.Length == 10 && Personnummer.All(Char.IsDigit);
            if (!okpersonnr)
            {
                throw new Exception("Ogilltig inamtning personnummer måste vara 10 siffror.");
            }
            okklassid = FkKlassIds >= 1 && FkKlassIds <= 3;
            if (!okklassid)
            {
                throw new Exception("Ogilltigt klass ID. Ange ett nr mellan 1 och 3.");
            }
        }
    }
}
