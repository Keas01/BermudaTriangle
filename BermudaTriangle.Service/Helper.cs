using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BermudaTriangle.Service
{
    public class Helper
    {
        public static bool AmIAGridRef(string gRef)
        {
            return int.TryParse(gRef.Substring(1), out int rowNum);
        }

        public static bool AmICoordinates(string gRef, out List<Coordinate> locations)
        {
            locations = JsonConvert.DeserializeObject<List<Coordinate>>(gRef);
            return locations.Count() > 0;
        }

        /// <summary>
        /// Idea from
        /// https://social.msdn.microsoft.com/Forums/vstudio/en-US/78e75d1a-0795-4bdb-8a62-ae6faa909986/convert-number-to-alphabet?forum=csharpgeneral
        /// </summary>
        /// <param name="number"></param>
        /// <param name="isCaps"></param>
        /// <returns></returns>
        public static String Number2String(int number, bool isCaps)
        {
            Char c = (Char)((isCaps ? 65 : 97) + (number - 1));
            return c.ToString();
        }
    }
}