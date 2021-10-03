using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum Menu { Login = 1, Register = 2 } // ใช้ตอนเลือกเมนู

namespace SoF_ckingSh_tExam2
{
    class Program
    {

        static void Main(string[] args)
        {    MainMenu();   }
        static void MainMenu()
        {   Console.WriteLine("Welcome to Digital Library");
            Console.WriteLine("------------------------------");
            Console.WriteLine("[1] Login");
            Console.WriteLine("[2] Register");
            Console.Write("Select Menu : ");
            Menu mn = (Menu)(int.Parse(Console.ReadLine()));
            Register();    }
        //เงื่อนไขตอนที่เลือกเมนู 

        static void selectmenu(Menu mn)
        {
            if (mn == Menu.Login)
            {
                ShowYourInputLogin();
            }
            else if (mn == Menu.Register)
            {   Register();    }
            else
            {
                ShowYourInCorrectMassage(); //เมื่อกดผิดจะวนซ้ำจนกว่าจะกรอกถูกตามเมนู  
            }
        }
        //ตัวเมนูกับการเลือกเมนู

        static void ShowYourInputLogin()
        {   Console.Clear();
            PrintLoginScreen();   }

        static void PrintLoginScreen()
        {   Console.WriteLine("Login Screen");
            Console.WriteLine("-------------");
            InputYourName();
            InputYourPassword();    }

        static void ShowYourInCorrectMassage()
        {
            Console.Clear();
            Console.WriteLine("Menu is Incorrect Please try again");
            MainMenu(); //ใช้ในการวนเมนูซ้ำ
        }

        static void Register()
        {   Console.WriteLine("Register new Person");
            Console.WriteLine("-----------------------");
            Inputyourtype();    }

        static string Inputyourtype()
            {   Console.Write("Input name : ");//พิมพ์ชื่อ
                string name = Console.ReadLine();
                Console.Write("Input password : ");
                int pw = int.Parse(Console.ReadLine());//พิมพ์รหัสผ่าน
                Console.Write("Input type : ");
                int t = int.Parse(Console.ReadLine());
                //เงื่อนไขในการเลือก
                if (t == 1)
            {   informationStudent();
                Console.Clear();
                Student student = creatnewstudent();
                Program.personlist.AddPerson(student);
                MainMenu();   }
            else if (t == 2)
            {   informationEmployee();
                Console.Clear();
                Employee employee = creatnewemployee();
                Program.personlist.AddPerson(employee);
                MainMenu();   }
            return Console.ReadLine();   }
            //ระบุว่าเป็น Type Student กับ Type Employee


            static PersonList personlist;
        static void PreparePersonListWhenLoading()
        {    Program.personlist = new PersonList();   }
        static Student creatnewstudent()
        {   return new Student(InputYourName(), InputYourPassword(), Inputyourtype(), informationStudent());   }
        static string InputYourName()
        {   Console.Write("Input Name: ");
            return Console.ReadLine();   }//ใส่ชื่อ

        static string InputYourPassword()
        {   Console.Write("Input Password : ");
            return Console.ReadLine();   }//ใส่รหัส

        static string informationStudent()
        {   Console.Write("StudentID : ");
            return Console.ReadLine();   }//ใส่เลขรหัสนักเรียน Stu ID
        static Employee creatnewemployee()//ใส่ข้อมูลของพนักงาน
        {   return new Employee(InputYourName(), InputYourPassword(), Inputyourtype(), informationEmployee());    }
        static string informationEmployee()
        {   Console.Write("EmployeeID : ");
            return Console.ReadLine();    }//ใส่รหัสพนักงาน


        //ข้อมูลที่กรอกจะเข้ามาอยู่ในคลาสที่สร้าง
    }
    class Person  //รายชื่อบุคทั่วไป
    {   public string name;
        public string password;
        public string type;
        public Person(String valuename, String valuepassword, string valuetype)
        {   name = valuename;   password = valuepassword;   type = valuetype;    }    }

    class Student : Person //รายชื่อนักเรียน
    {   public string name;
        public string password;
        public string StudentID;
        public string type;
        public Student(String valuename, String valuepassword, String valueStudentID, string valuetype) : base(valuename, valuepassword, valuetype)
        {    name = valuename;    password = valuepassword;   StudentID = valueStudentID;   type = valuetype;    }   }

    class Employee : Person //รายชื่อพนักงาน
    {   public string name;
        public string password;
        public string EmployeeID;
        public string type;
        public Employee(String valuename, String valuepassword, String valueEmployeeID, string valuetype) : base(valuename, valuepassword, valuetype)
        {   name = valuename;   password = valuepassword;   EmployeeID = valueEmployeeID;   type = valuetype;   }
    }

    class PersonList//รายชื่อบุคคล
    {   private List<Person> personLists;

        public PersonList()
        {       this.personLists = new List<Person>();   }
        public void AddPerson(Person person)
        {   this.personLists.Add(person);   }   }
    //RIP TwT Dead for Code ... ของ่ายๆหน่อยฮะ
}