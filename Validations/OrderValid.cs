using lab_8.Models;
using static lab_8.Models.Order;

namespace lab_8.Validations
{
    public static class OrderValid
    {

        public static bool OwnerIsValid(User owner)
        {
            if (owner is not null)
                return true;
            return false;
        }

        public static bool OrdersIsValid(List<OrderProduct> orders)
        {
            if (orders is not null && orders.Any())
                return true;
            return false;
        }

        public static bool StatusOrderIsValid(StatusOrder status)
        {
            if (Enum.IsDefined(status))
                return true;
            return false;
        }

        public static bool OrderIsValid(User owner, List<OrderProduct> orders, StatusOrder status)
        {
            return OwnerIsValid(owner)
                && OrdersIsValid(orders)
                && StatusOrderIsValid(status);
        }
    }
}
