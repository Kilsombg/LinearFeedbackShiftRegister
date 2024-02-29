using System.Collections;

namespace LinearFeedbackShiftRegister
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            bool[] register = new bool[7];
            register[6] = true;

            LFSR lfsr = new LFSR(register, new int[] { 0, 5, 6 });
            lfsr.CalculatePeriod();
            lfsr.IsMSequence();

            if (lfsr.Period != -1)
            {
                Console.WriteLine($"Period of the register is: {lfsr.Period}");
            }
            else
            {
                Console.WriteLine($"Period of the register is bigger than max period ({lfsr.MaxIterationCheck} is the max iteration)");
            }

            if (lfsr.IsMSEQ)
            {
                Console.WriteLine($"The sequence of the register is m-sequence");
            }
            else
            {
                Console.WriteLine($"The sequence of the register is not m-sequence");
            }

            Console.WriteLine("End of program!");
        }
    }
}