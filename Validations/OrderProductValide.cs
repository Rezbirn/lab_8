using lab_8.Models;

namespace lab_8.Validations
{
    public static class OrderProductValide
    {
        public static bool ProductIsValide(Product product)
        {
            return product is not null;
        }

        public static bool AmountIsValide(int amount)
        {
            return amount >= 0;
        }
        public static bool OrderProductIsValide(Product product, int amount)
        {
            return ProductIsValide(product) && AmountIsValide(amount);
        }
    }
}
