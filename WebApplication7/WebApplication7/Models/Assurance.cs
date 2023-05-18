namespace WebApplication7.Models
{
    /// <summary>
    /// vytvoření třídy pojištění
    /// </summary>
    /// po vytvoření databáze se PolicyholderId namapoval jako cizí klíč k Policyholder Id
    public class Assurance
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";

        public int PolicyholderId { get; set; }

        public string Type { get; set; } = "";
        public int Amount { get; set; }
        public string Payment { get; set; } = "";

        public virtual Policyholder Policyholder { get; set; }
    }
}
