using System;

namespace nothinbutdotnetstore.model
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime BecameACustomerOn { get; set; }
        public bool IsPreferred { get; set; }
    }
}