//Projekt DT071G Programmering i C# .NET - Moa Hjemdahl 2021
//Consoleapplication where you enter birtmonth and date and have to pass two math tests to get a Math Maniac superhero name.

//Class for Math Maniac superhero names.

using System;

namespace MathManiac
{
    public class SuperheroName
    {
        //Properties to set and get names.
        private string _month;
        private string _day;

        public string Month
        {
            set { _month = value; }
            get { return _month; }
        }

        public string Day
        {
            set { _day = value; }
            get { return _day; }
        }

        //Method who takes birthmonth and day as parameters to determen the name in i switch.
        public void setSuperheroName(string month, string day)
        {
            switch (month)
            {
                case "01":
                    _month = "Calculating";
                    break;
                case "02":
                    _month = "Deviding";
                    break;
                case "03":
                    _month = "Subtracting";
                    break;
                case "04":
                    _month = "Pi";
                    break;
                case "05":
                    _month = "Adding";
                    break;
                case "06":
                    _month = "Ruler";
                    break;
                case "07":
                    _month = "Analysing";
                    break;
                case "08":
                    _month = "Logical";
                    break;
                case "09":
                    _month = "Comparising";
                    break;
                case "10":
                    _month = "Infinite";
                    break;
                case "11":
                    _month = "Multiplying";
                    break;
                case "12":
                    _month = "Equalizing";
                    break;
            }

            switch (day)
            {
                case "01":
                    _day = "Ninja";
                    break;
                case "02":
                    _day = "Speedfingers";
                    break;
                case "03":
                    _day = "Big Brain";
                    break;
                case "04":
                    _day = "Tiger";
                    break;
                case "05":
                    _day = "Cape Carrier";
                    break;
                case "06":
                    _day = "Magician";
                    break;
                case "07":
                    _day = "Saviour";
                    break;
                case "08":
                    _day = "Quick Thinker";
                    break;
                case "09":
                    _day = "Sharp Eyes";
                    break;
                case "10":
                    _day = "Every Answer";
                    break;
                case "11":
                    _day = "Result Machine";
                    break;
                case "12":
                    _day = "Mustang";
                    break;
                case "13":
                    _day = "Wolf";
                    break;
                case "14":
                    _day = "Drogon";
                    break;
                case "15":
                    _day = "Tsunami";
                    break;
                case "16":
                    _day = "Titan";
                    break;
                case "17":
                    _day = "Shark";
                    break;
                case "18":
                    _day = "Warrior";
                    break;
                case "19":
                    _day = "Thunder";
                    break;
                case "20":
                    _day = "Eagle";
                    break;
                case "21":
                    _day = "Samurai";
                    break;
                case "22":
                    _day = "Bullseye";
                    break;
                case "23":
                    _day = "Kraken";
                    break;
                case "24":
                    _day = "Grizzly";
                    break;
                case "25":
                    _day = "Storm";
                    break;
                case "26":
                    _day = "Shredder";
                    break;
                case "27":
                    _day = "Fireball";
                    break;
                case "28":
                    _day = "Captain";
                    break;
                case "29":
                    _day = "Tornado";
                    break;
                case "30":
                    _day = "Mother";
                    break;
                case "31":
                    _day = "No Erase";
                    break;
            }
        }
    }
}