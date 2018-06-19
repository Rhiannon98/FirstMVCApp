// what we are using within the cs file (shortens the amount of chaining in our code)
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVCApp.Models
{
    public class TimePeople
    {
        // properties for stuff from csv
        // context
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Birth_Year { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }
        // public method that returns a list of people from Time
        // takes in 2 different (or maybe same) years
        public List<TimePeople> GetPeople(int beginYear, int endYear)
        {
            // setting people to equal a new List of TimePeople
            List<TimePeople> people = new List<TimePeople>();
            // path is now equal to the directory "path" in the computer
            // of the current user for whereever these files end up being
            string path = Environment.CurrentDirectory;
            // new path that is a full path with the root csv file included
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\personOfTheYear.csv"));
            // reading the lines of the file, specifically the path wiht the root connected
            string[] myFile = File.ReadAllLines(newPath);

            // for loop to iterate through the csv file.
            for (int i = 1; i < myFile.Length; i++)
            {
                // string array to split the csv file by commas
                string[] fields = myFile[i].Split(',');
                // adding new object each time there is a split item and assigning the keys 
                // the appropriate values provided from the csv file
                people.Add(new TimePeople
                {
                    Year = Convert.ToInt32(fields[0]),
                    Honor = fields[1],
                    Name = fields[2],
                    Country = fields[3],
                    Birth_Year = (fields[4] == "") ? 0 : Convert.ToInt32(fields[4]),
                    DeathYear = (fields[5] == "") ? 0 : Convert.ToInt32(fields[5]),
                    Title = fields[6],
                    Category = fields[7],
                    Context = fields[8],
                });
            }
            // fulfilling the return requirements by setting the asked for
            // list of people to be between or on the years requested.
            List<TimePeople> listofPeople = people.Where(p => (p.Year >= beginYear) && (p.Year <= endYear)).ToList();
            return listofPeople;
        }
    }
}
// end