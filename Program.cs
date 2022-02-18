using BankApp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace BankApp
{
    class LimitExceeded : Exception
    {
        public override string Message
        {
            get
            {
                string msg = "Please ensure that the deposit is within daily limit!";
                return msg;
            }
        }
    }
    public class Customers
    {
        
        public string name
        {
            get;
            set;
        }
        public string gender
        {
            get;
            set;
        }
        public string location
        {
            get;
            set;
        }


        
    }
    class List
    {
        public void callList()
        {

            List<Customers> cust = new List<Customers>();
            string fileName = @"D:\userDetails.txt";
            using (FileStream fs = File.Create(fileName)) ;
        l: Console.WriteLine("Please provide name:");
            string uName = Console.ReadLine();
            Console.WriteLine("Enter gender");
            string gen = Console.ReadLine();
            Console.WriteLine("Please provide location:");
            string loc = Console.ReadLine();
            cust.Add(new Customers { name = uName, gender = gen, location = loc });
            string line = (uName + "    " + gen + "    " + loc);
            File.AppendAllText(fileName, line + Environment.NewLine);
            Console.WriteLine("Enter y or n to enter another user's details?");
            char q = Convert.ToChar(Console.ReadLine());

            if (q == 'n')
            {
                goto j;
            }
            else { goto l; }
        j: Console.WriteLine("Printing the customers details");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("|Name         ||         Gender         ||         Location  ");
            Console.WriteLine("-----------------------------------------------------");
            foreach (Customers customer in cust)
            {

                Console.WriteLine("|{0}        ||         {1}        ||        {2}       ", customer.name, customer.gender, customer.location);
            }
            Console.WriteLine("-----------------------------------------------------");


        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List li = new List();
            Console.WriteLine("BANK TRANSACTION APPLICATION");
            int count = 1;
            long accBal=0;
            
            c:Console.WriteLine("---Choose the type of action---");
            Console.WriteLine("---Options---\n1 for Savings Account\n2 for Current Account\n3 for ChildCare Account\n4 for entering user details\n5 for exit\nEnter: ");
            int ch = Convert.ToInt32(Console.ReadLine());
            
            switch (ch)
            {
                case 1:
                    Console.WriteLine("Account type:Savings");
                    break;
                case 2:
                    Console.WriteLine("Account type:Current");
                    break;
                case 3:
                    Console.WriteLine("Account type:Child Care");
                    break;
                
                default:
                    Console.WriteLine(" ");
                    break;

            }
            

            switch (ch)
            {
                case 1:
                    g: Console.WriteLine("Enter the amount to be deposited\nThe daily limit for Savings Account is Rs.100000");
                    long dep1 = Convert.ToInt64(Console.ReadLine());
                    try
                    {
                        if (dep1 > 100000 && count<=3)
                        {
                            throw new LimitExceeded();
                        }
                        if(dep1 <=100000 )
                        {
                            accBal = accBal+dep1;
                            Console.WriteLine("The balance in your account is Rs.{0}", accBal);
                            Console.WriteLine("-----------------------------------");
                            a: Console.WriteLine("Do you want to perform another transaction?\nEnter y or n");
                            char i = Convert.ToChar(Console.ReadLine());
                            
                            if (i == 'y' && count<=3)
                            { 
                                w:Console.WriteLine("Enter 1 for deposit or 2 for withdrawal");
                                int n = Convert.ToInt32(Console.ReadLine());
                                if (n == 1)
                                {
                                    goto g;
                                }
                                else if(n==2)
                                {
                                    Console.WriteLine("Enter the amount of withdrawal");
                                    long amt = Convert.ToInt64(Console.ReadLine());
                                    if (amt < accBal)
                                    {
                                        accBal = accBal - amt;
                                        Console.WriteLine("Rs.{0} withdrawn from your account",amt);
                                        Console.WriteLine("Yor balance is {0}", accBal );
                                        goto a;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Withdrawal amount is more than balance!");
                                        goto a;

                                    }

                                }
                                else{
                                    Console.WriteLine("Invalid input--Enter only 1 or 2");
                                    goto w;
                                }
                                                      
                            }
                            else
                            {
                                Console.WriteLine("Your daily withdrawal limit has exceeded 3");
                                Console.WriteLine("Deducting Rs.500 for each transaction that has exceeded the daily limit..");
                                Console.WriteLine("Your current balance is {0}", accBal - (count * 500));
                            }
                            
                        }
                        
                        
                    }
                    catch (LimitExceeded b)
                    {
                        Console.WriteLine(b.Message);
                    }
                    count++;
                    break;
                case 2:
                    Console.WriteLine("Enter the amount to be deposited\nThe daily limit for Current Account is Rs.20000");
                    long dep2 = Convert.ToInt64(Console.ReadLine());
                    try
                    {
                        if (dep2 > 200000 && count <= 3)
                        {
                            throw new LimitExceeded();
                        }
                        if (dep2 <= 200000)
                        {
                            accBal = dep2;
                            Console.WriteLine("The balance in your account is {0}", accBal);
                            Console.WriteLine("-----------------------------------");
                            a: Console.WriteLine("Do you want to perform another transaction?\nEnter y or n");
                            char i = Convert.ToChar(Console.ReadLine());
                            if (i == 'y' && count<=3)
                            {
                                w:Console.WriteLine("Enter 1 for deposit or 2 for withdrawal");
                                int n = Convert.ToInt32(Console.ReadLine());
                                if (n == 1)
                                {
                                    goto g;
                                }
                                else if(n==2)
                                {
                                    Console.WriteLine("Enter the amount of withdrawal");
                                    long amt = Convert.ToInt64(Console.ReadLine());
                                    if (amt < accBal)
                                    {
                                        accBal = accBal - amt;
                                        Console.WriteLine("Rs.{0} withdrawn from your account",amt);
                                        Console.WriteLine("Yor balance is {0}", accBal);
                                        goto a;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Withdrawal amount is more than balance!");
                                        goto a;

                                    }

                                    
                                }
                                else{
                                    Console.WriteLine("Invalid input--Enter only 1 or 2");
                                    goto w;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Your daily withdrawal limit has exceeded 3");
                                Console.WriteLine("Deducting Rs.500 for each transaction that has exceeded the daily limit..");
                                Console.WriteLine("Your current balance is {0}", accBal - (count * 500));

                            }

                        }
                        

                    }
                    catch (LimitExceeded b)
                    {
                        Console.WriteLine(b.Message);
                    }
                    count++;
                    break;

                case 3:
                    Console.WriteLine("Enter the amount to be deposited\nThe daily limit for Child care Account is Rs.50000");
                    long dep3 = Convert.ToInt64(Console.ReadLine());
                    try
                    {
                        if (dep3 > 50000 && count <= 3)
                        {
                            throw new LimitExceeded();
                        }
                        if (dep3 <= 100000 )
                        {
                            accBal = dep3;
                            Console.WriteLine("The balance in your account is {0}", accBal);
                            Console.WriteLine("-----------------------------------");
                            a: Console.WriteLine("Do you want to perform another transaction?\nEnter y or n");
                            char i = Convert.ToChar(Console.ReadLine());
                            if (i == 'y' && count<=3)
                            {
                                w:Console.WriteLine("Enter 1 for deposit or 2 for withdrawal");
                                int n = Convert.ToInt32(Console.ReadLine());
                                if (n == 1)
                                {
                                    goto g;
                                }
                                else if(n==2)
                                {
                                    Console.WriteLine("Enter the amount of withdrawal");
                                    long amt = Convert.ToInt64(Console.ReadLine());
                                    if (amt < accBal)
                                    {
                                        accBal = accBal - amt;
                                        Console.WriteLine("Rs{0} withdrawn from your account",amt);
                                        Console.WriteLine("Yor balance is {0}", accBal);
                                        goto a;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Withdrawal amount is more than balance!");
                                        goto a;

                                    }

                                    
                                }
                                else{
                                    Console.WriteLine("Invalid input--Enter only 1 or 2");
                                    goto w;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Your daily withdrawal limit has exceeded 3");
                                Console.WriteLine("Deducting Rs.500 for each transaction that has exceeded the daily limit..");
                                Console.WriteLine("Your current balance is {0}", accBal - (count * 500));

                            }

                        }
                        
                    }
                    catch (LimitExceeded b)
                    {
                        Console.WriteLine(b.Message);
                    }
                    count++;
                    break;
                case 4:
                    li.callList();
                    Console.WriteLine("Do you want to perform any other action..Enter y or n");
                    char choice = Convert.ToChar(Console.ReadLine());
                    if(choice=='y')
                    {
                        goto c;
                    }
                    
                    
                    break;
                case 5:
                    break;
                    
                default:
                    Console.WriteLine("Please enter a valid choice among 1,2,3 or 4");
                    break;
            }
            Console.ReadKey();

        }
       
    }
}
