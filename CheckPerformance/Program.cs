using System;
using System.Linq;
using System.Diagnostics;

namespace CheckPerformance
{
    class Program
    {
        static void Main(string[] args)
        {

            Stopwatch sw = new Stopwatch();
            sw.Start();
            int range = 999;
             int sum = Enumerable.Range(1, range).Where(x => isDivisible(x)).Sum();
            sw.Stop();
            Console.WriteLine("Linq : Sum = {0} , Time Taken = {1} ", sum, sw.Elapsed);
            sw.Restart();
            sw.Start();
            int sumloop = getSumfromLoop(range);    
            sw.Stop();
            Console.WriteLine("Legacy Loop(no lood cut) : Sum = {0} , Time Taken = {1} ", sumloop, sw.Elapsed);
            
            sw.Restart();
            sw.Start();
            int sum2 = getSum(range);
            sw.Stop();
            Console.WriteLine("Legacy : Sum = {0} , Time Taken = {1} ", sum2, sw.Elapsed);
            Console.ReadLine();
        }

        public static bool isDivisible(int x)
        {
            if (x % 3 == 0 || x % 5 == 0) { return true; }
            else return false;
        }

        public static int getSumfromLoop(int range)
        {
            int index = 1;            
            int sum = 0;

            while (index <= range)
            {
                if (index % 3 == 0 || index % 5 == 0) sum = sum + index;
                index++;
            }
            return sum;
        }
        public static int getSum(int range)
        {
            int sum = 0;
            int index = 1;

            while (index <= range)
            {
                //int fivemult = 5 * index;

                if (index * 3 <= range) sum = sum + index * 3;
                else break;

                if (index * 5 <= range && (index * 5) % 3 != 0) sum = sum + index * 5;
                //else break;

                index++;
            }

            return sum;
        }
    }
}
    
