using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Solid_Principles
{
    internal class LiskovSubstitution
    {
        public LiskovSubstitution()
        {
            Console.WriteLine("It states that an object of a child class must be able to replace an object of a parent class " +
                "without breaking the applicaiton");

            Employee permEmp = new PermanentEmployee("Tanveer", 1);
            Employee contEmp = new PermanentEmployee("Kiani", 2);

            permEmp.CalculateSalary();
            permEmp.CalculateBonus();

            contEmp.CalculateBonus();
            contEmp.CalculateBonus();
        }
    }

    public interface IEmployeeBonus
    {
        decimal CalculateBonus();
    }

    public interface IEmployee
    {
        int Id { get; set; }
        string Name { get; set; }
        decimal CalculateSalary();
    }

    public abstract class Employee : IEmployee, IEmployeeBonus
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public Employee(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public abstract decimal CalculateBonus();
        public abstract decimal CalculateSalary();

    }

    public class PermanentEmployee : Employee
    {
        public PermanentEmployee(string name, int id) : base(name, id)
        {
        }
        public override decimal CalculateSalary()
        {
            return 120000;
        }

        public override decimal CalculateBonus()
        {
            return 15000;
        }
    }

    public class ContractEmployee : IEmployee
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public ContractEmployee(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public decimal CalculateSalary()
        {
            return 90000;
        }
        
    }
}
