using System;
using System.Collections.Generic;
using System.Text;

namespace EZDMS.App.Core
{
    public class CoverageProviderDataModel
    {

        /// <summary>
        /// The id of this CoverageProvider record
        /// <summary>
        public int ID { get; set; }

        /// <summary>
        /// The prefix id of this CoverageProvider record
        /// <summary>
        public string PrefixID { get; set; }

        /// <summary>
        /// The number of this CoverageProvider record
        /// <summary>
        public string Number { get; set; }

        /// <summary>
        /// The create date of this CoverageProvider record
        /// <summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// The last modified date of this CoverageProvider record
        /// <summary>
        public DateTime LastModifiedDate { get; set; }

        /// <summary>
        /// The is active flag of this CoverageProvider record
        /// <summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// The dealer number of this CoverageProvider record
        /// <summary>
        public string DealerNumber { get; set; }

        /// <summary>
        /// The name of this CoverageProvider record
        /// <summary>
        public string Name { get; set; }

        /// <summary>
        /// The street address of this CoverageProvider record
        /// <summary>
        public string StreetAddress { get; set; }

        /// <summary>
        /// The city of this CoverageProvider record
        /// <summary>
        public string City { get; set; }

        /// <summary>
        /// The state of this CoverageProvider record
        /// <summary>
        public string State { get; set; }

        /// <summary>
        /// The zip of this CoverageProvider record
        /// <summary>
        public string Zip { get; set; }

        /// <summary>
        /// The phone number of this CoverageProvider record
        /// <summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The phone number extension of this CoverageProvider record
        /// <summary>
        public string PhoneNumberExt { get; set; }

        /// <summary>
        /// The fax number of this CoverageProvider record
        /// <summary>
        public string FaxNumber { get; set; }

        /// <summary>
        /// The contact name of this CoverageProvider record
        /// <summary>
        public string ContactName { get; set; }

    }
}
