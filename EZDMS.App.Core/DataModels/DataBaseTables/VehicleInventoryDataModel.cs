using System;
using System.Collections.Generic;
using System.Text;

namespace EZDMS.App.Core
{
    public class VehicleInventoryDataModel
    {

        /// <summary>
        /// The id of this vehicle inventory record
        /// <summary>
        public int ID { get; set; }

        /// <summary>
        /// The prefix id of this vehicle inventory record
        /// <summary>
        public string PrefixID { get; set; }

        /// <summary>
        /// The status of this vehicle inventory record
        /// <summary>
        public string Status { get; set; }

        /// <summary>
        /// The stock number of this vehicle inventory record
        /// <summary>
        public string StockNumber { get; set; }

        /// <summary>
        /// The create date of this vehicle inventory record
        /// <summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// The last modified date of this vehicle inventory record
        /// <summary>
        public DateTime LastModifiedDate { get; set; }

        /// <summary>
        /// The type of this vehicle inventory record
        /// <summary>
        public string Type { get; set; }

        /// <summary>
        /// The year of this vehicle inventory record
        /// <summary>
        public int Year { get; set; }

        /// <summary>
        /// The make of this vehicle inventory record
        /// <summary>
        public string Make { get; set; }

        /// <summary>
        /// The model of this vehicle inventory record
        /// <summary>
        public string Model { get; set; }

        /// <summary>
        /// The body style of this vehicle inventory record
        /// <summary>
        public string BodyStyle { get; set; }

        /// <summary>
        /// The v i n of this vehicle inventory record
        /// <summary>
        public string VIN { get; set; }

        /// <summary>
        /// The model number of this vehicle inventory record
        /// <summary>
        public string ModelNumber { get; set; }

        /// <summary>
        /// The class of this vehicle inventory record
        /// <summary>
        public string Class { get; set; }

        /// <summary>
        /// The odometer of this vehicle inventory record
        /// <summary>
        public int Odometer { get; set; }

        /// <summary>
        /// The odometer status of this vehicle inventory record
        /// <summary>
        public string OdometerStatus { get; set; }

        /// <summary>
        /// The color of this vehicle inventory record
        /// <summary>
        public string Color { get; set; }

        /// <summary>
        /// The interior color of this vehicle inventory record
        /// <summary>
        public string InteriorColor { get; set; }

        /// <summary>
        /// The trim color of this vehicle inventory record
        /// <summary>
        public string TrimColor { get; set; }

        /// <summary>
        /// The number of doors of this vehicle inventory record
        /// <summary>
        public int NumberOfDoors { get; set; }

        /// <summary>
        /// The cylinders of this vehicle inventory record
        /// <summary>
        public int Cylinders { get; set; }

        /// <summary>
        /// The fuel type of this vehicle inventory record
        /// <summary>
        public string FuelType { get; set; }

        /// <summary>
        /// The fuel system of this vehicle inventory record
        /// <summary>
        public string FuelSystem { get; set; }

        /// <summary>
        /// The fuel economy of this vehicle inventory record
        /// <summary>
        public string FuelEconomy { get; set; }

        /// <summary>
        /// The transmission type of this vehicle inventory record
        /// <summary>
        public string TransmissionType { get; set; }

        /// <summary>
        /// The transmission speed of this vehicle inventory record
        /// <summary>
        public string TransmissionSpeed { get; set; }

        /// <summary>
        /// The drivetrain of this vehicle inventory record
        /// <summary>
        public string Drivetrain { get; set; }

        /// <summary>
        /// The engine of this vehicle inventory record
        /// <summary>
        public string Engine { get; set; }

        /// <summary>
        /// The engine type of this vehicle inventory record
        /// <summary>
        public string EngineType { get; set; }

        /// <summary>
        /// The engine serial number of this vehicle inventory record
        /// <summary>
        public string EngineSerialNumber { get; set; }

        /// <summary>
        /// The ignition key code of this vehicle inventory record
        /// <summary>
        public string IgnitionKeyCode { get; set; }

        /// <summary>
        /// The trunk key code of this vehicle inventory record
        /// <summary>
        public string TrunkKeyCode { get; set; }

        /// <summary>
        /// The weight of this vehicle inventory record
        /// <summary>
        public int Weight { get; set; }

        /// <summary>
        /// The m s r p of this vehicle inventory record
        /// <summary>
        public decimal MSRP { get; set; }

        /// <summary>
        /// The inventory price of this vehicle inventory record
        /// <summary>
        public decimal InventoryPrice { get; set; }

