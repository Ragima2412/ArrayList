using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedListArray
{
    abstract class Person
    {
        public string Lastname { get; set; }
        public Person(string _Lastname)
        {
            Lastname = _Lastname;
        }
        public abstract void Print();
        public int CompareTo(Person other) 
        {
            return String.Format("{0} ", Lastname).CompareTo(String.Format("{0}", other.Lastname));
             
        }
    }
    class Student : Person
    {
        public int Course { get; set; }
        public int RecordBook { get; set; }

        public Student(string _Lastname, int _Course, int _RecordBook) : base(_Lastname)
        {
            Course = _Course;
            RecordBook = _RecordBook;
        }
        public override void Print()
        {
            Console.WriteLine($"Full info about Student:\n Lastname:{Lastname} \n Course of study:{Course} \n ID Recordbook{RecordBook}");
        }

        class Aspirant : Student
        {
            public string Dissertation { get; set; }


            public Aspirant(string _Lastname, int _Course, int _Recordbook, string _Dissertation) : base(_Lastname, _Course, _Recordbook)
            {
                Dissertation = _Dissertation;
            }
            public override void Print()
            {
                Console.WriteLine($"Full info about Aspirant:\n Lastname:{Lastname} \n Course of study:{Course} \n ID Recordbook{RecordBook}" +
                    $" \n Task of Dissertation:{Dissertation}");
            }
        }
        class GroupOfStudent
        {
            public Student[] data1;
            public GroupOfStudent()
            {
                data1 = new Student[4];
            }
            public Student this[int index]
            {
                get { return data1[index]; }
                set { data1[index] = value; }
            }
            public void EntryStudents()
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine($"Enter full information for {i + 1} student");
                    string _Lastname = Program.CheckPrintLastName();
                    int _Course = Program.CheckPrintCourse();
                    int _RecordBook = Program.CheckPrintRecordB();
                    data1[i] = new Student(_Lastname, _Course, _RecordBook);
                }
            }
            public void PrintStudent()
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine($"Full information of {i + 1} students:\t Lastname: {data1[i].Lastname}\t Course:{data1[i].Course}\t " +
                        $"ID Recordbook{data1[i].RecordBook}\t Hashcode#: {data1[i].GetHashCode()}");
                }
            }
        }
        class GroupOfAspirants
        {
            public Aspirant[] data2;
            public GroupOfAspirants()
            {
                data2 = new Aspirant[4];
            }
            public Aspirant this[int index]
            {
                get { return data2[index]; }
                set { data2[index] = value; }
            }
            public void EntryAspirants()
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine($"Enter full information for {i + 1} aspirant");
                    string _Lastname = Program.CheckPrintLastName();
                    int _Course = Program.CheckPrintCourse();
                    int _RecordBook = Program.CheckPrintRecordB();
                    string _Disertation = Program.CheckPrintDissertation();
                    data2[i] = new Aspirant(_Lastname, _Course, _RecordBook, _Disertation);
                }
            }
            public void PrintAspirant()
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine($"Full information of {i + 1} aspirant:\t Lastname: {data2[i].Lastname}\t Course: {data2[i].Course}\t ID Recordbook: {data2[i].RecordBook}\t" +
                        $"Dissertation: {data2[i].Dissertation}\t HachCode#: {data2[1].GetHashCode()} ");
                }

            }
        }

        class Program
        {
            public static string CheckPrintLastName()
            {
                string str = "";
                bool IsLastName = false;
                while (!IsLastName)
                {
                    Console.WriteLine("Enter Lastname: ");
                    str = Console.ReadLine();
                    char[] chars = str.ToCharArray();
                    for (int i = 0; i < chars.Length; i++)
                    {
                        if ((chars[i] >= 'A' && chars[i] <= 'Z') || (chars[i] >= 'a' && chars[i] <= 'z'))
                        {
                            IsLastName = true;
                        }
                        else
                        {
                            IsLastName = false;
                            Console.WriteLine("You enter inccorect name");
                            break;
                        }
                    }
                }
                return str;
            }
            public static int CheckPrintCourse()
            {
                int Course = 0;
                bool IsNumber = false;
                while (!IsNumber)
                {
                    Console.WriteLine("Choose Course of Study: from 1 to 4");
                    bool result = Int32.TryParse(Console.ReadLine(), out Course);
                    if (result == false)
                    {
                        Console.WriteLine("You enter inccorect data");
                    }
                    else
                    {
                        IsNumber = true;
                    }
                }
                switch (Course)
                {
                    case 1:
                        Course = 1;
                        break;
                    case 2:
                        Course = 2;
                        break;
                    case 3:
                        Course = 3;
                        break;
                    case 4:
                        Course = 4;
                        break;
                    default:
                        Console.WriteLine("That course is not exist");
                        break;
                }
                return Course;
            }
            public static string CheckPrintDissertation()
            {
                int RecordB = 0;
                string result = "";
                bool IsNumber = false;
                while (!IsNumber)
                {
                    Console.WriteLine("Choose task of Dissertation: \n 1.Task1 \n 2.Task2 \n 3.Task3 ");
                    bool result1 = Int32.TryParse(Console.ReadLine(), out RecordB);
                    if (result1 == false)
                    {
                        Console.WriteLine("You enter inccorect data");
                    }
                    else
                    {
                        IsNumber = true;
                    }
                }
                switch (RecordB)

                {
                    case 1:
                        result = "Task1";
                        break;
                    case 2:
                        result = "Task2";
                        break;
                    case 3:
                        result = "Task3";
                        break;

                    default:
                        Console.WriteLine("That task of dissertation  is not exist");
                        break;
                }
                return result;
            }
            public static int CheckPrintRecordB()
            {
                int RecordB = 0;
                bool IsNumber = false;
                while (!IsNumber)
                {
                    Console.WriteLine("Enter ID of RecordBook:");
                    bool result1 = Int32.TryParse(Console.ReadLine(), out RecordB);
                    if (result1 == false)
                    {
                        Console.WriteLine("You enter inccorect data");
                    }
                    else
                    {
                        IsNumber = true;
                    }
                }
                while (!IsNumber)
                {
                    if (RecordB <= 99999 && RecordB >= 9999)
                    {
                        IsNumber = true;
                    }
                    Console.WriteLine("You enter incorret data");
                }
                return RecordB;
            }
            class PersonComparer : IComparer
            {

                int IComparer.Compare(Object x, Object y)
                {
                    if (x == null)
                        return (y == null) ? 0 : 1;

                    if (y == null)
                        return -1;

                    Person p1 = x as Person;
                    Person p2 = y as Person;
                    return (p1.Lastname.Length - p2.Lastname.Length);
                }
            }

                    static void Main(string[] args)
            {
                GroupOfStudent GroupStud = new GroupOfStudent();
                GroupStud.EntryStudents();
                GroupStud.PrintStudent();

                GroupOfAspirants GroupAsp = new GroupOfAspirants();
                GroupAsp.EntryAspirants();
                GroupAsp.PrintAspirant();



                ArrayList list = new ArrayList();//ArrayList
                list.AddRange(GroupStud.data1);
                list.AddRange(GroupAsp.data2);
                list.Sort(new PersonComparer());
                Console.WriteLine("Full list of study persons:");
                foreach (Person p in list)
                    Console.WriteLine(p.Lastname);               
               
                
                LinkedList<Student> students = new LinkedList<Student>();
                LinkedList<Aspirant> aspirants = new LinkedList<Aspirant>();

                foreach(var student in GroupStud.data1) 
                {
                    students.AddFirst(student);                
                }
                foreach (var aspirant in GroupAsp.data2) 
                {
                    aspirants.AddFirst(aspirant);                   
                }
                Console.WriteLine("List of Students:"); 
                foreach (var stud in students)
                {
                    Console.WriteLine(" {0}", stud.Lastname); 
                    Console.WriteLine(students.Equals(students));
                }
                Console.WriteLine("List of Aspirants:"); 
                foreach (var aspir in aspirants)
                {
                    Console.WriteLine(" {0}", aspir.Lastname);
                    Console.WriteLine(students.Equals(students));
                }
                
            }
        }

    }
}
