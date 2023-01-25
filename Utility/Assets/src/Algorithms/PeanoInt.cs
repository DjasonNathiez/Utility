using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public abstract class PeanoInt
    {
        public static PeanoInt Zero => PeanoZero.Instance;
        public static PeanoInt Successor(PeanoInt predecessor) => new PeanoNonZero(predecessor);

        public static explicit operator int(PeanoInt p) => p switch
        {
            PeanoZero => 0,
            PeanoNonZero nonZero => 1+(int)nonZero.Predecessor,
            _ => throw new ArgumentException("shouldn't happen")
        };

        public static explicit operator PeanoInt(int i) => i switch
        {
            0 => Zero,
            >0 => Successor((PeanoInt)(i-1)),
            _ => throw new ArgumentException("negative int cannot be represented as natural numbers")
        };

        public override abstract string ToString();

        public abstract string ToString(string format);
        
        public static PeanoInt Add(PeanoInt a, PeanoInt b) => (a, b) switch
        {
            (PeanoZero, _) => b,
            (PeanoNonZero aNonZero, _) => Successor (Add(aNonZero.Predecessor, b)),
            _ => throw new ArgumentException("unexpected arguments")
        };
        
        public static PeanoInt Substract(PeanoInt a, PeanoInt b) => (a, b) switch
        {
            (_,PeanoZero) => a,
            (PeanoZero , _) => throw new ArgumentException("Negative integers are not supported"),
            (PeanoNonZero nonZeroA, PeanoNonZero nonZeroB) => Substract(nonZeroA.Predecessor, nonZeroB.Predecessor),
            _ => throw new ArgumentException("Unexpected arguments")
        };
        
        public static PeanoInt Multiply(PeanoInt a, PeanoInt b) => (a, b) switch
        {
            (_, PeanoZero) => Zero,
            (_, PeanoNonZero nonZeroB) => Add(a, Multiply(a, nonZeroB.Predecessor)),
            _ => throw new ArgumentException("Unexpected arguments")
        };
    }

    public sealed class PeanoZero : PeanoInt
    {
        public static PeanoZero Instance { get; } = new PeanoZero();
        private PeanoZero() { }
        
        public override string ToString() => "0";

        public override string ToString(string format) => 0.ToString(format);
        
    }

    public sealed class PeanoNonZero : PeanoInt
    {
        public PeanoInt Predecessor { get; }

        public PeanoNonZero(PeanoInt predecessor)
        {
            Predecessor = predecessor;
        }
        
        public override string ToString() => ((int)this).ToString();

        public override string ToString(string format)
            => format switch
            {
                //"s" => $"S{Successor:s}",
                //"S" => $"S({Successor:S})",
                _ => ((int)this).ToString(format)
            };
    }


}
