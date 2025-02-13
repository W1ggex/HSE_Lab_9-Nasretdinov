using System.Security.Cryptography.X509Certificates;

namespace HSE_Lab_9
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            //Часть 1
            Console.WriteLine("Часть 1");
            Student s1 = new Student();   //значения по умолчанию
            Student s2 = new Student("Victor Saltykov", 21, 8.9);  //явное присваивание атрибутов
            Student s3 = new Student(s2);  //глубокая копия
            s3.Name = "Sergey Romanov";

            OutputData.PrintStudentInfo(s1);
            OutputData.PrintStudentInfo(s2);
            OutputData.PrintStudentInfo(s3);
            OutputData.PrintTotalStudentCount();

            Console.WriteLine("\nСравнения возраста и GPA");
            Student custom1 = InputData.GetStudentInfo();
            OutputData.PrintStudentInfo(custom1);
            Console.WriteLine();
            Student custom2 = InputData.GetStudentInfo();
            OutputData.PrintStudentInfo(custom2);

            Console.WriteLine();
            OutputData.PrintGPAComparison(custom1, custom2); //Сравнение GPA методом класса
            OutputData.PrintAgeComparison(custom1, custom2);  //Сравнение возраста статической функцией

            //Часть 2
            Console.WriteLine("\nЧасть 2");
            Console.WriteLine("Операции над экземпляром класса");
            Student custom3 = InputData.GetStudentInfo();
            OutputData.PrintStudentInfo(custom3);

            Console.WriteLine("\nУнарные операции");
            Console.WriteLine("Форматирование имени, увеличиение возраста на год, расчёт курса");
            OutputData.PrintStudentWithFormattedName(custom3);
            OutputData.PrintAgedStudent(custom3);
            OutputData.PrintIfStudentHasGPABelow6(custom3);
            OutputData.PrintStudentsCollegeYear(custom3);

            Console.WriteLine("\nБинарные операции");
            Console.WriteLine("Изменение имени, уменьшение GPA");
            custom3 = custom3 % InputData.GetString("Enter a new name for the student");
            OutputData.PrintStudentInfo(custom3);
            custom3 = custom3 - InputData.GetDoubleInRange($"Enter how much to decrase student's GPA for (not more than {custom3.GPA})", 0.0, custom3.GPA);
            OutputData.PrintStudentInfo(custom3);

            //Часть 3
            Console.WriteLine("\nЧасть 3");
            StudentArray array1 = new StudentArray();
            StudentArray array2 = new StudentArray(3);
            StudentArray array3 = new StudentArray(array2);
            array2[0].Name = "Original Array";

            Console.WriteLine("Пустой массив");
            OutputData.PrintArray(array1);
            Console.WriteLine("\nСлучайный массив");
            OutputData.PrintArray(array2);
            Console.WriteLine("\nСкопированный массив");
            OutputData.PrintArray(array3);
            Console.WriteLine("\nРучное заполнение массива");
            //StudentArray customArray = InputData.FillArray(InputData.GetIntInRange("Enter the array length between 1 and 20", 1, 20));
            StudentArray customArray = InputData.FillArray(2);
            OutputData.PrintArray(customArray);
            OutputData.PrintTotalStudentArrayCount();

            Console.WriteLine("\nДемонстрация работы исключений индексатора");
            try
            {
                StudentArray array4 = new StudentArray(2);
                OutputData.PrintArray(array4);
                Console.WriteLine("\nОбращения через индексатор к элементам 0 и 2");
                OutputData.PrintStudentInfo(array4[0]);
                OutputData.PrintStudentInfo(array4[2]);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.WriteLine("\nПоиск старшего ученика с GPA больше 8");
            StudentArray array5 = new StudentArray(3);
            array5[0] = new Student("A", 25, 7.9);
            array5[1] = new Student("B", 23, 8.1);
            array5[2] = new Student("C", 21, 8.5);
            OutputData.PrintArray(array5);
            OutputData.PrintOldestAvgAStudent(array5);

            Console.WriteLine("\nВ массиве нет такого ученика");
            StudentArray array6 = new StudentArray(1);
            array6[0] = new Student("D", 25, 7.9);
            OutputData.PrintArray(array6);
            OutputData.PrintOldestAvgAStudent(array6);
        }


    }
}
