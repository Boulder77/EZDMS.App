using System;
using System.Collections.Generic;
using System.Text;

namespace EZDMS.App.Core
{
    public class SalesTaxesDataModel
    {

        /// <summary>
        /// The deal number of this SalesTaxes record
        /// <summary>
        public int DealNumber { get; set; }

        /// <summary>
        /// The taxes in payment of this SalesTaxes record
        /// <summary>
        public bool TaxesInPayment { get; set; }

        /// <summary>
        /// The state tax active of this SalesTaxes record
        /// <summary>
        public bool StateTaxActive { get; set; }

        /// <summary>
        /// The state tax name of this SalesTaxes record
        /// <summary>
        public string StateTaxName { get; set; }

        /// <summary>
        /// The state tax base of this SalesTaxes record
        /// <summary>
        public decimal StateTaxBase { get; set; }

        /// <summary>
        /// The state tax amount of this SalesTaxes record
        /// <summary>
        public decimal StateTaxAmount { get; set; }

        /// <summary>
        /// The state tax rate of this SalesTaxes record
        /// <summary>
        public decimal StateTaxRate { get; set; }

        /// <summary>
        /// The county tax active of this SalesTaxes record
        /// <summary>
        public bool CountyTaxActive { get; set; }

        /// <summary>
        /// The county tax name of this SalesTaxes record
        /// <summary>
        public string CountyTaxName { get; set; }

        /// <summary>
        /// The county tax base of this SalesTaxes record
        /// <summary>
        public decimal CountyTaxBase { get; set; }

        /// <summary>
        /// The county tax amount of this SalesTaxes record
        /// <summary>
        public decimal CountyTaxAmount { get; set; }

        /// <summary>
        /// The county tax rate of this SalesTaxes record
        /// <summary>
        public decimal CountyTaxRate { get; set; }

        /// <summary>
        /// The local tax active of this SalesTaxes record
        /// <summary>
        public bool LocalTaxActive { get; set; }

        /// <summary>
        /// The local tax name of this SalesTaxes record
        /// <summary>
        public string LocalTaxName { get; set; }

        /// <summary>
        /// The local tax base of this SalesTaxes record
        /// <summary>
        public decimal LocalTaxBase { get; set; }

        /// <summary>
        /// The local tax amount of this SalesTaxes record
        /// <summary>
        public decimal LocalTaxAmount { get; set; }

        /// <summary>
        /// The local tax rate of this SalesTaxes record
        /// <summary>
        public decimal LocalTaxRate { get; set; }

        /// <summary>
        /// The other tax active of this SalesTaxes record
        /// <summary>
        public bool OtherTaxActive { get; set; }

        /// <summary>
        /// The other tax name of this SalesTaxes record
        /// <summary>
        public string OtherTaxName { get; set; }

        /// <summary>
        /// The other tax base of this SalesTaxes record
        /// <summary>
        public decimal OtherTaxBase { get; set; }

        /// <summary>
        /// The other tax amount of this SalesTaxes record
        /// <summary>
        public decimal OtherTaxAmount { get; set; }

        /// <summary>
        /// The other tax rate of this SalesTaxes record
        /// <summary>
        public decimal OtherTaxRate { get; set; }



    }
}
