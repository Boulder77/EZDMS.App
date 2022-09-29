using System;
using System.Collections.Generic;
using System.Text;

namespace EZDMS.App.Core
{
    public class SystemBackAddsDataModel
    {

        /// <summary>
        /// The number of this FrontAdds record
        /// <summary>
        public int Number { get; set; }        

        /// <summary>
        /// The id of this FrontAdds record
        /// <summary>
        public string Id { get; set; }

        /// <summary>
        /// The create date of this FrontAdds record
        /// <summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// The last modified date of this FrontAdds record
        /// <summary>
        public DateTime LastModifiedDate { get; set; }

        /// <summary>
        /// The is active of this FrontAdds record
        /// <summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// The type of this FrontAdds record
        /// <summary>
        public string Type { get; set; }

        /// <summary>
        /// The name of this FrontAdds record
        /// <summary>
        public string Name { get; set; }

        /// <summary>
        /// The retail of this FrontAdds record
        /// <summary>
        public decimal Retail { get; set; }

        /// <summary>
        /// The cost of this FrontAdds record
        /// <summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// The m s r p of this FrontAdds record
        /// <summary>
        public decimal MSRP { get; set; }

        /// <summary>
        /// The in deal of this FrontAdds record
        /// <summary>
        public bool InDeal { get; set; }

        /// <summary>
        /// The in payment of this FrontAdds record
        /// <summary>
        public bool InPayment { get; set; }

        /// <summary>
        /// The is taxable of this FrontAdds record
        /// <summary>
        public bool IsTaxable { get; set; }

        /// <summary>
        /// The provider number of this FrontAdds record
        /// <summary>
        public string ProviderNumber { get; set; }



    }
}
