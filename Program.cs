using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace Lab_01
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            Console.Write("Hello World");
            Console.Write("Hello World");
            Console.Read(); 
        }
        static void Main2(string[] args)
        {
            Console.WriteLine("Hello World");
            Console.WriteLine("Hello World");
            Console.Read();
        }
        static void Main3(string[] args)
        {
            double length;
            Console.WriteLine("Enter length of the side of square: ");
            length=Convert.ToDouble(Console.ReadLine());
            double area = length * length;
            Console.WriteLine("The total of triangle with side lengths " + length + " is: " + area);
            Console.Read();
        }
        //Manual-1 part 02 (Conditional Operations)
        static void Main4(string[] args)
        {
            float number;
            Console.WriteLine("Enter a number : ");
            number = float.Parse(Console.ReadLine());
            if (number >= 50)
                Console.WriteLine("You're passed");
            else if (number < 50)
                Console.WriteLine("You're failed");

            Console.Read();
        }
        static void Main5(string[] args)
        {
            string name = "Jack";
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("Welcome " + name);
            }
            Console.Read();
        }
        static void Main6(string[] args)
        {
            float sum = 0;
            Console.WriteLine("Enter your numbers and to exit enter (-1)");
            float num;
            num = float.Parse(Console.ReadLine());
            while (num != -1)
            {
                sum = sum + num;
                num = float.Parse(Console.ReadLine());
            }
            Console.WriteLine("The total sum = " + sum);
            Console.Read();
        }
        static void Main7(string[] args)
        {
            float sum = 0;
            Console.WriteLine("Enter your numbers and to exit enter (-1)");
            float num;
            num = float.Parse(Console.ReadLine());
            do
            {
                sum = sum + num;
                num = float.Parse(Console.ReadLine());
            } while (num != -1);
            Console.WriteLine("The total sum = " + sum);
            Console.ReadLine();
        }
        static void Main8(string[] args)
        {
            double[] values = new double[3];
            Console.WriteLine("Enter your values; ");
            for(int i = 0; i < 3; i++)
            {
                values[i] = float.Parse(Console.ReadLine());
            }
            double largest = -999;
            for (int i = 0; i < 3; i++)
            {
                if (values[i] > largest)
                {
                    largest = values[i];
                }
            }
            Console.WriteLine("The maximum value is : " + largest);
            Console.ReadLine();
        }
        static void Main9(string[] args)
        {
            Console.WriteLine("Enter age of lilly: ");
            int lillyAge=int.Parse(Console.ReadLine());

            Console.WriteLine("For how much she sold each toy?");
            int soldToysPrice = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter price of machine: ");
            int machinePrice = int.Parse(Console.ReadLine());

            savedMoney(lillyAge, soldToysPrice, machinePrice);


            Console.ReadLine();
        }
        //Function
        static void savedMoney(int age,int toysPrice,int machinePrice)
        {
            int savedAmount=0,counter=0,sumSaved=0;
            int toysAmount=0;
            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    savedAmount = (savedAmount + 10);
                    sumSaved = sumSaved + savedAmount;
                    counter++;


                }
                else
                {
                    toysAmount = (1 * toysPrice) + toysAmount;
                }
            }
            sumSaved = sumSaved - counter;
            int totalAmount = sumSaved + toysAmount;
            Console.WriteLine("Total Amount she saved is: "+ totalAmount);
            if (totalAmount >= machinePrice)
                Console.WriteLine("She can buy the machine.");
            else if (totalAmount < machinePrice)
            {
                int leftAmount = machinePrice - totalAmount;
                Console.WriteLine("She can't buy the machine she needs "+ leftAmount);
            }

        }

        //Manual-1 part 03 (Functions and file handling)
        static void Main10(string[] args)
        {
            int num1, num2;
            Console.WriteLine("Enter first number: ");
            num1=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number: ");
            num2 = int.Parse(Console.ReadLine());
            int result = summation(num1, num2);
            Console.WriteLine("Sum is : " + result);
            Console.Read();
        }
        static int summation(int num1,int num2)
        {
            int add = num1 + num2;
            return add;
        }

        static void Main11(string[] args)
        {
            string path = "C:\\Users\\IT LAND\\Desktop\\Courses\\C#\\Lab-01\\lab01.txt";
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string reader;
                while ((reader = fileVariable.ReadLine()) != null)
                {
                    Console.WriteLine(reader);
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("File doesn't exists.");
            }
            Console.ReadLine(); 
        }
        static void Main12(string[] args)
        {
            string path = "C:\\Users\\IT LAND\\Desktop\\Courses\\C#\\Lab-01\\lab01.txt";
            StreamWriter fileVariable = new StreamWriter(path, true);
            fileVariable.WriteLine("I was previously enrolled at ITU in CS program as well.");
            fileVariable.Flush();
           // fileVariable.WriteLine("I was previously enrolled at ITU in CS program as well. (2)");
            fileVariable.Close();
            Console.Read();
        }

        static void Main13(string[] args)
        {
            string path = "C:\\Users\\IT LAND\\Desktop\\Courses\\C#\\Lab-01\\form.txt";
            string[] username = new string[5];
            string[] password = new string[5];
            int option;
            do
            {
                Console.WriteLine("What do you want to do: ");
                Console.WriteLine("Login (1) or Signup(2)");

                option = int.Parse(Console.ReadLine());
                readData(path, username, password);

                if (option == 1)
                {
                    string n, p;
                    Console.WriteLine("Enter your name: ");
                    n = Console.ReadLine();
                    Console.WriteLine("Enter your password: ");
                    p = Console.ReadLine();
                    logIn(username, password, n, p);
                }
                else if (option == 2)
                {
                    Console.WriteLine("Welcome , Enter your username: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Welcome , Enter your password: ");
                    string p = Console.ReadLine();
                    signUp(path, n, p);
                }

            } while (option < 3);
            Console.Read();
        }

        static string parseData(string record,int field)
        {
            int comma = 1;
            string item = "";
            for(int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[i];
                }
            }
            return item;
        }
        static void readData(string path, string[] username, string[] password)
        {
            if (File.Exists(path))
            {
                int x = 0;
                StreamReader fileVar = new StreamReader(path);
                string record;
                while ((record = fileVar.ReadLine()) != null)
                {
                    username[x] = parseData(record, 1);
                    password[x] = parseData(record, 2);
                    x++;
                    if (x >= 5)
                    {
                        break;
                    }
                }
                fileVar.Close();
            }
            else
            {
                Console.WriteLine("File doesn't exists.");
            }
        }
        static void logIn(string[] username, string[] password, string name, string passcode)
        {
            bool flag = false;
            for(int i = 0; i < username.Length; i++)
            {
                if (name == username[i] && passcode == password[i])
                {
                    flag = true;
                }
            }
            if (flag == true)
            {
                Console.WriteLine("User found, login Successfully.");
            }
            else
            {
                Console.WriteLine("User not found, try again or signup.");
            }
        }
        static void signUp(string path, string n,string p)
        {
            if (File.Exists(path))
            {
                using (StreamWriter fileVar = new StreamWriter(path, true))
                {
                    fileVar.WriteLine(n + "," + p);
                    fileVar.Flush();
                    fileVar.Close();
                }
            }
            else
            {
                Console.WriteLine("File doesn't exist.");
            }
        }

        static void Main(string[] args)
        {
            string path = "C:\\Users\\IT LAND\\Desktop\\Courses\\C#\\Lab-01\\customers.txt";
            Console.WriteLine("Enter minimum amount of pizzas ordered: ");
            int minOrder=int.Parse(Console.ReadLine());

            Console.WriteLine("Enter minimum amount : ");
            int minPrice = int.Parse(Console.ReadLine());

            checkEligibility(path, minOrder, minPrice);
            Console.Read();

        }
        static void checkEligibility(string path,int minOrder, int minPrice)
        {
            string customerName="";
            if (File.Exists(path))
            {
                using(StreamReader reader=new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(new char[]{' '}, 3);
                        string name = parts[0];

                        int numberOfOrders = int.Parse(parts[1]);

                        string allPrices = parts[2].Trim('[', ']');
                        string[] allPricesArray = allPrices.Split(',');
                        int[] pricesOfOrders = new int[allPricesArray.Length];
                        for(int i = 0; i < allPricesArray.Length; i++)
                        {
                            pricesOfOrders[i] = int.Parse(allPricesArray[i]);
                        }

                        int countMinOrders = 0;
                        for(int i = 0; i < pricesOfOrders.Length; i++)
                        {
                            if (pricesOfOrders[i] >= minPrice)
                            {
                                countMinOrders++;
                            }
                        }
                        if (countMinOrders >= minOrder )
                        {
                            customerName = name;
                            Console.WriteLine(customerName + " is eligible for a free pizza.");
                        }
                    }
                }
            }
        }

    }
}
