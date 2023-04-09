#define __GANDALF__
using DefensiveProgrammingShared;
using Microsoft.VisualStudio.TestTools.UnitTesting;



#if __GANDALF__
using DefensiveProgrammingEnhanced;
#else
using DefensiveProgrammingBefore;
#endif

namespace DefensiveProgrammingTests
{
    [TestClass]
    public class UnitTest1
    {
        #region Properties

        
        private string TestAccountNumber { get; } = "FEEE FIEE FOE FUM";

        private string TestReturnAccountNumber { get; } = "MY HACKY ACCOUNT";

        private string TestCustomerName { get; } = "Big Daddy Boss Cranky";

        private string TestEmail { get; } = "fakeemail@___quacky__ducks.com";

        private string TestFileName { get; } = @"emails.txt";

        private decimal TestTransactionAmount { get; } = 987.65m;

        private Samples Sample { get; set; } = new Samples();

        #endregion

        #region Email Methods
        
        [TestInitialize]
        public void Init()
        {
        }

        [TestMethod]
        public void EmailValidatorTest()
        {
            var isValid = Sample.IsValidEmail(TestEmail);
            Assert.IsTrue(isValid);

            isValid = Sample.IsValidEmail(null);

#if __GANDALF__
            Assert.IsFalse(Sample.IsValidEmail(null));
#endif


        }

        [TestMethod]
        public void ContainsEmailTest()
        {
            var contains = Sample.FileContainsEmail(TestFileName, TestEmail);
            Assert.IsTrue(contains);

//#if __GANDALF__

            Assert.IsFalse(Sample.FileContainsEmail(TestAccountNumber, TestReturnAccountNumber));
//#endif
        }

        #endregion

        [TestMethod]
        public void PurchaseAndReturnSameTendersTest()
        {
            var theCustomer = new Customer(42, TestCustomerName, TestEmail);
            Assert.IsNotNull(theCustomer);

            // made up (moq'ed if you prefer) tender
            var theTender = new Tender(TestAccountNumber);
            Assert.IsNotNull(theTender);
            Assert.AreEqual(theTender.AccountNumber, TestAccountNumber);

            // make believe transaction
            // make a sale
            var theSale = Sample.Purchase(theCustomer, theTender, TestTransactionAmount);
            Assert.IsNotNull(theSale);
            Assert.AreEqual(theSale.Amount, TestTransactionAmount);

            // return same amount
            var theReturn = Sample.Return(theSale, theTender);
            Assert.IsNotNull(theReturn);
            Assert.IsTrue((theSale.Amount + theReturn.Amount) == 0);
            Assert.IsTrue(theTender.Balance == 0m);

        }





        [TestMethod]
        public void PurchaseAndReturnDifferentTendersTest()
        {
            var theCustomer = new Customer(42, TestCustomerName, TestEmail);
            Assert.IsNotNull(theCustomer);

            // made up (moq'ed if you prefer) tender
            var theTender = new Tender(TestAccountNumber);
            Assert.IsNotNull(theTender);
            Assert.AreEqual(theTender.AccountNumber, TestAccountNumber);

            // make believe transaction
            // make a sale
            var theSale = Sample.Purchase(theCustomer, theTender, TestTransactionAmount);
            Assert.IsNotNull(theSale);
            Assert.AreEqual(theSale.Amount, TestTransactionAmount);

            // prep a new Tender for the return
            var theReturnTender = new Tender(TestReturnAccountNumber);

            // return same amount
            var theReturn = Sample.Return(theSale, theReturnTender);
            Assert.IsNotNull(theReturn);
            Assert.IsTrue((theSale.Amount + theReturn.Amount) == 0);
            //Assert.IsTrue(theTender.Balance == 0m);

        }

        
        
        
        
        
        //Assert.IsTrue((theSale.Amount + theReturn.Amount) == 0);

    }
}