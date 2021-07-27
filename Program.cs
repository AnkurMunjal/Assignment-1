using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp3
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class Student
    {
        int id;
        string name;
        string date;
        public static string collegeName="IIIT";
        //private string[] phoneNumber;
        public phonenumber;
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Date { get => date; set => date = value; }
        //public string[] PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        //static Student()
        //{
        //    CollegeName = "IIIT";
        //}

        public Student()
        {

        }

        public Student(int id, string name, string date,String PhoneNumber)
        {
            this.id = id;
            this.name = name;
            this.date = date;
            this.PhoneNumber = PhoneNumber;
        }

    }

    public class Info
    {
    
        public void display(Student student)
        {
            Console.WriteLine(student.Id);
            Console.WriteLine(student.Name);
            Console.WriteLine(student.Date);
            foreach(string p in student.PhoneNumber)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine(Student.collegeName);


        }

        public void display(Course course)
        {
            Console.WriteLine(course.Id);
            Console.WriteLine(course.Name);
            Console.WriteLine(course.Duration);
            course.calculateMonthlyFee();
            Console.WriteLine(course.Fees);
        }

        public void display(Enroll enroll)
        {
            display(enroll.Student);
            display(enroll.Course);
            Console.WriteLine("Date :" + enroll.EnrollmentDate);

        }
    }
    public abstract class Course
    {
        int id;
        string name;
        int duration;
        int fees;

        public Course(int id, string name, int duration, int fees)
        {
            this.id = id;
            this.name = name;
            this.duration = duration;
            this.fees = fees;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Duration { get => duration; set => duration = value; }
        public int Fees { get => fees; set => fees = value; }

        public abstract void calculateMonthlyFee();

    }
    public class DegreeCourse : Course
    {
        enum Level
        {
            Bachelors,
            Masters
        }

        Boolean isPlacementAvailable;

        public DegreeCourse(int id, string name, int duration, int fees, Boolean isPlacementAvailable) : base(id, name, duration, fees)
        {
            this.IsPlacementAvailable = isPlacementAvailable;
            

        }

        public bool IsPlacementAvailable { get => isPlacementAvailable; set => isPlacementAvailable = value; }


        public override void calculateMonthlyFee()
        {
            if (isPlacementAvailable)
                Console.WriteLine(Fees + (Fees / 10));
            else
                Console.WriteLine(Fees);
        }
    }

    
    public class DiplomaCourse : Course
    {
        enum Type
        {
            Professional,
            Acadmeic
        }

        public DiplomaCourse(int id, string name, int duration, int fees) : base(id, name, duration, fees)
        {


        }

        public override void calculateMonthlyFee()
        {
            Console.WriteLine("Choose the course type. Professional or academic");
            string t = Console.ReadLine();
            if (t==Type.Professional.ToString())
                Console.WriteLine(Fees + (Fees / 10));
            else
                Console.WriteLine(Fees + (Fees / 20));
        }
    }

    

    public class Enroll
    {
        private Student student;
        private Course course;
        private DateTime enrollmentDate;

        public Enroll(Student student, Course course, DateTime enrollmentDate)
        {
            this.student = student;
            this.course = course;
            this.EnrollmentDate = enrollmentDate;
        }

        public Student Student { get => student; set => student = value; }
        public Course Course { get => course; set => course = value; }
        public DateTime EnrollmentDate { get => enrollmentDate; set => enrollmentDate = value; }
    }



    public interface AppEngine
    {

        public void introduce(Course course);
        public void register(Student student);
        public List<Student> listOfStudents();
        public void enroll(Student student, Course course);
        public List<Enroll> listOfEnrollments();
    }

    public class InMemoryAppEngine : AppEngine
    {
        List<Student> StudentList = new List<Student>();
        List<Course> CourseList = new List<Course>();
        List<Enroll> EnrollList = new List<Enroll>();
        public void introduce(Course course)
        {
            //course.Id = Convert.ToInt32(Console.ReadLine());
            //course.Name = Console.ReadLine();
            //course.Duration = Convert.ToInt32(Console.ReadLine());
            //course.Fees = Convert.ToInt32(Console.ReadLine());

            CourseList.Add(course);
        }
        public virtual void register(Student student)
        {
            //student.Id = Convert.ToInt32(Console.ReadLine());
            //student.Name = Console.ReadLine();
            //student.Date = Console.ReadLine();
            //student.PhoneNumber = new string[] { Console.ReadLine() };

            StudentList.Add(student);
        }
        
        public List<Student> listOfStudents()
        {
            return StudentList;
        }
        public void enroll(Student student, Course course)
        {
            DateTime d = DateTime.Today;
            Enroll e1 = new Enroll(student, course, d);
            try
            {
                if (CourseList.Count > 1 || EnrollList.Contains(e1))
                {
                    throw new EnrollmentException("No new registrations in this course allowed");
                }
                EnrollList.Add(e1);
            }
            catch (EnrollmentException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public List<Enroll> listOfEnrollments()
        {

            return EnrollList;
        }
    }

        public class App
    {
        Info inf = new Info();
        public void scenario1()
        {
            //Info inf = new Info();

            Student s2 = new Student(1, "Roy", "10-12-1990", new string[] { "9856383" });
            Student s3 = new Student(2, "Roy", "10-12-1990", new string[] { "9856383" });
            Student s4 = new Student(3, "Roy", "10-12-1990", new string[] { "9856383" });
            Student s5 = new Student(4, "Roy", "10-12-1990", new string[] { "9856383" });


            inf.display(s2);
        }

        public void scenario2()
        {

            Student s2 = new Student(1, "Roy", "10-12-1990", new string[] { "9856383" });
            Student s3 = new Student(2, "Roy", "10-12-1990", new string[] { "9856383" });
            Student s4 = new Student(3, "Roy", "10-12-1990", new string[] { "9856383" });
            Student s5 = new Student(4, "Roy", "10-12-1990", new string[] { "9856383" });
            Student[] arrStudents = new Student[] { s2,s3,s4,s5 };

            foreach(Student s in arrStudents)
            {
                inf.display(s);
            }
        }
        public void scenario3()
        {
            int count = Convert.ToInt32(Console.ReadLine());
            Student[] StudentArray = new Student[count]; 
            for(int i=0;i<count;i++)
            {
                Student s = new Student();
                s.Id = Convert.ToInt32(Console.ReadLine());
                s.Name = Console.ReadLine();
                s.Date = Console.ReadLine();
                s.PhoneNumber = new string[] { Console.ReadLine() };
                StudentArray[i] = s;

            }
            foreach(Student s in StudentArray)
            {
                inf.display(s);
            }

        }

        public void scenario4()
        {
            int count = Convert.ToInt32(Console.ReadLine());
            ArrayList StudentArray = new ArrayList();
            for (int i = 0; i < count; i++)
            {
                Student s = new Student();
                s.Id = Convert.ToInt32(Console.ReadLine());
                s.Name = Console.ReadLine();
                s.Date = Console.ReadLine();
                s.PhoneNumber = new string[Convert.ToInt32(Console.ReadLine())];
                for(int j=0;j<s.PhoneNumber.Length;j++)
                {
                    s.PhoneNumber[j] = Console.ReadLine();
                }
                StudentArray.Add(s);

            }
            foreach (Student s in StudentArray)
            {
                inf.display(s);
            }

        }

        

        public static void Main(String[] args)
        {
            App ap = new App();
            //ap.scenario1();
            //ap.scenario2();
            //ap.scenario3();
            //ap.scenario4();
            //Info info = new Info();
            //Course c = new DegreeCourse(1,"asfgs",6,10000,true);
            ////info.display(c);
            //Course c1 = new DegreeCourse(2, "asfgs", 5, 90000, true);
            ////info.display(c1);
            //Student s2 = new Student(1, "Roy", "10-12-1990", new string[] { "9856383" });
            //Student s3 = new Student(2, "Roy", "10-12-1990", new string[] { "9856383" });
            //AppEngine obj = new InMemoryAppEngine();
            //obj.introduce(c);
            //obj.enroll(s2,c);
            //obj.introduce(c1);
            //obj.enroll(s3,c1);

            InMemoryAppEngine obj = new PersistentAppEngine();
            Student s = new Student(1, "JHON", "23-04-21", new string [] { "900896744"});
            obj.register(s);



        }

        


    }
    class EnrollmentException : Exception
    {
        public EnrollmentException(string message) : base(message)
        {

        }
    }
    class PersistentAppEngine : InMemoryAppEngine
    {

        public PersistentAppEngine()
        {

        }
        public override void register(Student student)
        {
            //int id = student.Id;
            //string name = student.Name;
            //string date = student.Date;
            //string[] phonenumber = student.PhoneNumber;

            //Console.WriteLine("Enter the id , name , date, phonenumber");

            //id = Convert.ToInt32(Console.ReadLine());

            //name = Console.ReadLine();

            //date = Console.ReadLine();

            //phonenumber = Console.ReadLine();

            string constr = @"Data Source=DESKTOP-AK777FG\MSSQL;database=MyfirstDB;Integrated Security=true;";

            using (SqlConnection con = new SqlConnection(constr))

            {

                con.Open();

                SqlCommand cmd = new SqlCommand("sp_Addstud", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", student.Id);
                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@date", student.Date);
                cmd.Parameters.AddWithValue("@CollegeName", Student.collegeName);
                cmd.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);


                int result = cmd.ExecuteNonQuery();

                if (result > 0)

                    Console.WriteLine("Inserted Successfully");

                else

                    Console.WriteLine("Inserted Failed");

                con.Close();

            }
        }
    }




}
