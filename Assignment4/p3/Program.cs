using System;

namespace p3
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee("Rushita", "Banker", 75000);
            Employee e2 = new Employee("Aishwarya", "Mundley", 80000);

            Console.WriteLine("Before Increment...");
            Console.WriteLine(e1.ToString());
            Console.WriteLine(e2.ToString());

            Console.WriteLine("After Increment...");
            e1.giveRaise(10.0);
            e2.giveRaise(10.0);

            Console.WriteLine(e1.ToString());
            Console.WriteLine(e2.ToString());


            Console.WriteLine("*******Permanent Employee********");

            PermanentEmployee p1 = new PermanentEmployee("Harsh", "Solanki", 65000, 2750, 700, 7500, "01-01-2022", "07-07-2023");

            PermanentEmployee p2 = new PermanentEmployee("Jay", "Shah", 70000, 2573, 1500, 6500, "08-02-2022", "18-06-2023");

            Console.WriteLine("Before Increment...");

            Console.WriteLine(p1);
            Console.WriteLine(p2);

            p1.giveRaise(10.0);
            p2.giveRaise(10.0);

            Console.WriteLine("After Increment...");

            Console.WriteLine(p1.ToString());
            Console.WriteLine(p2.ToString());
        }
    }

    public class Employee
    {

        private String _firstName;
        private String _lastName;
        private double _monSalary;

        public Employee(String first, String last, double sal)
        {
            _firstName = first;
            _lastName = last;
            _monSalary = sal;
        }

        public String First
        {
            get => _firstName;
            set => _firstName = value;
        }

        public String Last
        {
            get => _lastName;
            set => _lastName = value;
        }

        public double MonSalary
        {
            get => _monSalary;
            set
            {
                if (value < 0.0)
                {
                    _monSalary = 0.0;
                }
                else
                {
                    _monSalary = value;
                }
            }

        }

        public virtual void giveRaise(double inc)
        {
            _monSalary = _monSalary + (_monSalary * inc / 100);
        }

        public override string ToString()
        {
            return "Employee Details : " + _firstName + " " + _lastName + " Yearly Salary : " + (_monSalary) * 12;
        }
    }

    public class PermanentEmployee : Employee
    {

        private double _hra;
        private double _da;
        private double _pf;
        private String _joiningDate;
        private String _retirementDate;

        public PermanentEmployee(String first, String last, double sal, double hra, double da, double pf, String joiningDate, String retirementDate) : base(first, last, sal)
        {
            this._hra = hra;
            this._da = da;
            this._pf = pf;
            this._joiningDate = joiningDate;
            this._retirementDate = retirementDate;
            this.MonSalary = this.MonSalary + _hra + _da;
        }

        public double Hra
        {
            get => _hra;
        }

        public double Da
        {
            get => _da;
        }

        public double Pf
        {
            get => _pf;
        }

        public String JoiningDate
        {
            get => _joiningDate;
            set => _joiningDate = value;
        }

        public String RetirementDate
        {
            get => _retirementDate;
            set => _retirementDate = value;
        }

        public override void giveRaise(double inc)
        {
            this.MonSalary = this.MonSalary + (this.MonSalary * inc) / 100 + _da + _hra;
        }

        public override string ToString()
        {
            return "Permanent Employee Details : " + this.First + " " + this.Last + " Joining Date : " + _joiningDate + " Retirement Date : " + _retirementDate + " Yearly Salary : " + (this.MonSalary) * 12;
        }
    }
}
