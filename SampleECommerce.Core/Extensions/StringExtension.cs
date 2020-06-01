using System;
using System.Collections.Generic;
using System.Text;

namespace SampleECommerce.Core.Extensions
{
    public static class StringExtension
    {
        public static bool IsNullOrEmptWhiteSpace(this string txt)
        {
            return string.IsNullOrEmpty(txt) || string.IsNullOrWhiteSpace(txt);
        }
    }
}
