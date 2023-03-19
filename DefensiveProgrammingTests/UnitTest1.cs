using DefensiveProgrammingBefore;
using DefensiveProgrammingShared;

namespace DefensiveProgrammingTests
{
    [TestClass]
    public class UnitTest1
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();

        [TestInitialize]
        public void Init()
        {

        }

        [TestMethod]
        public void SimpleTests()
        {
            var theCustomer = DefensiveProgrammingBefore.Samples.FindById(4, Customers);
            Assert.IsNotNull(theCustomer);

            var isValid = Samples.IsValidEmail("thebosscranky@gmail.com");
            Assert.IsTrue(isValid);

            var contains = Samples.FileContainsEmail(@"emails.txt", "thebosscranky@gmail.com");
            Assert.IsTrue(contains);

        }
    }
}