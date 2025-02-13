using System.Runtime.Intrinsics.X86;

namespace HSE_Lab_9
{
    public class StudentArray
    {
        private static readonly Random rnd = new Random();
        String[] firstNames = {"Liam", "Noah", "Oliver", "James", "Elijah", "Mateo", "Theodore", "Henry", "Lucas", "William", "Olivia", "Emma", "Charlotte", "Amelia", "Sophia", "Mia", "Isabella", "Ava", "Evelyn", "Luna"};
        String[] lastNames = {"Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez", "Hernandez", "Lopez", "Gonzales", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin"};

        private readonly Student[] array;
        private static int studentCount = 0;

        //конструкторы коллекции
        public StudentArray()
        {
            array = new Student[0];
            studentCount++;
        }

        public StudentArray(int length)  
        {
            array = new Student[length];
            for (int i = 0; i < length; i++)
                array[i] = new Student(
                    firstNames[rnd.Next(0, 19)] + " " + lastNames[rnd.Next(0, 19)],
                    rnd.Next(17, 24),
                    (double)rnd.Next(1, 100) / 10.0
                    );
            studentCount++;
        }

        public StudentArray(StudentArray studentArray) 
        {
            array = new Student[studentArray.GetLengthArray];
            for (int i = 0; i < studentArray.GetLengthArray; i++)
                array[i] = new Student(studentArray[i]);
            studentCount++;
        }

        //индексатор
        public Student this[int index]  
        {
            get
            {
                if (index >= 0 && index < array.Length)
                    return array[index];
                throw new IndexOutOfRangeException($"Index = {index} is out of the range of the array (0 : {array.Length-1})");
            }
            set
            {
                if (index >= 0 && index < array.Length)
                    array[index] = value;
                else
                    throw new IndexOutOfRangeException($"Index = {index} is out of the range of the array (0 : {array.Length - 1})");
            }
        }

        //методы коллекции
        public int GetLengthArray => array.Length;

        public static int GetCount => studentCount;

        public int GetOldestAvgAStudent()
        {
            if (array.Length == 0)
                throw new InvalidOperationException("The array is empty");
            int index = -1, maxAge = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].GPA > 8)
                    if (array[i].Age > maxAge)
                    {
                        maxAge = array[i].Age;
                        index = i;
                    }
            }
            return index;
        }

        public void PrintArray()
        {
            if (array.Length == 0)
            {
                Console.WriteLine("The array is empty");
                return;
            }
            for (int i = 0; i < array.Length; i++)
                Console.WriteLine(array[i]);
        }

        //сравнение для UnitTest
        public override bool Equals(object? obj)
        {
            if (obj is not StudentArray otherarray)
                return false;
            if (GetLengthArray != otherarray.GetLengthArray)
                return false;
            for (int i = 0; i < GetLengthArray; i++)
                if (!array[i].Equals(otherarray[i]))
                    return false;
            return true;
        }
    }
}

