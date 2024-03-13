using System.ComponentModel.DataAnnotations;

namespace WebClient2.Models
{
    public class DepositModel
    {
        public int amount { get; set; }
        public string? description { get; set; }
    }
}
