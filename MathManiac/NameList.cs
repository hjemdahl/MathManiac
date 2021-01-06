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

        public NameList()
        {
            if (File.Exists(@"namelist.json") == true)
            {
                json = File.ReadAllText(@"namelist.json");
                names = JsonConvert.DeserializeObject<List<SuperheroName>>(json);
            }
        }

        public SuperheroName addName(SuperheroName superheroname)
        {
            names.Reverse();
            names.RemoveAt(0);
            names.Add(superheroname);
            createUpdateList();
            return superheroname;
        }

        public List<SuperheroName> getNames()
        {
            names.Reverse();
            return names;
        }

        public void createUpdateList()
        {
            json = JsonConvert.SerializeObject(names);
            File.WriteAllText(@"namelist.json", json);
        }
    }
}
