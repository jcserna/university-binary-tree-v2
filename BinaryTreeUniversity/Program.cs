using System;

namespace BinaryTreeUniversity
{
    class Program
    {
        static void Main(string[] args)
        {
            //Imagen 1
            Position rectorPosition = new Position();
            rectorPosition.Name = "Rector";
            rectorPosition.Salary = 1000;
            rectorPosition.tax = 30;   //30%

            Position vicFinPosition = new Position();
            vicFinPosition.Name = "Vicerrector Financiero";
            vicFinPosition.Salary = 750;
            vicFinPosition.tax = 28;

            Position contadorPosition = new Position();
            contadorPosition.Name = "Contador";
            contadorPosition.Salary = 500;
            contadorPosition.tax = 26;

            Position jefeFinPosition = new Position();
            jefeFinPosition.Name = "Jefe Financiero";
            jefeFinPosition.Salary = 610;
            jefeFinPosition.tax = 20;

            Position secFin1Position = new Position();
            secFin1Position.Name = "Secretaria financiera 1";
            secFin1Position.Salary = 350;
            secFin1Position.tax = 12;

            Position secFin2Position = new Position();
            secFin2Position.Name = "Secretaria financiera 2";
            secFin2Position.Salary = 310;
            secFin2Position.tax = 10;

            Position vicAcadPosition = new Position();
            vicAcadPosition.Name = "Vicerrector Academico";
            vicAcadPosition.Salary = 780;
            vicAcadPosition.tax = 27;

            Position jefeRegPosition = new Position();
            jefeRegPosition.Name = "Jefe Registro Academico";
            jefeRegPosition.Salary = 640;
            jefeRegPosition.tax = 22;

            //Imagen 2
            Position secReg2Position = new Position();
            secReg2Position.Name = "Secretaria Registro academico 2";
            secReg2Position.Salary = 360;
            secReg2Position.tax = 13;

            Position secReg1Position = new Position();
            secReg1Position.Name = "Secretaria Registro academico 1";
            secReg1Position.Salary = 400;
            secReg1Position.tax = 11;

            Position asist2Position = new Position();
            asist2Position.Name = "Asistente 2";
            asist2Position.Salary = 170;
            asist2Position.tax = 7;

            Position asist1Position = new Position();
            asist1Position.Name = "Asistente 1";
            asist1Position.Salary = 250;
            asist1Position.tax = 8;


            Position mensajPosition = new Position();
            mensajPosition.Name = "Mensajero";
            mensajPosition.Salary = 90;
            mensajPosition.tax = 5;


            UniversityTree universityTree = new UniversityTree();
            universityTree.CreatePosition(null, rectorPosition, null);
            universityTree.CreatePosition(universityTree.Root, vicFinPosition, rectorPosition.Name);
            universityTree.CreatePosition(universityTree.Root, contadorPosition, vicFinPosition.Name);
            universityTree.CreatePosition(universityTree.Root, secFin1Position, contadorPosition.Name);
            universityTree.CreatePosition(universityTree.Root, jefeFinPosition, vicFinPosition.Name);
            universityTree.CreatePosition(universityTree.Root, secFin2Position, contadorPosition.Name);
            universityTree.CreatePosition(universityTree.Root, vicAcadPosition, rectorPosition.Name);
            universityTree.CreatePosition(universityTree.Root, jefeRegPosition, vicAcadPosition.Name);
            universityTree.CreatePosition(universityTree.Root, secReg2Position, jefeRegPosition.Name);
            universityTree.CreatePosition(universityTree.Root, secReg1Position, jefeRegPosition.Name);
            universityTree.CreatePosition(universityTree.Root, asist2Position, secReg1Position.Name);
            universityTree.CreatePosition(universityTree.Root, mensajPosition, asist2Position.Name);
            universityTree.CreatePosition(universityTree.Root, asist1Position, secReg1Position.Name);
                   

            universityTree.PrintTree(universityTree.Root);
            Console.ReadLine();

            ////Sumar Salarios
            float totalSalary = universityTree.AddSalaries(universityTree.Root);
            Console.WriteLine($"Total salaries: {totalSalary}");
            Console.ReadLine();


        //2.1. Get the longest salary (without including "the principal".)
            float longest =0;
            //Console.WriteLine("Ingrese desde donde quiere consultar");
            //string from = Console.ReadLine();
            //Para este caso from == Rector y no se tiene en cuenta su salario
            string from = "Rector";
            if (from.Equals("Rector"))
            {
                if (universityTree.LongestSalary(universityTree.Root.Left) > universityTree.LongestSalary(universityTree.Root.Right))
                {
                    longest = universityTree.LongestSalary(universityTree.Root.Left);
                }
                else
                {
                    longest = universityTree.LongestSalary(universityTree.Root.Right);
                }
            }


            Console.WriteLine($"Longest salarie: {longest}");
            Console.ReadLine();


         //2.2. Calculate the salary average
            //Average
            float average = universityTree.Average(universityTree.Root);
            Console.WriteLine($"Average: {average}");
            Console.ReadLine();

         //2.3. How much is the salary given a certain position (e.g. "Vicerector financiero")
            //SalaryForPosition
            float salaryFromPosition = universityTree.SalaryForPosition(universityTree.Root, "Vicerrector Financiero");
            Console.WriteLine($"SalaryFromPosition: {salaryFromPosition}");
            Console.ReadLine();

         //2.4. Add salary tax(percentaje 0%-30%), each position has a different tax percentaje
            //Total Taxes
            float taxes = universityTree.TaxSum(universityTree.Root);
            Console.WriteLine($"Taxes: {taxes}");
            Console.ReadLine();
        }
    }
}
