//Projekt DT071G Programmering i C# .NET - Moa Hjemdahl 2021
//Consoleapplication where you enter birtmonth and date and have to pass two math tests to get a Math Maniac superhero name.

using System;
using System.Globalization;
using System.Threading.Tasks;
using static System.Console;

namespace MathManiac
{
    class Program
    {
        static void Main(string[] args)
        {
            Welcome();
        }

        //Welcome method.
        //Instantiates NameList class, prints out list of 3 names with the most recent on top.
        //Sends instantiated list as parameter on its way to the goal method.
        static void Welcome()
        {
            NameList namelist = new NameList();

            Clear();
            WriteLine("\n🄼 🄰 🅃 🄷 🄼 🄰 🄽 🄸 🄰 🄲\n");
            WriteLine("Our three most recent maniacs:");

            foreach (SuperheroName superheroname in namelist.getNames())
            {
                WriteLine("* " + superheroname.Month + " " + superheroname.Day);
            }

            createSuperheroName(namelist);
        }

        //Method to create superhero name.
        //Instantiates SuperheroName class, asks fot birthmonth and date, reads input and checks if it's a valid date, not null or empty and is 4 charaters long.
        //Then splits string into seperate month and day and passes them as parameters to SuperheroName class to set the names.
        //Sends instantiated list and superhero name as parameters on its way to the goal method.

        static void createSuperheroName(NameList namelist)
        {
            SuperheroName superheroname = new SuperheroName();

            Write("\nWelcome, please enter your birthmonth and birthdate (MMDD) to recieve your mathmaniac superhero name: ");

            string dateInput;
            string format;
            bool dateFormat;
            DateTime fullDate;
            string month;
            string day;

            do
            {
                dateInput = ReadLine();
                format = "Mdd";
                CultureInfo provider = CultureInfo.InvariantCulture;

                dateFormat = DateTime.TryParseExact(dateInput, format, provider, DateTimeStyles.None, out fullDate);

                if (string.IsNullOrEmpty(dateInput) || dateInput.Length != 4 || !dateFormat)
                {
                    Write("No valid date was entered, sharpen than mathbrain of yours and give it one more go: ");
                }
            }
            while (string.IsNullOrEmpty(dateInput) || dateInput.Length != 4 || !dateFormat);

            month = dateInput.Substring(0, 2);
            day = dateInput.Substring(2, 2);

            superheroname.setSuperheroName(month, day);
            AcceptChallangeOne(superheroname, namelist);
        }

        //Method to enter or escpare first challange.
        //Informs of the two challanges that need to be passed, gives options to enter or escape, reads key and executes in switch.
        //Sends instantiated list and superhero name as parameters on its way to the goal method.
        static void AcceptChallangeOne(SuperheroName superheroname, NameList namelist)
        {
            do
            {
                Clear();
                WriteLine("\n🄼 🄰 🅃 🄷 🄼 🄰 🄽 🄸 🄰 🄲\n");
                WriteLine("Hold up, hold up! You have to earn your mathmaniac superhero name by passing trough two challanges.\nFirst up, lest test your multiplication skills. You have 6 chanses to get 4 correct answers.");
                Write("\nUp for it? Press enter! Otherwise Esc is your way out.");

                ConsoleKeyInfo key = ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        ChallengeOne(superheroname, namelist);
                        break;

                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            } while (ReadKey().Key != ConsoleKey.Escape);
        }

        //Method for first challange
        //Instantiates random class, prints round and points status, creates two random numbers between 1-12 and it's result when mulitplyed.
        //Print multiplication challange, reads answer and compares it to result. If correct, one point is added. When 4 points is reached method to
        //accept challange two is called. Every round is counted and if failed to get 4 points on 6 rounds failed mathod is called.
        //Sends instantiated list and superhero name as parameters on its way to the goal method.
        static void ChallengeOne(SuperheroName superheroname, NameList namelist)
        {
            Random random = new Random();

            int rounds = 0;
            int points = 0;

            while (rounds < 6)
            {
                Clear();
                WriteLine("\n🄼 🄰 🅃 🄷 🄼 🄰 🄽 🄸 🄰 🄲\n");
                WriteLine("Points: " + points);
                WriteLine("Round: " + rounds + "/6\n");

                int rand1 = random.Next(1, 12);
                int rand2 = random.Next(1, 12);
                int result = rand1 * rand2;
                int answer;
                bool numberic;

                Write(rand1 + " x " + rand2 + " = ");

                string strAnswer = ReadLine();
                numberic = int.TryParse(strAnswer, out answer);

                if (answer == result)
                {
                    points++;

                    if (points == 4)
                    {
                        AcceptChallangeTwo(superheroname, namelist);
                    }
                }

                rounds++;
            }

            Failed();
        }

