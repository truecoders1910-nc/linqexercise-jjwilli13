using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };


        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            foreach (var num in numbers)
            {
                numbers.Sum();
                numbers.Average();
            }
            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers.Average());


            //Order numbers in ascending order and decsending order. Print each to console.

            //Asceding Order
            var nums = from num in numbers
                       orderby num ascending
                       select num;
            foreach (var n in nums)
            {
                Console.WriteLine(n);
            }

            //Descending Order
            var nums1 = from num in numbers
                        orderby num descending
                        select num;
            foreach (var n in nums1)
            {
                Console.WriteLine(n);
            }


            //Print to the console only the numbers greater than 6

            var nums2 = from num in numbers
                       where num > 6
                       select num;
            foreach (var n in nums2)
            {
                Console.WriteLine(n);
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            var nums3 = from num in numbers
                       where num <= 3
                       orderby num descending
                       select num;
            foreach (var n in nums3)
            {
                Console.WriteLine(n);
            }

            //Change the value at index 4 to your age, then print the numbers in decsending order

            var nums5 = from num in numbers
                       orderby num descending
                       select num;
            numbers[4] = 29;


            foreach (var n in nums5)
            {
                Console.WriteLine(n);

            }



            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.


            var FirstName = employees.OrderBy(x => x.FirstName).Where(names => employees.Any(name => names.FirstName.StartsWith("S") || names.FirstName.StartsWith("C")));


            foreach (var person in FirstName)
            {
                Console.WriteLine(person.FullName);
            }


            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.

            var NameAge = employees.OrderBy(x => x.Age).ThenBy(x => x.FirstName).Where(ageName => employees.Any(ageNames => ageName.Age > 26));

            foreach (var item in NameAge)
            {
                Console.WriteLine(item.Age + " " + item.FullName);
            }


            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35

            Console.WriteLine(employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Sum(x => x.YearsOfExperience));
            Console.WriteLine(employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Average(x => x.YearsOfExperience));


            //Add an employee to the end of the list without using employees.Add()
            Employee emp = new Employee("Jordan", "Williams", 29, 5);
            List<Employee> newEmployee = employees.Append(emp).ToList();

            foreach (var item in newEmployee)
            {
                Console.WriteLine($"{item.FullName} {item.Age} {item.YearsOfExperience}");
            }


            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion




    }



}
