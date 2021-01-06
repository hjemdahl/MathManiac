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

        static void Failed()
        {
            Clear();
            WriteLine("\n🄼 🄰 🅃 🄷 🄼 🄰 🄽 🄸 🄰 🄲\n");
            WriteLine("Sorry, that didn't go well. I'll send you back to the beginning...");

            Task.Delay(4000).Wait();
            Welcome();
        }

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