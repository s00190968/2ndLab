//Janessa Aulén
//s00190968
//Foundation Object Oriented Programming [FOOP 201]
//6.10.2018, Lab Sheet 2

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("\n1.\nChecking for age 17,20 and 30");
            Console.WriteLine("Age 17 has access = " + p.ageIsOkay(17));
            Console.WriteLine("Age 20 has access = " + p.ageIsOkay(20));
            Console.WriteLine("Age 30 has access = " + p.ageIsOkay(30));

            Console.WriteLine("\n2.\nCost of products:");
            Console.WriteLine("Jeans cost " + p.costOfProduct("Jeans"));
            Console.WriteLine("A jacket costs " + p.costOfProduct("Jacket"));
            Console.WriteLine("Boots cost " + p.costOfProduct("Boots"));
            Console.WriteLine("Scraves cost " + p.costOfProduct("Scarf"));
            Console.WriteLine("Belts cost " + p.costOfProduct("Belt"));
            Console.WriteLine("Socks cost " + p.costOfProduct("Socks"));

            Console.WriteLine("\n3.\nInt array with all elements initialized to 0. Array size 20");
            int[] arr = { 1 };
            p.zero(arr, 20);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("Array[ " + i + " ] = " + arr[i] + ", ");
            }
            Console.WriteLine("\n");

            Console.WriteLine("\n4.\nSum of all even numbers between the two integers 3 and 18.");
            Console.WriteLine("Sum = " + p.Sum(3, 16));

            Console.WriteLine("\n5.\nStock and sales.");
            Console.WriteLine("Was the stock updated (stock on hand: 50, sales: 12): " + p.stock(50,12));
            Console.WriteLine("Was the stock updated (stock on hand: 10, sales: 18): " + p.stock(10, 18));

            Console.WriteLine("\n6.\nSales report to a file.");
            p.salesData();
            Console.WriteLine("You can find the report in the specified folder.");
        }

        public bool ageIsOkay(int age)
        {
            if (age <= 21 && age >= 18)
            {
                return true;
            }
            return false;
        }

        public float costOfProduct(string product)
        {
            float price = 0;
            switch (product)
            {
                case "Jeans":
                    price = 67.99f;
                    break;
                case "Jacket":
                    price = 68.99f;
                    break;
                case "Boots":
                    price = 34.99f;
                    break;
                case "Scarf":
                    price = 10f;
                    break;
                case "Belt":
                    price = 10f;
                    break;
                case "Socks":
                    price = 10f;
                    break;
                default:
                    price = -999f;
                    break;
            }
            return price;
        }

        public void zero(int[] arr, int size)
        {
            arr = new int[size];
        }

        public int Sum(int n1, int n2)
        {
            int sum = 0;

            do
            {
                if (n1 % 2 == 0)
                {
                    sum += n1;
                    Console.WriteLine("Added " + n1 + " to sum");
                }
                n1++;
            } while (n1 <= n2+1);
            if (n1 % 2 == 0)
            {
                sum += n1;
                Console.WriteLine("Added " + n1 + " to sum");
            }
            return sum;
        }

        public bool stock(int stockOnHand, int sales)
        {
            if(stockOnHand < sales)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void salesData()
        {
            StreamReader sr = new StreamReader(@"D:\Schools\XAMK\Exchange Studies\FOOP\Lab2\2ndLab\Lab2\sales.txt");
            StreamWriter sw = new StreamWriter(@"D:\Schools\XAMK\Exchange Studies\FOOP\Lab2\2ndLab\Lab2\salesReport.txt");

            sw.WriteLine(string.Format("{0, 0}{1,20}", "Sales report\t", DateTime.UtcNow));
            sw.WriteLine("");
            sw.WriteLine(string.Format("{0, 0}{1,20}", "Store IDSales: ", "Performance: "));
            sw.WriteLine("");

            Console.WriteLine("Sales report\t" + DateTime.UtcNow);
            Console.WriteLine("");
            Console.WriteLine(string.Format("{0, -5}{1,20}", "Store IDSales: ", "Performance: "));
            Console.WriteLine("");

            int totalSales = 0, counter = 0;
            double averageSales = 0;

            string data = sr.ReadLine();
            string note = "";
            string[] sales;
            string id = "";
            int performance = 0;

            while (data != null)
            {
                //Console.WriteLine("in while loop");
                //Console.WriteLine(data);

                sales = data.Split(',');//sales[0] = ID and sales[1] = performance

                id = sales[0];
                performance = Int32.Parse(sales[1]);

                if (performance > 2000)
                {
                    note = "Very Good";
                }else if(performance < 1000)
                {
                    note = "Needs attention";
                }
                else
                {
                    note = "Moderate";
                }
                Console.WriteLine(string.Format("{0, -5}{1,40}{2,60}", id, performance, note));
                sw.WriteLine(string.Format("{0, 0}{1,40}{2,60}", id, performance, note));

                totalSales += Int32.Parse(sales[1]);
                counter++;

                data = sr.ReadLine();
            }

            averageSales = totalSales / counter;
            sw.WriteLine("");
            sw.WriteLine("\nTotal sales: " + totalSales + ".");
            sw.WriteLine("Average sales: " + averageSales + ".");

            Console.WriteLine("");
            Console.WriteLine("\nTotal sales: " + totalSales + ".");
            Console.WriteLine("Average sales: " + averageSales + ".");

            sr.Close();
            sw.Close();

        }
    }
}
