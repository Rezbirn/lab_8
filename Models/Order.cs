using lab_8.Validations;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace lab_8.Models
{
    public class Order
    {

        public enum StatusOrder
        {
            BeingProcessed = 1,
            Sending = 2,
            Completed = 3,
            Canceled = 4
        }

        public int Id { get; set; }

        private User _owner;
        public User Owner 
        {
            get
            {
                return _owner;
            }
            set
            {
                if (!OrderValid.OwnerIsValid(value))
                    throw new ArgumentException();
                _owner = value;
            }
        }

        private List<OrderProduct> _orders;

        public List<OrderProduct> Orders 
        { 
            get
            {
                return _orders;
            }
            set
            {
                if (!OrderValid.OrdersIsValid(value))
                    throw new ArgumentException();
                _orders = value;
            } 
        }
        private StatusOrder _statusOrder;
        public StatusOrder Status 
        { 
            get
            {
                return _statusOrder;
            }
            set 
            {
                if (!OrderValid.StatusOrderIsValid(value))
                    throw new ArgumentException();
                _statusOrder = value;

            } 
        }


        public Order(User owner, List<OrderProduct> orders, StatusOrder status)
        {
            Owner = owner;
            Orders = orders;
            Status = status;
        }
        private Order() { }
    }
}
