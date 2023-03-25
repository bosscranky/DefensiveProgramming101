using DefensiveProgrammingShared;

namespace DefensiveProgrammingBefore
{
    public class Samples
    {

        #region Email Validation

        public bool IsValidEmail(string candidate)
        {
            // worlds simplest, laziest and possibly least efficeint check.
            return candidate.Contains("@") && candidate.Contains(".");
        }
        #endregion

        #region File Method

        public bool FileContainsEmail(string fileName, string candidate)
        {
            string contents = System.IO.File.ReadAllText(fileName);
            return contents.Contains(candidate);
        }

        #endregion

        #region Transaction Methods

        public Transaction? Purchase(Customer aCustomer, Tender aTender, decimal anAmount)
        {
            if (aCustomer != null && aTender != null)
            {
                //do stuff;
                aTender.Charge(anAmount);
                return new Transaction(anAmount, aTender, aCustomer);
            }

            return null;
        }

        public Transaction? Return(Transaction aTransaction, Tender aTender)
        {
            if (aTransaction != null && aTender != null)
            {
                //do stuff;
                aTender.Credit(aTransaction.Amount);
                return new Transaction(aTransaction.Amount * -1, aTender, aTransaction.Customer);
            }

            return null;
        }

        #endregion
    }

}