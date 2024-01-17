using System.Xml.Linq;

namespace lab_8.Validations
{
    public static class ProductValid
    {
        public static bool NameIsValide(string name)
        {
            if (!string.IsNullOrEmpty(name))
                return true;

            return false;
        }

        public static bool DescriptionIsValide(string description)
        {
            if (!string.IsNullOrEmpty(description))
                return true;

            return false;
        }


        public static bool PriceIsValide(int price)
        {
            if (price > 0)
                return true;

            return false;
        }

        public static bool ProductIsValid(string name, string description, int price)
        {
            return NameIsValide(name) && DescriptionIsValide(description)
                && PriceIsValide(price);
        }
    }
}
