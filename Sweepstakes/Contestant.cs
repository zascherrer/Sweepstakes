using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class Contestant
    {
        public string firstName;
        public string lastName;
        public string email;
        public Guid registrationNumber;

        public Contestant()
        {
            firstName = "John";
            lastName = "Doe";
            email = "john.doe@gmail.com";
            registrationNumber = new Guid();
        }

        public Contestant(string firstName, string lastName, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            registrationNumber = new Guid();
        }
    }
}
