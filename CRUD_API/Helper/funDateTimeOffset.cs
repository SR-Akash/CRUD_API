using System;
using System.Net;
using Newtonsoft.Json;

namespace CRUD_API.Helper
{
    public static class Datetime
    {
        public static string funDateTimeOffset()
        {
            DateTimeOffset dtOffset = DateTimeOffset.Now; // Current date and time with local time zone offset
            var dats = dtOffset.ToString();

            DateTimeOffset localDateTime = DateTimeOffset.Now;

            // Format the localDateTime to include AM/PM
            string amPmDesignation = localDateTime.ToString("tt", System.Globalization.CultureInfo.InvariantCulture);

            Console.WriteLine("AM/PM designation: " + amPmDesignation); // Outputs "AM" or "PM"


            DateTimeOffset utcOffset = DateTimeOffset.UtcNow; // Current date and time in UTC
            Console.WriteLine("UTC date and time: " + utcOffset.ToString());

            // Displaying the date and time in a specific time zone (e.g., Pacific Standard Time)
            DateTimeOffset pacificTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dtOffset, "Pacific Standard Time");
            Console.WriteLine("Pacific Time: " + pacificTime.ToString());

            return "";
        }
    }
}
