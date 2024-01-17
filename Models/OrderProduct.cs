using lab_8.Validations;
namespace lab_8.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }

        private Product _product;
        public Product Product
        {
            get
            {
                return _product;
            }
            set 
            {
                if (!OrderProductValide.ProductIsValide(value))
                    throw new ArgumentException();
                _product = value;
            } 
        }

        private int _amount;

        public int Amount 
        {
            get
            {
                return _amount;
            }
            set 
            {
                if (!OrderProductValide.AmountIsValide(value))
                    throw new ArgumentException();
                _amount = value;
            } 
        }

        public OrderProduct(Product product, int amount)
        {
            Product = product;
            Amount = amount;
        }

        private OrderProduct() { }
    }
}
