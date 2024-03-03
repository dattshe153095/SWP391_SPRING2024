using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebClient2.ViewModel
{
    public class ProductViewModel
    {
        [Required(ErrorMessage = "Name cannot be blank")]
        public string name { get; set; }

        [Required(ErrorMessage = "Price cannot be blank")]
        public int price { get; set; }

        [Required(ErrorMessage = "Quantity cannot be blank")]
        public int quantity { get; set; }

        [Required(ErrorMessage = "Content cannot be blank")]
        public string content { get; set; }
        public string description { get; set; }
    }
}
