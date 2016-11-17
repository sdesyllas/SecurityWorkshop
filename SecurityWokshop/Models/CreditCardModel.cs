namespace SecurityWokshop.Models
{
    public class CreditCardModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public string Cvv { get; set; }
    }
}