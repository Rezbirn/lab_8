using lab_8.Validations;

namespace lab_8.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }

        public bool IsValid 
        {
            get
            {
                return ProductValid.ProductIsValid(Name, Description, Price);
            }
        }
    }
}
