using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.ResponseModel
{
    public class RegisterationResponseModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailId { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
