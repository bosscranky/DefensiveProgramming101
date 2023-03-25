using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefensiveProgrammingShared
{
    public class Tender
    {
        public decimal Balance { get; set; }

        public string AccountNumber { get; private set; } = string.Empty;

        public void Credit(decimal anAmount)
        {
            // credit this account number with the amount supplied
            Balance -= anAmount;
        }

        public void Charge(decimal anAmount)
        {
            // charge this account with the amount provided
            Balance += anAmount;
        }

        public Tender(string accountNumber)
        {
            AccountNumber = accountNumber;
        }
    }
}
