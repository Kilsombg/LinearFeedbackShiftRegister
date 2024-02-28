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
            int a = lfsr.Period();

            Console.WriteLine("End of program!");
        }
    }
}