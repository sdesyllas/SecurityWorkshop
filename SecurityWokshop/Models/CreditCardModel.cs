using System.ComponentModel.DataAnnotations;

namespace SecurityWokshop.Models
{
    public class CreditCardModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^4[0-9]{12}(?:[0-9]{3})?$", ErrorMessage = "Invalid Credit card number")]
        public string Number { get; set; }

        [Required]
        [Range(1, 12)]
        public int ExpiryMonth { get; set; }

        [Required]
        [Range(2016, 2050)]
        public int ExpiryYear { get; set; }

        [Required]
        [RegularExpression("^([0-9]{3,4})$", ErrorMessage = "Invalid CVV")]
        public string Cvv { get; set; }
    }
}