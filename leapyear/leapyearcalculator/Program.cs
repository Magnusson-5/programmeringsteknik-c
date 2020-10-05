using System;

namespace leapyearcalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstYear = int.Parse(args[0]);
            int secondYear = int.Parse(args[1]);

            int maxYear = Math.Max(firstYear, secondYear);
            int minYear = Math.Min(firstYear, secondYear);

            int leapYearCount = 0;

            for (int year = minYear; year <= maxYear; year++)
            {
                bool isLeapYear = DateTime.IsLeapYear(year);
                
                if (isLeapYear)
                {
                    leapYearCount++;
                }
            }

            Console.WriteLine($"Encountered {leapYearCount} leap years from {minYear} to {maxYear}");





            //int isLeapYear = 0;

            //Console.Write("Skriv in ett årtal: ");
            //int firstYear = int.Parse(Console.ReadLine());
            //int secondYear = 0;

            //while (secondYear < firstYear)
            //{
            //    Console.Write("Skriv in ett till, högre årtal: ");
            //    secondYear = int.Parse(Console.ReadLine());
            //}

            //Console.WriteLine($"Du skrev in {firstYear} och {secondYear}.");


            //while (DateTime.IsLeapYear(secondYear) == false)
            //{
            //    secondYear -= 1;
            //}

            //int totalYears = secondYear - firstYear;
            //totalYears =totalYears / 4;
            //Console.WriteLine($"There is {totalYears}");

            //Console.WriteLine($"{secondYear}");
            // If the year is evenly divisible by 4, go to step 2. ...
            // If the year is evenly divisible by 100, go to step 3. ...
            // If the year is evenly divisible by 400, go to step 4
            
            // Räkna ut hur många skottår som passerat mellan två inmatade värden.

            // DateTime.IsLeapYear(year) är en metod man kan använda.
        }
    }
}
