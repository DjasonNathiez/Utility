using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class EuclidDivision
    {
        public static int PgcdRecursif(int a, int b)
            => b switch
            {
                0 => a,
                _ => PgcdRecursif(b, a % b)
            };

        public static int PgcdIteratif(int a, int b)
        {
            while (b != 0)
            {
                var remainder = a % b;
                a = b;
                b = remainder;
            }

            return a;
        }

    }

}