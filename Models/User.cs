using Microsoft.EntityFrameworkCore;
using lab_8.Hasher;
using System.ComponentModel.DataAnnotations.Schema;
using lab_8.Validations;

namespace lab_8.Models
{
    public class User
    {
        public int Id { get; private set; }

        private string _name;
        public string Name
        {
            get 
            {
                return _name;
            }  
            set
            {
                if (!UserValidation.NameIsValid(value))
                    throw new ArgumentException();
                _name = value;

            } 
        }

        private string _email;

        public string Email 
        { 
            get 
            {
                return _email;
            }
            set
            {
                if (!UserValidation.EmailIsValid(value))
                    throw new ArgumentException();
                _email = value;

            }
        }
        private string _password;
        public string Password 
        {
            get 
            {
                return _password;
            }
            set
            {
                if (!UserValidation.PasswordIsValid(value))
                    throw new ArgumentException();
                _password = PasswordHasher.HashPassword(value);
            }
        }

        private string _address;
        public string Address { 
            get
            {
                return _address;

            }
            set
            {
                if (!UserValidation.AddressIsValid(value))
                    throw new ArgumentException();
                _address = value;
            }
        }

        public User(string name, string email, string password, string address)
        {
            Name = name;
            Email = email;
            Password = password;
            Address = address;
        }

        private User() { }
    }
}
