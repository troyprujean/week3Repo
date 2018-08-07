using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankingApp
{
    class Program
    {
        static string userInput;

        static float ConfirmNumber (float _parameter)
        {
            userInput = Console.ReadLine();
            if (float.TryParse(userInput, out _parameter))
            {
                return _parameter;
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a number");
                return 0;
            }
        }
        

        static bool ConfirmPin (float _userPin)
        {
            float temporary;
            string userInput = Console.ReadLine();
            if (float.TryParse(userInput, out temporary))
            {
                if (temporary != _userPin)
                {
                    Console.WriteLine("Invalid PIN, please try again");
                    return false;
                }
                else
                {
                    Console.WriteLine("Authentication successful!");
                    return true;
                }
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
            float menuChoice = 0;
            while (!isNumber)
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("(1) Create account");
                Console.WriteLine("(2) Exit");
                float input = ConfirmNumber(menuChoice);

                isNumber = input != 0;
            }


            if (menuChoice == 1)
            {
                Person user1 = new Person();
                Console.Clear();
                Console.WriteLine("Please enter your first name:");
                user1.Fname = Console.ReadLine();
                Console.WriteLine("Please enter your last name:");
                user1.Lname = Console.ReadLine();
                isNumber = false;
                while (!isNumber)
                {
                    Console.WriteLine("Please enter a PIN number");
                    if (ConfirmNumber(user1.Pin))
                    {
                        isNumber = true;
                    }
                    else isNumber = false;
                }

                isNumber = false;
                while (!isNumber)
                {
                    Console.WriteLine("Please enter your account number:");
                    if (ConfirmNumber(user1.AccountNum))
                    {
                        isNumber = true;
                    }
                    else isNumber = false;
                }

                isNumber = false;
                while (!isNumber)
                {
                    Console.WriteLine("Please enter your account balance:");
                    if (ConfirmNumber(user1.AccountBalance))
                    {
                        isNumber = true;
                    }
                    else isNumber = false;
                }

                isNumber = false;
                while (!isNumber)
                {
                    Console.WriteLine("Please enter your phone number");
                    if (ConfirmNumber(user1.PhoneNum))
                    {
                        isNumber = true;
                    }
                    else isNumber = false;
                }
                Console.WriteLine($"Congratulations {user1.Fname}, your account has been created successfully");

                isNumber = false;
                while (!isNumber)
                {
                    Console.WriteLine("Please select an option:");
                    Console.WriteLine("(1) View funds");
                    Console.WriteLine("(2) Withdraw funds");
                    Console.WriteLine("(3) Logout");
                    if (ConfirmNumber(menuChoice))
                    {
                        if (menuChoice > 2)
                        {
                            Console.WriteLine("Invalid input, please try again");
                            isNumber = false;
                        }
                        else isNumber = true;
                    }
                    else isNumber = false;
                }
                switch (menuChoice)
                {
                    case 1:
                        isNumber = false;
                        while (!isNumber)
                        {
                            Console.WriteLine("Please enter your PIN number");
                            ConfirmPin(user1.Pin);
                        }
                        Console.WriteLine($"Your account balance is: ${user1.AccountBalance}");
                        break;

                    case 2:
                        isNumber = false;
                        while (!isNumber)
                        {
                            Console.WriteLine("Please enter your PIN number");
                            ConfirmPin(user1.Pin);
                        }
                        float withdrawAmount = 0;
                        isNumber = false;
                        while (!isNumber)
                        {
                            Console.WriteLine("How much would you like to withdraw?");
                            isNumber = ConfirmNumber(withdrawAmount);
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
