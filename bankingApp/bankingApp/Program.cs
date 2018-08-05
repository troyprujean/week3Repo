using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankingApp
{
    class Program
    {
        static bool confirmNumber (string _input)
        {
            int temporary = 0;
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out temporary))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid input, please try again");
                return false;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the mobile banking app.");
            bool isNumber = false;
            int menuChoice = 0;
            int menu2Choice = 0;
            int temporary = 0;
            while (!isNumber)
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("(1) Create account");
                Console.WriteLine("(2) Exit");
                string userInput = Console.ReadLine();
                confirmNumber(userInput);
                if (menuChoice > 2)
                {
                    Console.WriteLine("Invalid input, please try again");
                    isNumber = false;
                }
                else isNumber = true;
            }
            if (menuChoice == 1)
            {
                Person user1 = new Person("","",0,0,0,0);
                Console.Clear();
                Console.WriteLine("Please enter your first name:");
                user1.Fname = Console.ReadLine();
                Console.WriteLine("Please enter your last name:");
                user1.Lname = Console.ReadLine();
                isNumber = false;
                while (!isNumber)
                {
                    Console.WriteLine("Please enter a PIN number");
                    string userInput = Console.ReadLine();
                    if (int.TryParse(userInput, out temporary))
                    {
                        user1.Pin = temporary;
                        isNumber = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please try again");
                        isNumber = false;
                    }
                }
                isNumber = false;
                while (!isNumber)
                {
                    Console.WriteLine("Please enter your account number:");
                    string userInput = Console.ReadLine();
                    if (int.TryParse(userInput, out temporary))
                    {
                        user1.AccountNum = temporary;
                        isNumber = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please try again");
                        isNumber = false;
                    }
                }
                isNumber = false;
                while (!isNumber)
                {
                    Console.WriteLine("Please enter your account balance:");
                    string userInput = Console.ReadLine();
                    if (int.TryParse(userInput, out temporary))
                    {
                        user1.AccountBalance = temporary;
                        isNumber = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please try again");
                        isNumber = false;
                    }
                }
                isNumber = false;
                while (!isNumber)
                {
                    Console.WriteLine("Please enter your phone number");
                    string userInput = Console.ReadLine();
                    if (int.TryParse(userInput, out temporary))
                    {
                        user1.PhoneNum = temporary;
                        isNumber = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please try again");
                        isNumber = false;
                    }
                }
                isNumber = false;

                while (!isNumber)
                {
                    Console.WriteLine("Please select an option:");
                    Console.WriteLine("(1) View funds");
                    Console.WriteLine("(2) Withdraw funds");
                    Console.WriteLine("(3) Logout");
                    string userInput = Console.ReadLine();
                    if (int.TryParse(userInput, out temporary))
                    {
                        if (temporary > 3)
                        {
                            Console.WriteLine("Invalid input, please try again");
                            isNumber = false;
                        }
                        else
                        {
                            menu2Choice = temporary;
                            isNumber = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please try again");
                        isNumber = false;
                    }
                }
                int userPIN;
                switch (menu2Choice)
                {
                    case 1:
                        isNumber = false;
                        while (!isNumber)
                        {
                            Console.WriteLine("Please enter your PIN number");
                            string userInput = Console.ReadLine();
                            if (int.TryParse(userInput, out temporary))
                            {
                                if (temporary != user1.Pin)
                                {
                                    Console.WriteLine("Invalid PIN, please try again");
                                }
                                else
                                {
                                    userPIN = temporary;
                                    isNumber = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input, please try again");
                                isNumber = false;
                            }
                        }
                        Console.WriteLine("Authentication successful");
                        Console.WriteLine($"Your account balance is: ${user1.AccountBalance}");
                        break;
                    case 2:
                        isNumber = false;
                        while (!isNumber)
                        {
                            Console.WriteLine("Please enter your PIN number");
                            string userInput = Console.ReadLine();
                            if (int.TryParse(userInput, out temporary))
                            {
                                if (temporary != user1.Pin)
                                {
                                    Console.WriteLine("Invalid PIN, please try again");
                                }
                                else
                                {
                                    userPIN = temporary;
                                    isNumber = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input, please try again");
                                isNumber = false;
                            }
                        }
                        Console.WriteLine("Authentication successful");
                        int withdrawAmount = 0;
                        isNumber = false;
                        while (!isNumber)
                        {
                            Console.WriteLine("How much would you like to withdraw?");
                            string userInput = Console.ReadLine();
                            if (int.TryParse(userInput, out temporary))
                            {
                                 withdrawAmount = temporary;
                                 isNumber = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input, please try again");
                                isNumber = false;
                            }
                        }

                        if (withdrawAmount > user1.AccountBalance)
                        {
                            Console.WriteLine("Insufficient funds to withdraw that amount");
                        }
                        else
                        {
                            user1.AccountBalance = user1.AccountBalance - withdrawAmount;
                            Console.WriteLine($"Your account balance is now: ${user1.AccountBalance}");
                        }
                        break;
                    case 3: break;
                }

            }
        }
    }
}
