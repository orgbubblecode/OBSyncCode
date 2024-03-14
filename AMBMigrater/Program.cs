using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMBMigrater
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Starting");

            //AMB6Operations.RestorAllTables();
            //AMB6Operations.MigrateUsers(50);
            //AMB6Operations.MigratePlansAKAPackages();
            //AMB6Operations.ProcessUserData();


            //Console.WriteLine(AMB6Operations.AMB4SelectAllFrom("users").Rows.Count);

            /*Migration Plan Sequence:
             * MigrateUsers
             * MigratePlansAKAPackages
             * 
             * 
             * 
             * 
             */


            AMB6Operations.Restore_dev_allmy_bio();



            Console.ReadLine();
            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