        //Method to enter or escpare second challange.
        //Informs about challange, gives options to enter or escape, reads key and executes in switch.
        //Sends instantiated list and superhero name as parameters on its way to the goal method.
        static void AcceptChallangeTwo(SuperheroName superheroname, NameList namelist)
        {
            do
            {
                Clear();
                WriteLine("\n🄼 🄰 🅃 🄷 🄼 🄰 🄽 🄸 🄰 🄲\n");
                WriteLine("Good job, halfway there.\nNow let's test another skill of yours, addition! Again you have 6 chanses to get 4 correct answers.");
                Write("\nUp for it? Press enter! Otherwise Esc is your way out.");

                ConsoleKeyInfo key = ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        ChallengeTwo(superheroname, namelist);
                        break;

                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            } while (ReadKey().Key != ConsoleKey.Escape);
        }

        //Method for second challange
        //Instantiates random class, prints round and points status, creates two random numbers between 1-300 and it's result when added.
        //Print addition challange, reads answer and compares it to result. If correct, one point is added. When 4 points is reached goal method is called.
        //Every round is counted and if failed to get 4 points on 6 rounds failed mathod is called.
        //Sends instantiated list and superhero name as parameters on its way to the goal method.
        static void ChallengeTwo(SuperheroName superheroname, NameList namelist)
        {
            Random random = new Random();

            int rounds = 0;
            int points = 0;

            while (rounds < 6)
            {
                Clear();
                WriteLine("\n🄼 🄰 🅃 🄷 🄼 🄰 🄽 🄸 🄰 🄲\n");
                WriteLine("Points: " + points);
                WriteLine("Round: " + rounds + "/6\n");

                int rand1 = random.Next(1, 300);
                int rand2 = random.Next(1, 300);
                int result = rand1 + rand2;
                int answer;
                bool numberic;

                Write(rand1 + " + " + rand2 + " = ");

                string strAnswer = ReadLine();
                numberic = int.TryParse(strAnswer, out answer);

                if (answer == result)
                {
                    points++;

                    if (points == 4)
                    {
                        Goal(superheroname, namelist);
                    }
                }

                rounds++;
            }

            Failed();
        }

        //Method for failed challanges
        //Informs of failiure and calls welcome method after 4 seconds.
        static void Failed()
        {
            Clear();
            WriteLine("\n🄼 🄰 🅃 🄷 🄼 🄰 🄽 🄸 🄰 🄲\n");
            WriteLine("Sorry, that didn't go well. I'll send you back to the beginning...");

            Task.Delay(4000).Wait();
            Welcome();
        }

        //Method for completed challanges
        //Adds recieved paramater for superheroname to recieved parameter for namelist. Print out earned name and options to escape or go again.
        //Reds key to execute options in switch.
        static void Goal(SuperheroName superheroname, NameList namelist)
        {
            do
            {
                namelist.addName(superheroname);

                Clear();
                WriteLine("\n🄼 🄰 🅃 🄷 🄼 🄰 🄽 🄸 🄰 🄲\n");
                WriteLine("Congratulations my friend, you are a true mathmaniac!\nYou finally earnd your name:\n\n" + superheroname.Month + " " + superheroname.Day + "\n");

                WriteLine("\nEscape? Press Esc.");
                WriteLine("Or go again? Press Enter.");

                ConsoleKeyInfo key = ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        Welcome();
                        break;

                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            } while (ReadKey().Key != ConsoleKey.Escape);
        }
    }
}