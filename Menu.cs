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
        private readonly LAB2Context context;
        public Menu()
        {
            context = new LAB2Context();
        }
        public void meny()
        {
            Console.Clear();
            string connection = "Server=(localdb)\\MSSQLLocalDB;Database=LAB2;Trusted_Connection=True;";
            using (var context = new LAB2Context(new DbContextOptionsBuilder<LAB2Context>()
                .UseSqlServer(connection)
                .Options))
            {
                StudentService studentService = new StudentService();
                PersonalService personalService = new PersonalService();
                Console.WriteLine("══════════════════════════════════════════════════════════════");
                Console.WriteLine("Vänligen gör ett val från menyn nedan");
                Console.WriteLine("(1) Hämta Personal");
                Console.WriteLine("(2) Hämta elever och betyg");
                Console.WriteLine("(3) Lägg till en ny elev");
                Console.WriteLine("(4) Lägg till ny personal");
                Console.WriteLine("(5) Visa Lista på aktiva kurser.");
                Console.WriteLine("══════════════════════════════════════════════════════════════");
                int.TryParse(Console.ReadLine(), out int input);

                switch (input)
                {
                    case 1:
                        personalService.Personelmenu();
                        break;
                    case 2:
                        studentService.Studentmeny();
                        break;

                    case 3:
                        studentService.AddStudent();
                        break;
                    case 4:
                        personalService.AddPersonell();
                        break;
                    case 5:
                        GetCourses();
                        break;
                }
            }
        }
    public void GetCourses()
        {
            var activakurser = context.Kurs.
    Where(k => k.Aktiv).ToList();
            foreach (var item in activakurser)
            {
                if (item.Aktiv == true) //Fixa kontroll av kursstatus

                    Console.WriteLine($"Kursnamn: {item.KursNamn} Kursstatus: Aktive");

                else
                    Console.WriteLine($"Kursnamn: {item.KursNamn} Kursstatus: Inaktiv");
            }
        }
    }
}
