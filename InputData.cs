using System;
using System.Transactions;

namespace HSE_Lab_9
{
    internal class InputData
    {
        //работы с целыми числами
        public static bool IsInteger(string s, bool mustBePositive)
        {
            int value;
            return (Int32.TryParse(s, out value) && (value > 0 || !mustBePositive));
        }
        public static bool IntIsInRange(int n, int min, int high)
        {
            return n <= high && n >= min;
        }
        public static int GetInteger(string msg, bool mustBePositive)
        {
            string console = GetString(msg);
            while (!IsInteger(console, mustBePositive))
                console = GetString($"Enter a valid integer");
            return Int32.Parse(console);
        }
        public static int GetIntInRange(string msg, int min, int high)
        {
            string console = GetString(msg);
            while (!(IsInteger(console, false) && IntIsInRange(Int32.Parse(console), min, high)))
                console = GetString($"Enter a valid integer within the ({min} : {high}) range");
            return Int32.Parse(console);
        }

        //работа с вещественными числами
        public static bool IsDouble(string s, bool mustBePositive)
        {
            double value;
            return (Double.TryParse(s, out value) && (value > 0 || !mustBePositive));
        }
        public static double GetDouble(string msg, bool mustBePositive)
        {
            string console = GetString(msg);
            while (!IsDouble(console, mustBePositive))
                console = GetString($"Enter a valid real number");
            return Double.Parse(console);
        }
        public static bool DoubleIsInRange(double n, double min, double high)
        {
            return n <= high && n >= min;
        }
        public static double GetDoubleInRange(string msg, double min, double high)
        {
            string console = GetString(msg);
            while (!(IsDouble(console, false) && DoubleIsInRange(Double.Parse(console), min, high)))
                console = GetString($"Enter a valid real number within the ({min} : {high}) range");
            return Double.Parse(console);
        }


        //работа со строками
        public static string GetString(string msg)
        {
            Console.WriteLine(msg);
            return Console.ReadLine();
        }

        public static string NumerableEnding(int i)
        {
            if (i > 3 && i < 21)
                return "th";
            else
            {
                i = i % 10;
                return i switch
                {
                    1 => "st",
                    2 => "nd",
                    3 => "rd",
                    _ => "th",
                };
            }
        }

        //работа с классами
        public static StudentArray FillArray(int size)
        {
            StudentArray array = new StudentArray(size);
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"\nEnter {i + 1}{NumerableEnding(i + 1)} student's data");
                array[i] = GetStudentInfo();
            }
            return array;
        }

        public static Student GetStudentInfo()
        {
            return new Student(GetString("Enter the student's name"), GetIntInRange("Enter the student's age between 14 and 65", 14, 65), GetDoubleInRange("Enter the student's GPA in between 0 and 10", 0.0, 10.0));
        }
    }
}