using lab_8.Validations;

namespace lab_8.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        public bool IsValid 
        { 
            get
            {
                return UserValidation.UserIsValid(Name, Email, Password, Address);
                    
            }
        }
    }
}
