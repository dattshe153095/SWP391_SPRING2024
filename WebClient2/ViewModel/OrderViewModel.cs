namespace WebClient2.ViewModel
{
    public class OrderViewModel
    {
        public string code { get; set; }
        public string create_user { get; set; }
        public string state { get; set; }
        public string status { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public string fee_type { get; set; }
        public int fee_amount { get; set; }
        public int earn_amount { get; set; }
        public string description { get; set;}
        public string contact { get; set; }
        public string hide_content { get; set; }
        public bool is_public { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set;}
        public string link_share { get; set; }

    }
}
