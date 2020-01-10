using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todolist
{
    class Program
    {
        List<Detail> headerList = new List<Detail>();
        public Program()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("1. Add todolist");
                Console.WriteLine("2. View todolist");
                Console.WriteLine("3. Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddTodo();
                        break;
                    case 2:
                        View();
                        break;
                    case 3:
                        break;
                }
            } while (choice != 3);
        }
        static void Main(string[] args)
        {
            new Program();
        }

        private void AddTodo()
        {
            string date, todo;
            int priority;

            Console.Write("Input date: ");
            date = Console.ReadLine();

            Console.Write("Input todo: ");
            todo = Console.ReadLine();
            
            do
            {
                Console.Write("Input priority: ");
                priority = int.Parse(Console.ReadLine());
            } while (priority != 1 && priority != 2 && priority != 3);

            Detail detail = new Detail();
            detail.Date = date;
            detail.Todo = todo;
            detail.Priority = priority;

            headerList.Add(detail);
        }

        private void View()
        {
            SortList();
            string currentDate = headerList.ElementAt(0).Date;
            Console.WriteLine("Date: " + currentDate);
            foreach (Detail detail in headerList)
            {
                if (!currentDate.Equals(detail.Date))
                {
                    currentDate = detail.Date;
                    Console.WriteLine("Date: " + currentDate);
                }
                Console.WriteLine("Todolist: " + detail.Todo);
                Console.WriteLine("Priority: " + detail.Priority);
                Console.WriteLine();
            }
        }

        private void SortList()
        {
            //headerList.Sort(
            //    delegate (Header p1, Header p2)
            //    {
            //        return p1.Date.CompareTo(p2.Date);
            //    }
            //);

            // LINQ
            // Lambda
            headerList.Sort((p1, p2) => p1.Priority.CompareTo(p2.Priority));
            headerList.Sort((p1, p2) => p1.Date.CompareTo(p2.Date));
        }
    }
}