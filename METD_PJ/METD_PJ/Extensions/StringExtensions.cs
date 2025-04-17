using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace METD_PJ.Extensions
{
    public static class StringExtension
    {
        public static int GetId(this string val)
        {
            Regex regId = new Regex(@"\((\d{1,5})\)$");

            if (regId.IsMatch(val))
            {
                return int.Parse(regId.Match(val).Groups[1].Value.Trim());
            }

            throw new InvalidDataException();
        }

        public static bool IsVazio(this string val) => string.IsNullOrEmpty(val.Trim());
    }
}
