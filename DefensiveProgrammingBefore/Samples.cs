using DefensiveProgrammingShared;

namespace DefensiveProgrammingBefore
{
    public class Samples
    {




        public static Customer FindById(int suppliedId, List<Customer> customers)
        {

#pragma warning disable CS8603 // Possible null reference return.

            return customers.Where(customer => customer.Id == suppliedId).FirstOrDefault();

#pragma warning restore CS8603 // Possible null reference return.


        }

        public static bool IsValidEmail(string candidate)
        {
            return candidate.Contains("@") && candidate.Contains(".");
        }


        public static bool FileContainsEmail(string fileName, string candidate)
        {
            string contents = System.IO.File.ReadAllText(fileName);
            return contents.Contains(candidate);
        }

    }

}