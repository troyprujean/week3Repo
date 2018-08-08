using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankingApp
{
    class Person
    {
        private static string fname;
        private static string lname;
        private static string phoneNum;
        private static decimal pin;
        private static int accountNum;
        private static decimal accountBalance;
        



        public string Fname
        {
            get
            {
                return fname;
            }
            set
            {
                fname = value;
            }
        }

        public string Lname
        {
            get
            {
                return lname;
            }
            set
            {
                lname = value;
            }
        }

        public decimal Pin
        {
            get
            {
                return pin;
            }
            set
            {
                pin = value;
            }
        }

        public int AccountNum
        {
            get
            {
                return accountNum;
            }
            set
            {
                accountNum = value;
            }
        }
        
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public decimal AccountBalance
        {
            get
            {
                return accountBalance;
            }
            set
            {
                accountBalance = value;
            }
        }

        public string PhoneNum
        {
            get
            {
                return phoneNum;
            }
            set
            {
                phoneNum = value;
            }
        }

        public Person (string _fname, string _lname, decimal _pin, int _accountNum, decimal _accountBalance, string _phoneNum)
        {
            Fname = _fname;
            Lname = _lname;
            Pin = _pin;
            AccountNum = _accountNum;
            AccountBalance = _accountBalance;
            PhoneNum = _phoneNum;
        }

        public Person ()
        {

        }
    }
}
