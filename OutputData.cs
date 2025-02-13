

using static System.Net.Mime.MediaTypeNames;

namespace HSE_Lab_9
{
    public class OutputData
    {
        //Работа с единичными экземплярами
        public static void PrintStudentInfo(Student s)
        {
            Console.WriteLine(s.GetStudentInfo());
        }

        public static void PrintAgeComparison(Student s1, Student s2)
        {
            Console.WriteLine(Student.CompareAge(s1, s2));
        }

        public static void PrintGPAComparison(Student s1, Student s2)
        {
            Console.WriteLine(s1.CompareGPA(s2));
        }

        public static void PrintStudentWithFormattedName(Student s)
        {
            PrintStudentInfo(~s);
        }

        public static void PrintAgedStudent(Student s)
        {
            PrintStudentInfo(++s);
        }

        public static void PrintStudentsCollegeYear(Student s)
        {
            Console.WriteLine($"The student is supposed to study in the {(int)s}{InputData.NumerableEnding((int)s)} year of University");
        }

        public static void PrintIfStudentHasGPABelow6(Student s)
        {
            bool gpaIsBelow6 = s;
            Console.WriteLine("Student has the below 6 GPA: " + gpaIsBelow6);
        }

        public static void PrintTotalStudentCount()
        {
            Console.WriteLine(Student.GetTotalStudentAmount());
        }

        //Работа с экземплярами коллекций
        public static void PrintArray(StudentArray array)
        {
            if (array.GetLengthArray == 0)
            {
                Console.WriteLine("The array is empty");
                return;
            }
            for (int i = 0; i < array.GetLengthArray; i++)
                PrintStudentInfo(array[i]);
        }

        public static void PrintOldestAvgAStudent(StudentArray array)
        {
            int index = array.GetOldestAvgAStudent();
            if (index == -1)
                Console.WriteLine("There are no students with GPA over 8");
            else
                Console.WriteLine($"{array[index].Name} is the oldest student ({array[index].Age}) with GPA over 8 ({array[index].GPA})");
        }

        public static void PrintTotalStudentArrayCount()
        {
            Console.WriteLine($"{StudentArray.GetCount} student array(s) has(ve) been initialized");
        }

    }
}
