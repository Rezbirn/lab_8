using lab_8.Validations;

namespace lab_8.Models
{
    public class Product
    {
        public int Id { get; private set; }

        private string _name;
        public string Name { 
            get
            {
                return _name;
            }
            set
            {
                if (!ProductValid.NameIsValide(value))
                    throw new ArgumentException();

                _name = value;
            }
        }
        private string _description;
        public string Description 
        { 
            get 
            { 
                return _description;
            }
            set 
            {
                if (!ProductValid.DescriptionIsValide(value))
                    throw new ArgumentException();

                _description = value;
            }
        }
        private int _price;
        public int Price 
        {
            get
            {
                return _price; 
            }
            set
            {
                if (!ProductValid.PriceIsValide(value))
                    throw new ArgumentException();
                _price = value;
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
                _amount = value;
            } 
        }

        public Product(string name, string description,int price, int amount)
        {
            Name = name;
            Description = description;
            Price = price;
            Amount = amount;
        }

        private Product() { }
    }
}
