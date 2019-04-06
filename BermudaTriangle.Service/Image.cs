using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BermudaTriangle.Service
{
    public abstract class Image
    {
        public int ImageSide { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        /// <summary>
        /// Idea from
        /// https://social.msdn.microsoft.com/Forums/vstudio/en-US/78e75d1a-0795-4bdb-8a62-ae6faa909986/convert-number-to-alphabet?forum=csharpgeneral
        /// </summary>
        /// <param name="number"></param>
        /// <param name="isCaps"></param>
        /// <returns></returns>
        public String Number2String(int number, bool isCaps)
        {
            Char c = (Char)((isCaps ? 65 : 97) + (number - 1));
            return c.ToString();
        }

        public int ConvertRow(string gRef)
        {
            char letter = gRef.ToCharArray().FirstOrDefault();

            //https://stackoverflow.com/questions/20044730/convert-character-to-its-alphabet-integer-position
            int index = (int)letter % 32;

            return index;
        }

        public int ConvertColumn(string gRef)
        {
            int col;
            int.TryParse(gRef.Substring(1), out col);
            return col;
        }
    }
}