using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFileIO
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Employee> EmployeeList = ReadDataFile();

            ///////////////////////
            foreach (Employee Emp in EmployeeList)
            {
                // Console.WriteLine(Emp.Name1 + "=>" + Emp.Salary1);              //3 ways to print to console
                //Console.WriteLine($"Name: {Emp.Name1}, Salary:${Emp.Salary1}");
                Console.WriteLine("Name: {0}, Salary: {1}", Emp.Name1, Emp.Salary1);
            }
            WriteToDataFile("Q","100000");

        }

        private static void WriteToDataFile(string Name, string salary)
        {
            StreamWriter writer = new StreamWriter("../../DataFile.txt", true);
            writer.Write($"\n{Name},{salary}");
            writer.Close();
        }

        private static List<Employee> ReadDataFile()
        {
            List<Employee> EmployeeList = new List<Employee>();
            string filelocation = "../../DataFile.txt";

            StreamReader reader = new StreamReader(filelocation);

            //Console.WriteLine(reader.ReadToEnd());

            string Data = reader.ReadToEnd().Trim().Trim('\n');
            string[] Records = Data.Split('\n');

            foreach (string record in Records)
            {
                string[] rc = record.Split(',');
                EmployeeList.Add(new Employee(rc[0],float.Parse(rc[1])));
            }
            reader.Close();

            return EmployeeList;
        }
    }
}
