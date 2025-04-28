using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture11_Demo_5_6
{
    internal class Program
    {
        //demo 5
        public struct Student
        {
            public int StudentId;
            public string FirstName;
            public string LastName;

            public Student(int studentId, string firstName, string lastName)
            {
                StudentId = studentId;
                FirstName = firstName;
                LastName = lastName;
            }
            public string ToString()
            {
                return $"Student Id: {StudentId}, Name: {FirstName} {LastName}";
            }
        }
        //demo 5
        static void Main(string[] args)
        {
            //demo 5
            List<Student> list = new List<Student>();
            list.Add(new Student(5, "Matt", "Baira"));
            list.Add(new Student(6, "John", "Moree"));
            list.Add(new Student(3, "Travis", "che"));
            list.Add(new Student(4, "Nico", "Sarneli"));
            list.Add(new Student(7, "Justin", "Wal"));
            list.Add(new Student(8, "Maria", "lamber"));
            list.Add(new Student(1, "Siena", "Baira"));
            list.Add(new Student(2, "Alessandra", "Rota"));
            
  
            Console.WriteLine("Students before sorting");
            Console.WriteLine("--------------------------");
            foreach(Student st in list)
            {
                Console.WriteLine(st.ToString());
            }
            list.Sort(CompareStudents);
            
            Console.WriteLine("\nStudents after sorting");
            Console.WriteLine("--------------------------");
            foreach (Student st in list)
            {
                Console.WriteLine(st.ToString());
            }
            Console.ReadLine();
            //demo 5

            //demo 6
            List<int> listdemo6 = new List<int>() {5,26,12,56,13,19,1,93};
            List<int> newlistdemo6 = new List<int>();
            Console.WriteLine("\nDemo 6\n");
            Console.WriteLine("Inital List: ");
            foreach (int value in listdemo6)
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine("\n");

            //filerting the list 
            Console.WriteLine("New List: ");
            newlistdemo6 = listdemo6.FindAll(BigOddvalues);
            foreach (int value in newlistdemo6)
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine("\n");
            Console.Read();
            //demo 6

        }
        //demo 5
        static private int CompareStudents(Student student1, Student student2)
        {
            return student2.StudentId.CompareTo(student1.StudentId);
        }
        //demo 5


        //Demo 6
        //the predicate method below has a parameter an
        //interger value. it returns true if the parameter is
        // an odd value > 10 
        static private bool BigOddvalues(int value)
        {
            return (value % 2 != 0 && value < 10);
        }
        //Demo 6
    }
}
