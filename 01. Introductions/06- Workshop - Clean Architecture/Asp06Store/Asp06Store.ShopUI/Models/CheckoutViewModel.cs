using System.ComponentModel.DataAnnotations;

namespace Asp06Store.ShopUI.Models
{
    public class CheckoutViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
