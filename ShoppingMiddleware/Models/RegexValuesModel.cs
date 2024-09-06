using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.WebPages;

namespace ShoppingMiddleware.Models
{
    public class RegexValues
    {
        /* *************************** Documents ***************************
         * 
         * Todo: 
         *       + Cln All message Regex before check regex.
         *       + Set isValid is flase when create new Method validate.
         *       + Add new message when Regex `flase`.
         * 
         * *************************** Documents *************************** */


        // Setup:
        public List<string> messages = new List<string>();
        private bool isValid;
        
        public bool IsStrongPassword(string password)
        {
            // setup:
            messages.Clear();
            isValid = false;

            /* Check if the password is empty */
            if (string.IsNullOrEmpty(password))
            {
                messages.Add("Password is empty.");
                return false;
            }

            /* Check password length */
            if (password.Length < 6 || password.Length > 10)
                messages.Add("Password must be longer than 6 and shorter than 10 characters.");
            /* Check for spaces */
            if (password.Contains(" "))
                messages.Add("Password should not contain spaces.");
            // Check if the password contains at least one uppercase letter
            if (!password.Any(char.IsUpper))
                messages.Add("Password must have at least one uppercase letter.");
            // Check if the password contains at least one lowercase letter
            if (!password.Any(char.IsLower))
                messages.Add("Password must have at least one lowercase letter.");
            // Check if the password contains at least one digit
            if (!password.Any(char.IsDigit))
                messages.Add("Password must have at least one digit.");
            // Check if the password contains at least one special character
            if (!password.Any(c => !char.IsLetterOrDigit(c)))
                messages.Add("Password must have at least one special character.");
            
            if( messages.Count <= 0)
                isValid = true;

            return isValid;
        }

        public bool PhoneNumberValid(string phoneNumber)
        {
            // setup:
            messages.Clear();
            isValid = false;

            // Check if phone number is empty.
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                messages.Add("Please input the phone number.");
            }
            // Phone number must be exactly 10 digits.
            if (phoneNumber.Length != 10 || !phoneNumber.All(char.IsDigit))
            {
                messages.Add("Phone number must be exactly 10 digits and contain only numbers.");
            }
            // Check if phone number contains at least one character (this check is redundant if above is valid).
            if (!phoneNumber.Any(char.IsDigit))
            {
                messages.Add("Phone number must contain at least one numeric character.");
            }

            // If there are no messages, the phone number is valid.
            if (messages.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    
        public bool UserNameIsValid(string userName)
        {
            // setup:
            messages.Clear();
            isValid = false;

            /* User name not empty */
            if (userName.IsEmpty())
            {
                messages.Add("User name is empty.");
                return false;
            }

            /* User name length validations */
            if (userName.Length <= 2 || userName.Length >= 10) 
                messages.Add("User name short than 3 and long than 10 charaters.");
            /* Check for spaces */
            if (userName.Contains(" "))
                messages.Add("User name should not contain spaces.");
            // User name is valid:
            if(messages.Count <= 0)
            isValid = true;

            return isValid;
        }
    
    }
}