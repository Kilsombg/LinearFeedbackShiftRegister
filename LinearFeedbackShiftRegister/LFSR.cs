using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearFeedbackShiftRegister
{
    public class LFSR
    {
        private readonly bool[] primaryRegister;
        private readonly List<int> xorBits;

        public int MaxIterationCheck = 101;
        public int Period { get; set; } = -1;
        public bool IsMSEQ { get; set; }

        public LFSR(bool[] bitArray, int[] xorBits)
        {
            primaryRegister = bitArray;
            this.xorBits = xorBits.Distinct().ToList();
        }

        public int CalculatePeriod()
        {
            BitArray bitArray = new BitArray(primaryRegister);
            BitArray primaryBits = new BitArray(primaryRegister);
            int iteration = 1;

            do
            {
                bool xor = CalculateXOR(bitArray);
                bitArray.RightShift(1);
                bitArray[bitArray.Count - 1] = xor;

                Console.Write($"{iteration} :");
                for (int i = 0; i < bitArray.Length; i++)
                {
                    Console.Write(bitArray[i]);
                    Console.Write(" ");
                }
                Console.WriteLine();


                if (isEqual(bitArray, primaryBits))
                {
                    break;
                }

                iteration++;
            }
            while (iteration < MaxIterationCheck);

            if (iteration == MaxIterationCheck)
            {
                Period = -1;
            }
            else
            {
                Period = iteration;
            }

            return Period;
        }


        public bool IsMSequence()
        {
            if(Period == -1) return false;

            int m = primaryRegister.Length;
            IsMSEQ = Period == (Math.Pow(2, m) - 1) ? true : false;

            return IsMSEQ;
        }

        public bool isEqual(BitArray bitArray1, BitArray bitArray2)
        {
            bool equal = true;
            for (int i = 0; i < bitArray1.Length; i++)
            {
                if (bitArray1[i] != bitArray2[i]) { equal = false; break; }
            }
            return equal;
        }

        private bool CalculateXOR(BitArray bitArray)
        {
            if (xorBits.Count() > bitArray.Length) throw new Exception("incorect bits");

            BitArray bitArrayXOR = new BitArray(xorBits.Count());
            for (int i = 0; i < bitArrayXOR.Length; i++)
            {
                bitArrayXOR[i] = bitArray[xorBits[i]];
            }


            bool result = false;
            foreach (bool bit in bitArrayXOR)
            {
                result ^= bit;
            }

            return result;
        }
    }
}
