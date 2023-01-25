using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
   public class CribleErathostene
   {
      private readonly bool[] candidates;
      private readonly int max;
      private int _lastPrimeFound = 1;
      private const int SqrtMaxInt = 46_340;

      public CribleErathostene(int max)
      {
         this.max = max;
         candidates = new bool[max + 1];
      }

      public bool TryGetNextPrime(out int prime)
      {
         var index = _lastPrimeFound + 1;

         while (candidates[index] && index < max)
         {
            index++;
         }

         prime = index;
         _lastPrimeFound = prime;


         if (!candidates[prime])
         {
            candidates[prime] = true;
            var increment = prime == 2 ? 2 : 2 * prime;
            if (prime <= SqrtMaxInt)
            {
               for (var number = prime * prime; number < max + 1; number += increment)
               {
                  candidates[number] = true;
               }
            }

            return true;
         }
         else
         {
            return false;
         }
      }

   }
}
