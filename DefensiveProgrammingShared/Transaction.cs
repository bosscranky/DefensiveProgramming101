using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefensiveProgrammingShared
{
    public class Transaction
    {

        public decimal Amount { get; set; }

        public Tender Account { get; set; }

        public Customer Customer { get; set; }

        public Transaction(decimal amount, Tender account, Customer customer)
        {
            Amount = amount;
            Account = account;
            Customer = customer;
        }   
    }
}
