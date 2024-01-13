using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace car_magazine
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var context = new AppDbContext())
            {
                if (!context.Roles.Any(r => r.Name == "admin"))
                {
                    context.Roles.Add(new Role { Name = "admin" });
                }

                if (!context.Roles.Any(r => r.Name == "moderator"))
                {
                    context.Roles.Add(new Role { Name = "moderator" });
                }
                context.SaveChanges();
            }
            /*Application.Run(new RegistrationForm());*/
            Application.Run(new LoginForm());
        }
    }
}
