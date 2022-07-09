using System;
using System.Collections.Generic;
using System.Text;

namespace EZDMS.App.Core
{
    public class CustomerItemDataModel
    {

        /// <summary>
        /// The number of this customer record
        /// <summary>
        public string Number { get; set; }

        /// <summary>
        /// The first name of this customer record
        /// <summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of this customer record
        /// <summary>
        public string LastName { get; set; }

        /// <summary>
        /// The business name of this customer record
        /// <summary>
        public string Business { get; set; }

        /// <summary>
        /// The full address of this customer record
        /// <summary>
        public string Address { get; set; }
                
        /// <summary>
        /// The phone of this customer record
        /// <summary>
        public string PhoneNumber { get; set; }
                
        /// <summary>
        /// The email of this customer record
        /// <summary>
        public string Email { get; set; }
                
        /// <summary>
        /// The status of this customer record
        /// <summary>
        public string Status { get; set; }

    }
}
