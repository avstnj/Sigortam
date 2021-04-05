using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sigortam.CSigorta.Api.Helper
{
    public static class Helpers
    {
        public static int RandomNumber(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }
    }
}
