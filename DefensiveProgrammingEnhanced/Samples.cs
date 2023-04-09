﻿using DefensiveProgrammingShared;

namespace DefensiveProgrammingEnhanced
{
    public class Samples
    {
        #region Email Validation

        public bool IsValidEmail(string candidate)
        {
            // worlds simplest, laziest and possibly least efficeint check.
            return !string.IsNullOrWhiteSpace(candidate) && candidate.Contains("@") && candidate.Contains(".");
        }
        #endregion

        #region File Method

        public bool FileContainsEmail(string fileName, string candidate)
        {
            if (!string.IsNullOrWhiteSpace(fileName) && !string.IsNullOrWhiteSpace(candidate))
            {
                #region Secondary Checks

                if (!File.Exists(fileName))
                {
                    return false;
                }

                #endregion

                #region Tertiary Checks

                // TODO: figure out how to verify you can read the file.
                // you might just catch the exception generated by ReadAllText, maybe,
                // IF exceptions aren't too costly in your use case.
                #endregion

                string contents = System.IO.File.ReadAllText(fileName);
                return contents.Contains(candidate);
            }

            return false;
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
            if (aTransaction != null && aTender != null && TendersAreOK(aTransaction.Account, aTender))
            {
                //do stuff;
                aTender.Credit(aTransaction.Amount);
                return new Transaction(aTransaction.Amount * -1, aTender, aTransaction.Customer);
            }

            return null;
        }

        private bool TendersAreOK(Tender account, Tender aTender)
        {
            // note: in private methods, you may decide that input validation has already been completed.
            // that's dealers choice, I know that it gets old constantly checking for nulls...
            // Also, a number of my previous clients have had a check here, too, usually at a customer level,
            // to allow the customer to specify if they allow returns to a different tender.
            return account != null && aTender != null && account.AccountNumber == aTender.AccountNumber;
        }

        #endregion
    }
}