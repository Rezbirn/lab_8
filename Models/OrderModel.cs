namespace lab_8.Models
{
    public class OrderModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Dictionary<int, int> OrdersAndAmount { get; set; }

        public bool IsValide
        {
            get
            {
                return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password)
                    && OrdersAndAmount is not null && OrdersAndAmount.Any();
            }
        }
        

    }
}
