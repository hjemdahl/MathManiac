//Projekt DT071G Programmering i C# .NET - Moa Hjemdahl 2021
//Consoleapplication where you enter birtmonth and date and have to pass two math tests to earn a Math Maniac superhero name.

//Class for list of earned Math Maniac superhero names saved to a JSON file.

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MathManiac
{
    public class NameList
    {
        public List<SuperheroName> names = new List<SuperheroName>();
        string json = null;

        //If JSON file exists, open read and deserialize.
        public NameList()
        {
            if (File.Exists(@"namelist.json") == true)
            {
                json = File.ReadAllText(@"namelist.json");
                names = JsonConvert.DeserializeObject<List<SuperheroName>>(json);
            }
        }

        //Reverses back list(after being reversed for print in next method), removes object at index 0 to keep list 3 objects long,
        //adds object to list and then calls method to update list in JSON file.
        public SuperheroName addName(SuperheroName superheroname)
        {
            names.Reverse();
            names.RemoveAt(0);
            names.Add(superheroname);
            createUpdateList();
            return superheroname;
        }

        //Reverses list for print to console and return reversed list.
        public List<SuperheroName> getNames()
        {
            names.Reverse();
            return names;
        }

        //Serializes list and creates/writes over JSON file.
        public void createUpdateList()
        {
            json = JsonConvert.SerializeObject(names);
            File.WriteAllText(@"namelist.json", json);
        }
    }
}
