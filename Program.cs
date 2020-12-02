using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAssignment
{
    class Employee
    {
        String name;
        static int empNo;
        decimal basic;
        short deptNo;

        public Employee(String name, decimal basic, short deptNo)
        {
            this.name = name;
            empNo++;
            this.basic = basic;
            this.deptNo = deptNo;
        }
        public Employee(String name, decimal basic)
        {
            this.name = name;
            empNo++;
            this.basic = basic;
        }
        public Employee(String name)
        {
            this.name = name;
            empNo++;
        }
        public String Name
        {
            set
            {
                if (value != "")
                    name = value;
                else
                    Console.WriteLine("Name cannot be blank");
            }
            get
            {
                return name;
            }
        }
        public static int EMPNO
        {
            get
            {
                return empNo;
            }
        }
        public decimal BASIC
        {
            set
            {
                if (value >= 100000 && value <= 1000000)
                    basic = value;
                else
                    Console.WriteLine("Out of range");
            }
            get
            {
                return basic;
            }
        }
        public short DEPTNO
        {
            set
            {
                if (value > 0)
                    deptNo = value;
                else
                    Console.WriteLine("Deptno greater than zero");
            }
            get
            {
                return deptNo;
            }
        }
        public decimal GETNETSAL()
        {
            return 12 * basic;
        }

    }
    public class MainMethod
    {
        static void Main()
        {
            Employee emp1 = new Employee("Ram", 123456, 10);
            Console.WriteLine(Employee.EMPNO + "\t" + emp1.Name + "\t" + emp1.BASIC + "\t" +emp1.DEPTNO+"\t"+ emp1.GETNETSAL());
            Employee emp2 = new Employee("Shyam", 123456);
            Console.WriteLine(Employee.EMPNO + "\t" + emp2.Name + "\t" + emp2.BASIC + "\t" + emp2.GETNETSAL());

            Console.ReadLine();
        }
    }
}
