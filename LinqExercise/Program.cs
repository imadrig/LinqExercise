using Microsoft.VisualBasic;
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

            //TODO: Print the Sum of numbers - DONE
            int sum = SumOfNumbers(numbers);
            Console.WriteLine($"The sum of the numbers is: {sum}");

            static int SumOfNumbers(int[] numbers)
            {
                return numbers.Sum();
            }

            //TODO: Print the Average of numbers - DONE
            double average = AverageOfNumbers(numbers);
            Console.WriteLine($"The average of the numbers is: {average} ");
            static double AverageOfNumbers(int[] numbers)
            {
                return numbers.Average();
            }

            //TODO: Order numbers in ascending order and print to the console - DONE
            int[] numbersAscending = OrderAscending(numbers);
            Console.WriteLine($"The numbers in ascending order: {string.Join(", " , numbersAscending)}");

            static int[] OrderAscending(int[] numbers)
            {
                int[] numbersByAscendingOrder = numbers.OrderBy(number => number).ToArray();
                return numbersByAscendingOrder;
            }

            //TODO: Order numbers in descending order and print to the console - DONE
            int[] numbersDescending = OrderDescending(numbers);
            Console.WriteLine($"The numbers in descending order: {string.Join(", ", numbersDescending)}");

            static int[] OrderDescending(int[] numbers)
            {
                int[] numbersByDescendingOrder = numbers.OrderByDescending(number => number).ToArray();
                return numbersByDescendingOrder;
                
            }

            //TODO: Print to the console only the numbers greater than 6 - DONE
            int[] numbersGreaterThan6 = NumbersGreaterThanSix(numbers);
            Console.WriteLine($"The numbers greater than 6 are: {string.Join(", ", numbersGreaterThan6)}");

            static int[] NumbersGreaterThanSix(int[] numbers)
            {
                int[] numbersGreaterThan6 = numbers.Where(number => number > 6).ToArray();
                return numbersGreaterThan6;
            }

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!** - DONE
            int[] printFourNumbers = ForeachOrderDescending(numbers);
            
            static int[] ForeachOrderDescending(int[] numbers)
            {
                int[] numbersByDescendingOrder = numbers.OrderByDescending(number => number).ToArray();
                Console.Write("Four numbers in the array are: ");

                foreach (int number in numbersByDescendingOrder.Take(4))
                {
                    Console.Write(number + ", ");
                    
                }
                return numbersByDescendingOrder;

            }
            Console.WriteLine();

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order - DONE
            int[] changeValue = ChangeValueAtIndexFour(numbers);
            Console.WriteLine($"After changing the value at index 4, the descending list is: {string.Join(", ", changeValue)}");

            static int[] ChangeValueAtIndexFour(int[] numbers)
            {
                numbers[4] = 32;
                int[] changeValueOfIndex4 = numbers.OrderByDescending(number => number).ToArray();
                return changeValueOfIndex4;
            }





                // List of employees ****Do not remove this****
                var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName. - DONE
            List<Employee> employeesList = EmployeesWithFirstNameCOrS(employees);
            Console.WriteLine($"Employees with a first name that start with 'C' or 'S': " +
                $"{string.Join(", ", employeesList.OrderBy(employee => employee.FullName).Select(employee => employee.FullName))}");

            static List<Employee> EmployeesWithFirstNameCOrS(List<Employee> employees)
            {
                
                List<Employee> employeesFirstLetterCOrS = employees.Where(employee => employee.FirstName.ToLower()[0] == 'c' || employee.FirstName.ToLower()[0] == 's').ToList();
                return employeesFirstLetterCOrS;
            }

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            List<Employee> employeesOver26 = EmployeesOverAgeTwentySix(employees);
            Console.WriteLine($"Employees over the age of 26: " +
               $"{string.Join(", ", employeesOver26.OrderBy(employee => employee.Age).ThenBy(employee => employee.FirstName).Select(employee => $"{employee.FullName} - Age: {employee.Age}"))}");

            static List<Employee> EmployeesOverAgeTwentySix(List<Employee> employees)
            {
                List<Employee> employeesOverAge26 = employees.Where(employee => employee.Age > 26).ToList();
                return employeesOverAge26;
            }


            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            List<Employee> yearsExperienceAndAgeRequirement = SumAndAverageExperience(employees);
            Console.WriteLine($"The list includes: {string.Join(", ", yearsExperienceAndAgeRequirement.Select(employee => employee.FullName))}");

            static List<Employee> SumAndAverageExperience(List<Employee> employees)
            {
                List<Employee> yearsExperienceAndAgeRequirement = employees.Where(employee => employee.YearsOfExperience <= 10 && employee.Age > 35).ToList();
                int sumOfYearsExperience = yearsExperienceAndAgeRequirement.Sum(employee => employee.YearsOfExperience);
                double avgYearsExperience = Math.Round(yearsExperienceAndAgeRequirement.Average(emloyee => emloyee.YearsOfExperience) , 2);

                Console.WriteLine($"Sum of Years of Experience if employee  YOE is less than or equal to 10 AND Age is greater than 35: {sumOfYearsExperience}");
                Console.WriteLine($"Average of Years of Experience if employee YOE is less than or equal to 10 AND Age is greater than 35: {avgYearsExperience}");
                return yearsExperienceAndAgeRequirement;    
            }

            //TODO: Add an employee to the end of the list without using employees.Add()
            Employee newEmployee = new Employee("Harry", "Potter", 21, 7);
            employees = AddEmployee(employees, newEmployee);
            Console.WriteLine($"Adding a new employee at the end: " +
                $"{string.Join(", ", employees.Select(employee => employee.FullName))}");


            static List<Employee> AddEmployee(List<Employee> employees, Employee newEmployee)
            {

                employees.Insert(employees.Count, newEmployee);
                return employees;
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
