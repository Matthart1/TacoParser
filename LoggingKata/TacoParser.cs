﻿namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                // Do not fail if one record parsing fails, return null
                return null; // TODO Implement
            }

            // grab the latitude from your array at index 0
            var latA = cells[0];
            // grab the longitude from your array at index 1
            var lonA = cells[1];
            // grab the name from your array at index 2
            var name = cells[2];

            // Youre going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`
            var dLatitude = double.Parse(latA);
            var dLongitude = double.Parse(lonA);

            var tacoPoint = new Point();
            tacoPoint.Latitude = dLatitude;
            tacoPoint.Longitude = dLongitude;

            // You'll need to create a TacoBell class
            // that conforms to ITrackable

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly
            var bell = new TacoBell(name, tacoPoint);

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            return bell;
        }
    }
}