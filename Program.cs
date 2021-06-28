using System.Collections.Generic;
using System;
using System.Linq;

namespace FizzBuzz_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxNumber = GetMaximumNumber();
            var ruleOfThreeIsActive = IsRuleActive(3);
            var ruleOfFiveIsActive = IsRuleActive(5);
            var ruleOfSevenIsActive = IsRuleActive(7);
            var ruleOfElevenIsActive = IsRuleActive(11);
            var ruleOfThirteenIsActive = IsRuleActive(13);
            var ruleOfSeventeenIsActive = IsRuleActive(17);

            for (var i = 1; i <= maxNumber; i++)
            {
                var result = new List<string>();
                result.Add((i % 3 == 0 && ruleOfThreeIsActive) ? "Fizz" : null);
                result.Add((i % 13 == 0 && ruleOfThirteenIsActive) ? "Fezz" : null);
                result.Add((i % 5 == 0 && ruleOfFiveIsActive) ? "Buzz" : null);
                result.Add((i % 7 == 0 && ruleOfSevenIsActive) ? "Bang" : null);

                if (i % 11 == 0 && ruleOfElevenIsActive)
                {
                    result = new List<string> {"Bong"};
                    if ((i % 13 == 0 && ruleOfThirteenIsActive))
                    {
                        result = result.Prepend("Fezz").ToList();
                    }
                }

                if (i % 17 == 0 && ruleOfSeventeenIsActive)
                {
                    result.Reverse();
                }

                Console.Write(result.Any(x => !string.IsNullOrEmpty(x))
                    ? string.Join("", result) + " "
                    : i + " ");
            }
        }

        private static int GetMaximumNumber()
        {
            Console.WriteLine("Please enter a maximum number for FizzBuzz:");
            return int.Parse(Console.ReadLine()!);
        }

        private static bool IsRuleActive(int ruleNumber)
        {
            Console.WriteLine($"Would you like to activate the rule for the number {ruleNumber}? (y/n)");
            var response = Console.ReadLine();
            return response is "y" or "Y";
        }
    }
}