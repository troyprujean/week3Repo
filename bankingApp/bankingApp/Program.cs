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
        static float confirmation;
        static float depositAmount;
        static float withdrawAmount;
        static bool isNumber = false;
        static bool repeat = true;
        static float menuChoice = 0;

        static bool ConfirmNumber (string _userInput)
        {
            float temporary;
            if (float.TryParse(_userInput, out temporary))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a number");
                return false;
            }
        }
        

        static bool ConfirmPin (float _savedPin)
        {
            float temporary;
            Console.WriteLine("Please enter your PIN number:");
            userInput = Console.ReadLine();
            if (float.TryParse(userInput, out temporary))
            {
                if (temporary != _savedPin)
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

        static float DepositFunds()
        {
            isNumber = false;

            while (!isNumber)
            {
                Console.WriteLine("How much would you like to deposit?");
                userInput = Console.ReadLine();
                if(ConfirmNumber(userInput))
                {
                    depositAmount = float.Parse(userInput);
                    isNumber = true;
                }
                else
                {
                    isNumber = false;
                }
            }
            return depositAmount;
        }

        static float WithdrawFunds(float _balance)
        {
            isNumber = false;

            while (!isNumber)
            {
                Console.WriteLine("How much would you like to withdraw?");
                userInput = Console.ReadLine();
                if (ConfirmNumber(userInput))
                {
                    withdrawAmount = float.Parse(userInput);
                    if (withdrawAmount > _balance)
                    {
                        Console.WriteLine("Error, you have insufficient funds to withdraw that amount, please try again");
                        isNumber = false;
                    }
                    else isNumber = true;
                }
                else
                {
                    isNumber = false;
                }
            }
            return withdrawAmount;
        }

        static bool ConfirmString (string _userInput)
        {
            if (userInput == "")
            {
                Console.WriteLine("You did not enter anything, please try again");
                return false;
            }
            else if (userInput.Length > 20)
            {
            Console.WriteLine("Your input must be less with 20 characters or less");
            return false;
            }
            else return true;
        }

        static void Main(string[] args)
        {
            Person user1 = new Person();
            Console.WriteLine("Welcome to the PoorBank ATM");
            Console.WriteLine("===========================");
            while(!isNumber)
            {
                Console.WriteLine("Please enter your first name:");
                userInput = Console.ReadLine();
                if (ConfirmString(userInput))
                {
                    user1.Fname = userInput;
                    isNumber = true;
                }
                else isNumber = false;
            }
            isNumber = false;

            while (!isNumber)
            {
                Console.WriteLine("Please enter your last name:");
                userInput = Console.ReadLine();
                if (ConfirmString(userInput))
                {
                    user1.Lname = userInput;
                    isNumber = true;
                }
                else isNumber = false;
            }
            isNumber = false;

            while (!isNumber)
            {
                Console.WriteLine("Please enter your phone number:");
                userInput = Console.ReadLine();
                if (ConfirmString(userInput))
                {
                    user1.PhoneNum = userInput;
                    isNumber = true;
                }
                else isNumber = false;
            }
            isNumber = false;
            
            Console.Clear();
            while (!isNumber)
            {
                Console.WriteLine("Please enter a 4-digit PIN");
                userInput = Console.ReadLine();
                if (ConfirmNumber(userInput))
                {
                    user1.Pin = float.Parse(userInput);
                    if (user1.Pin < 1000 || user1.Pin > 9999)
                    {
                        Console.WriteLine("Invalid PIN, your PIN must be 4-digits only");
                        user1.Pin = 0;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Please confirm your PIN");
                        userInput = Console.ReadLine();
                        if (ConfirmNumber(userInput))
                        {
                            confirmation = float.Parse(userInput);
                            if(confirmation == user1.Pin)
                            {
                                Console.WriteLine("Congratulations, your PIN has been set!");
                                isNumber = true;
                            }
                            else
                            {
                                Console.WriteLine("Your PIN's did not match, please try again");
                                isNumber = false;
                            }
                        }
                        else
                        {
                            isNumber = false;
                        }
                    }
                }
            }
            isNumber = false;
            user1.AccountNum = user1.RandomNumber(10000000, 99999999);
            Console.Clear();
            Console.WriteLine($"Congratulations {user1.Fname}, your account has been created successfully");
            Console.WriteLine($"Your new account number is: {user1.AccountNum}");
            Console.WriteLine("=========================================");
            Console.WriteLine($"Your account balance is: {user1.AccountBalance:C}");
            Console.WriteLine("=========================================");
            Console.WriteLine("press enter to continue");
            Console.ReadLine();
            Console.Clear();

            while (repeat) 
            {
                while (!isNumber)
                {
                    Console.WriteLine("What would you like to do next?");
                    Console.WriteLine("(1) Deposit Funds");
                    Console.WriteLine("(2) Withdraw Funds");
                    Console.WriteLine("(3) View Account");
                    Console.WriteLine("(4) Logout");
                    userInput = Console.ReadLine();
                    if (ConfirmNumber(userInput))
                    {
                        menuChoice = float.Parse(userInput);
                        if(menuChoice > 4)
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid input");
                            isNumber = false;
                        }
                        else
                        {
                            Console.Clear();
                            isNumber = true;
                        }
                    }
                    else isNumber = false;
                }
                isNumber = false;
                switch (menuChoice)
                {
                    case 1:
                        while (!isNumber)
                        {
                            isNumber = ConfirmPin(user1.Pin);
                        }
                        user1.AccountBalance += DepositFunds();
                        Console.Clear();
                        Console.WriteLine($"{depositAmount:C} was deposited into account number: {user1.AccountNum}");
                        Console.WriteLine($"the balance is now {user1.AccountBalance:C}");
                        Console.WriteLine("=========================================");
                        Console.WriteLine("press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                        menuChoice = 0;
                        repeat = true;
                        break;
                    case 2:
                        while (!isNumber)
                        {
                            isNumber = ConfirmPin(user1.Pin);
                        }
                        user1.AccountBalance = user1.AccountBalance - WithdrawFunds(user1.AccountBalance);
                        Console.Clear();
                        Console.WriteLine($"{withdrawAmount:C} was withdrawn from account number: {user1.AccountNum}");
                        Console.WriteLine($"the balance is now {user1.AccountBalance:C}");
                        Console.WriteLine("=========================================");
                        Console.WriteLine("press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                        menuChoice = 0;
                        repeat = true;
                        break;
                    case 3:
                        while (!isNumber)
                        {
                            isNumber = ConfirmPin(user1.Pin);
                        }
                        Console.Clear();
                        Console.WriteLine($"Account holder: {user1.Fname} {user1.Lname}\nPhone number {user1.PhoneNum}\n\n");
                        Console.WriteLine($"Account number: {user1.AccountNum}\n\nAccount balance {user1.AccountBalance:C}");
                        Console.WriteLine("=========================================");
                        Console.WriteLine("press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                        menuChoice = 0;
                        repeat = true;
                        break;
                    case 4:
                        Console.WriteLine("Thank you for using the PoorBank ATM, i hope you have more money next time :)");
                        repeat = false;
                        break;
                }
            }
            return;
        }
    }
}