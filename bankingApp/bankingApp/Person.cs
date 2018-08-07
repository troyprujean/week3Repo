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
        private static float pin;
        private static float accountNum;
        private static float accountBalance;
        private static float phoneNum;



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

        public float Pin
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

        public float AccountNum
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
        
        
        public float AccountBalance
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

        public float PhoneNum
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

        public Person (string _fname, string _lname, float _pin, float _accountNum, float _accountBalance, float _phoneNum)
        {
            Fname = _fname;
            Lname = _lname;
            Pin = _pin;
            AccountNum = _accountNum;
            AccountBalance = _accountBalance;
            PhoneNum = _phoneNum;
        }
    }
}
