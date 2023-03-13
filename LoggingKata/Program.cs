using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath).ToList();
            if(lines.Count == 0)
            {
                logger.LogError($"No lines to be read from csv."); 

                return;
            }
            if (lines.Count == 1)
            {
                logger.LogWarning($"Warning, only one line read.");
            }
            // Create a new instance of your TacoParser class
            var parser = new TacoParser();
            logger.LogInfo("Begin parsing");

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToList();

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            // Create a `double` variable to store the distance
            ITrackable trackable = null;
            ITrackable trackable2 = null;

            double maxDistance = 0;
            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`
            
            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            for (int i = 0; i < locations.Count; i++)
            {
                var locA = locations[i];

                var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);

                for ( int j = 0; j < locations.Count; j++)
                {
                    var locB = locations[j];

                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);

                    double distance = corA.GetDistanceTo(corB);

                    if (distance > maxDistance)
                    {
                        trackable = locA;
                        trackable2 = locB;
                        maxDistance = distance;
                    }
                }
            }

            Console.WriteLine($"{trackable.Name} and {trackable2.Name} are {maxDistance} apart");

            // Create a new corA Coordinate with your locA's lat and long

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

            // Create a new Coordinate with your locB's lat and long

            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.



        }
    }
}
