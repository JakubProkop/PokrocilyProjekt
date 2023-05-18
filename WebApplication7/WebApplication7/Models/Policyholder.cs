namespace WebApplication7.Models
{
    /// <summary>
    /// vytvoření třídy pojištěnec
    /// </summary>
    public class Policyholder
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public int TelephoneNumber { get; set; }
        public string Street { get; set; } = "";
        public string City { get; set; } = "";
        public int PostCode { get; set; }
        public ICollection<Assurance> Assurances { get; set; }

        public Policyholder()
        {
            Assurances = new List<Assurance>();
        }
    }
}
