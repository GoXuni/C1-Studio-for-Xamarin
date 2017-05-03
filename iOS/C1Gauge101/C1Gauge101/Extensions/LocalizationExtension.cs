using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;

namespace C1Gauge101
{
    public static class LocalizationExtension
    {
        public static string Localize(this string text)
        {
            return NSBundle.MainBundle.LocalizedString(text, text);
        }
    }
}