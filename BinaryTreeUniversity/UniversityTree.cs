using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeUniversity
{
    class UniversityTree
    {
        public PositionNode Root;

        public void CreatePosition(PositionNode parent, Position positionToCreate, string parentPositionName)
        {
            PositionNode newNode = new PositionNode();
            newNode.Position = positionToCreate;
            if(Root == null )
            {
                Root = newNode;
                return;
            }

            if(parent == null)
            {
                return;
            }
            if(parent.Position.Name == parentPositionName)
            {
                if (parent.Left == null)
                {
                    parent.Left = newNode;
                    return;
                }
                parent.Right = newNode;
                return;
            }

            CreatePosition(parent.Left, positionToCreate, parentPositionName);
            CreatePosition(parent.Right, positionToCreate, parentPositionName);
        }

        public void PrintTree (PositionNode from)
        {
            if(from == null)
            {
                return;
            }
            Console.WriteLine($"{from.Position.Name} : ${from.Position.Salary}");
            PrintTree(from.Left);
            PrintTree(from.Right);
        }

        public float AddSalaries(PositionNode from)
        {
            if (from == null)
            { 
                return 0;
            }
            return from.Position.Salary + AddSalaries(from.Left) + AddSalaries(from.Right);
        }

        //2.1. Get the longest salary (without including "the principal".)
        float longest = 0;
        public float LongestSalary (PositionNode from)
        {
            if (from != null)
            {

                if (from.Position.Salary >= longest)
                {
                    longest = from.Position.Salary;
                }

               float longestL = LongestSalary(from.Left);
               float longestR = LongestSalary(from.Right);


                if (longestL > longestR)
                {
                    return longestL;
                }
                return longestR;
            }
                 
            
            return longest;
        }

        //2.2. Calculate the salary average
        //nodes must be counted
        public float CountNodes(PositionNode from)
        {
            if(from == null)
            {
                return  0;
            }

            return CountNodes(from.Left) + CountNodes(from.Right) + 1;
        }

        //the sum is used and divided by the number of nodes
        public float Average(PositionNode from)
        {
            if (from == null)
            {
                return 0;
            }
            
            return AddSalaries(from)/CountNodes(from);
        }

        //2.3. How much is the salary given a certain position (e.g. "Vicerector financiero")
        public float SalaryForPosition(PositionNode from, string position)
        {

            if (from == null)
            {
                return 0;
            }

            if (from.Position.Name == position)
            {
             return AddSalaries(from.Left) + AddSalaries(from.Right) + from.Position.Salary;
            }
              else
            {
                return SalaryForPosition(from.Left, position) + SalaryForPosition(from.Right, position);
            }

        }


        //2.4. Add salary tax(percentaje 0%-30%), each position has a different tax percentaje
        public float TaxSum(PositionNode from)
        {
            if (from == null)
            {
                return 0;
            }
            return ((from.Position.Salary * from.Position.tax)/100) + TaxSum(from.Left) + TaxSum(from.Right);
        }

    }
}
