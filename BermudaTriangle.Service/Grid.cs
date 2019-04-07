using System;
using System.Collections.Generic;
using System.Linq;

namespace BermudaTriangle.Service
{
    public class Grid
    {
        public int Width { get; set; }
        public int Height { get; set; }

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

        /// <summary>
        /// Converts a string to a Row number
        ///https://stackoverflow.com/questions/20044730/convert-character-to-its-alphabet-integer-position
        /// </summary>
        /// <param name="gRef"></param>
        /// <returns>Row Number<returns>
        public static int ConvertRow(string gRef)
        {
            char letter = gRef.ToCharArray().FirstOrDefault();

            int index = (int)letter % 32;

            return index;
        }

        public static int ConvertColumn(string gRef)
        {
            int col;
            int.TryParse(gRef.Substring(1), out col);
            return col;
        }
    }
}