        /// <summary>
        /// The list price of this vehicle inventory record
        /// <summary>
        public decimal ListPrice { get; set; }

        /// <summary>
        /// The internet price of this vehicle inventory record
        /// <summary>
        public decimal InternetPrice { get; set; }

        /// <summary>
        /// The accounting cost of this vehicle inventory record
        /// <summary>
        public decimal AccountingCost { get; set; }

        /// <summary>
        /// The a c v of this vehicle inventory record
        /// <summary>
        public decimal ACV { get; set; }

        /// <summary>
        /// The added costs of this vehicle inventory record
        /// <summary>
        public decimal AddedCosts { get; set; }

        /// <summary>
        /// The stock date of this vehicle inventory record
        /// <summary>
        public DateTime StockDate { get; set; }

        /// <summary>
        /// The days in stock of this vehicle inventory record
        /// <summary>
        public int DaysInStock { get; set; }

        /// <summary>
        /// The registration number of this vehicle inventory record
        /// <summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// The registration due date of this vehicle inventory record
        /// <summary>
        public DateTime RegistrationDueDate { get; set; }

        /// <summary>
        /// The registration amount of this vehicle inventory record
        /// <summary>
        public decimal RegistrationAmount { get; set; }

        /// <summary>
        /// The advertising of this vehicle inventory record
        /// <summary>
        public decimal Advertising { get; set; }

        /// <summary>
        /// The reconditioning of this vehicle inventory record
        /// <summary>
        public decimal Reconditioning { get; set; }

        /// <summary>
        /// The holdback of this vehicle inventory record
        /// <summary>
        public decimal Holdback { get; set; }

        /// <summary>
        /// The dealer pack of this vehicle inventory record
        /// <summary>
        public decimal DealerPack { get; set; }

        /// <summary>
        /// The buyer fee of this vehicle inventory record
        /// <summary>
        public decimal BuyerFee { get; set; }

        /// <summary>
        /// The license plate of this vehicle inventory record
        /// <summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// The license state of this vehicle inventory record
        /// <summary>
        public string LicenseState { get; set; }

        /// <summary>
        /// The license expiration date of this vehicle inventory record
        /// <summary>
        public DateTime LicenseExpirationDate { get; set; }

        /// <summary>
        /// The purchase source of this vehicle inventory record
        /// <summary>
        public string PurchaseSource { get; set; }

        /// <summary>
        /// The purchase vendor of this vehicle inventory record
        /// <summary>
        public string PurchaseVendor { get; set; }

        /// <summary>
        /// The bought from of this vehicle inventory record
        /// <summary>
        public string BoughtFrom { get; set; }

        /// <summary>
        /// The notes of this vehicle inventory record
        /// <summary>
        public string Notes { get; set; }

        /// <summary>
        /// The is salvage of this vehicle inventory record
        /// <summary>
        public bool IsSalvage { get; set; }

        /// <summary>
        /// The is buyers guide of this vehicle inventory record
        /// <summary>
        public bool IsBuyersGuide { get; set; }

        /// <summary>
        /// The is smog certificate of this vehicle inventory record
        /// <summary>
        public bool IsSmogCertificate { get; set; }

        /// <summary>
        /// The is p65 sticker of this vehicle inventory record
        /// <summary>
        public bool IsP65Sticker { get; set; }

        /// <summary>
        /// The is new license of this vehicle inventory record
        /// <summary>
        public bool IsNewLicense { get; set; }

        /// <summary>
        /// The report of sale number of this vehicle inventory record
        /// <summary>
        public string ReportOfSaleNumber { get; set; }

        /// <summary>
        /// The reg zip of this vehicle inventory record
        /// <summary>
        public string RegZip { get; set; }

        /// <summary>
        /// The reg county of this vehicle inventory record
        /// <summary>
        public string RegCounty { get; set; }

        /// <summary>
        /// The is editable of this vehicle inventory record
        /// <summary>
        public bool IsEditable { get; set; }

        /// <summary>
        /// The purchase type of this vehicle inventory record
        /// <summary>
        public string PurchaseType { get; set; }

        /// <summary>
        /// The purchase check number of this vehicle inventory record
        /// <summary>
        public string PurchaseCheckNumber { get; set; }

        /// <summary>
        /// The is show on web of this vehicle inventory record
        /// <summary>
        public bool IsShowOnWeb { get; set; }

        /// <summary>
        /// The lot location of this vehicle inventory record
        /// <summary>
        public string LotLocation { get; set; }

    }
}
