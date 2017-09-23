using System;

namespace Joan.Misc
{
    public static class Utils
    {
        public static string GerRandString()
        {
            return new Random().Next().ToString("X");
        }
    }
}
