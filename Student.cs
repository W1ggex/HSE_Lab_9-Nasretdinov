namespace HSE_Lab_9
{
    public class Student
    {
            //поля
            string name; 
            int age;   
            double gpa;  
            static int total_students;
            private Student student;
            
            //свойства
            public string Name  
        {
            get => name;

            set
            {
                if (value.Length <= 60)
                    name = value;
                else
                    name = "John Doe";
            }
        }

            public int Age  
            {
                get => age; 

                set
                {
                if (value <= 17)
                    age = 17;
                else
                    age = value;       
            }
            }

            public double GPA
            {
            get => gpa;
            set 
            {
                if(value < 0 || value > 10)
                    gpa = 0.0;
                else
                    gpa = value;
            }
            }

            public static int Total_students
            {
                get => total_students;
                //set отсутствует - устанавливать значение нельзя, только получать
            }

            //методы
            public Student()  
            {
                Name = "John Doe";
                Age = 18;  
                GPA = 5;
                total_students++; 
            }

            public Student(string n, int a, double g)
            {
                Name = n;
                Age = a;
                GPA = g;
                total_students++;
            }

            public Student(Student student)
        {
            this.Name = student.Name;
            this.Age = student.Age;
            this.GPA = student.GPA;
            total_students++;
        }

            public string GetStudentInfo()
            {
            return ($"{Name} is {Age} years old with the GPA of {GPA}");
            }

            public int GetCount()
            {
                return total_students;
            }

            public static string GetTotalStudentAmount()
            {
                return $"{total_students} total students were initialized";
            }

            public string CompareGPA(Student otherStudent)
            {
            if (Age < otherStudent.Age)
                return $"{Name} младше {otherStudent.Name}";
            else if (Age > otherStudent.Age)
                return $"{Name} старше {otherStudent.Name}";
            else
                return $"{Name} ровесник {otherStudent.Name}";
        }

            public static string CompareAge(Student s1, Student s2) 
            {
                if (s1.GPA < s2.GPA)
                    return $"GPA {s1.Name} ниже GPA {s2.Name}";
                else if (s1.GPA > s2.GPA)
                    return $"GPA {s1.Name} выше GPA {s2.Name}";
                else
                    return $"GPA {s1.Name} равен GPA {s2.Name}";
        }

            //унарные операции
            public static Student operator ~(Student s)
            {
                string newName = "";
                for(int i = 0; i < s.Name.Length; i++)
            {
                char c = s.Name[i];
                if(i == 0 || s.Name[i-1].Equals(' '))
                    newName += c.ToString().ToUpper();
                else
                    newName += c.ToString().ToLower();
            }
                s.Name = newName;
            return new(newName, s.Age, s.GPA);
            }

            public static Student operator ++(Student s)
        {
            int newAge = s.Age + 1;
            return new(s.Name, newAge, s.GPA);
        }

            //преобразования
            public static implicit operator bool (Student s)
            {
            return s.GPA < 6;
            }

            public static explicit operator int (Student s)
            {
            int year = -1;
            if (s.Age > 17 && s.Age < 24)
                year = s.Age - 17;
            return year;
            }

            //бинарные операции
            public static Student operator %(Student s1, string newName)
        {
            return new(newName, s1.Age, s1.GPA);
        }

            public static Student operator -(Student s1, double d)
            {
            if (s1.GPA < d)
                return s1;
            else
                return new(s1.Name, s1.Age, (s1.GPA - d));
            }   
    }
}
