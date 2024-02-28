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

        public LFSR(bool[] bitArray, int[] xorBits)
        {
            primaryRegister = bitArray;
            this.xorBits = xorBits.Distinct().ToList();
        }

        public int Period()
        {
            BitArray bitArray = new BitArray(primaryRegister);
            BitArray primaryBits = new BitArray(primaryRegister);
            int maxIteration = 101;
            int iteration = 1;

            do
            {
                bool xor = CalculateXOR(bitArray);
                bitArray.RightShift(1);
                bitArray[bitArray.Count - 1] = xor;

                if (isEqual(bitArray,primaryBits)) {
                    break; 
                }

                Console.Write($"{iteration} :");
                for (int i = 0; i < bitArray.Length; i++)
                {
                    Console.Write(bitArray[i]);
                    Console.Write(" ");
                }
                Console.WriteLine();

                    iteration++;
            }
            while (iteration < maxIteration);

            if(iteration == maxIteration)
            {
                return -1;
            }
            else return iteration;
        }

        public bool isEqual(BitArray bitArray1, BitArray bitArray2) {
            bool equal = true;
            for(int i=0; i<bitArray1.Length; i++)
            {
                if (bitArray1[i] != bitArray2[i]) { equal = false;  break; }
            }
            return equal;
        }

        private bool CalculateXOR(BitArray bitArray)
        {
            if(xorBits.Count() > bitArray.Length) throw new Exception("incorect bits");

            BitArray bitArrayXOR = new BitArray(xorBits.Count());
            for(int i=0; i<bitArrayXOR.Length; i++)
            {
                bitArrayXOR[i] = bitArray[xorBits[i]];
            }


            bool result = false;
            foreach(bool bit in bitArrayXOR)
            {
                result ^= bit;
            }

            return result;
        }
    }
}
