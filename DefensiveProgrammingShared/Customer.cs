namespace DefensiveProgrammingShared
{
    public class Customer
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = String.Empty;

        public string Email { get; private set; } = String.Empty;

        public Customer(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}