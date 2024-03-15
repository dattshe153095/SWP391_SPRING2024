namespace WebClient2.Services
{
    public class VnPaymentRequestModel
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
